using System.Collections;
using UnityEngine;

// Attacher ce script sur l'objet Goal (qui doit avoir un Collider en mode Is Trigger)
public class Soccer : MonoBehaviour
{
    [Header("Ballon")]
    public GameObject ballon;

    [Header("Position initiale du ballon (centre du terrain)")]
    public Vector3 ballonPositionInitiale = new(0f, 0.624f, 0.5f);

    [Header("Score max pour gagner")]
    public int scoreMax = 3;

    private int score = 0;
    private Rigidbody ballonRb;

    // Récupère le Rigidbody du ballon une seule fois au démarrage pour éviter
    // d'appeler GetComponent à chaque collision
    private void Start()
    {
        if (ballon != null)
            ballonRb = ballon.GetComponent<Rigidbody>();
    }

    // Appelé quand un objet entre dans le trigger du Goal.
    // Filtre pour ne réagir qu'au ballon (tag "Ballon"), incrémente le score,
    // remet le ballon en position initiale et termine le jeu si le score max est atteint.
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ballon")) return;

        score++;
        Debug.Log("But ! Score : " + score);

        StartCoroutine(ResetBallon());

        if (score >= scoreMax)
        {
            Debug.Log("Partie terminée ! " + scoreMax + " points atteints.");
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }

    // Attend la fin du step physique en cours avant de téléporter le ballon,
    // sinon Unity écrase le changement de position pendant la simulation.
    private IEnumerator ResetBallon()
    {
        yield return new WaitForFixedUpdate();
        ballonRb.linearVelocity = Vector3.zero;
        ballonRb.angularVelocity = Vector3.zero;
        ballonRb.position = ballonPositionInitiale;
    }

    // Affiche le score en overlay à l'écran à chaque frame d'interface.
    private void OnGUI()
    {
        GUIStyle style = new(GUI.skin.label)
        {
            fontSize = 36,
            normal = { textColor = Color.white }
        };
        GUI.Label(new Rect(20, 20, 300, 60), "Score : " + score + " / " + scoreMax, style);
    }
}
