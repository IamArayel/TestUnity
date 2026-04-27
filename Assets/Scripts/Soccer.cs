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

    private void Start()
    {
        if (ballon != null)
            ballonRb = ballon.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
    Debug.Log(other.gameObject.name);
        // Remonte au GameObject racine via le Rigidbody pour gérer les colliders enfants

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

    private IEnumerator ResetBallon()
    {
        yield return new WaitForFixedUpdate();
        ballonRb.linearVelocity = Vector3.zero;
        ballonRb.angularVelocity = Vector3.zero;
        ballonRb.position = ballonPositionInitiale;
    }

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
