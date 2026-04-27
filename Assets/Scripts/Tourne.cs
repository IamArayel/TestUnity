using UnityEngine;

public class Tourne : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Je suis dans le start");
    }

    // Update is called once per frame

    public GameObject brique;

    void Update()
    {
        //Debug.Log("Je suis dans l'update");
        // À chaque frame, tu vas tourner le gameObject sur lequel tu es greffé de quelques règles
        Vector3 haut=new Vector3(0,1,0);
        this.gameObject.transform.Rotate(haut, 0.01f);

        // Si le joueur appuie sur la touche F
        // J'écris un debug log
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("J'ai appuyé sur F");

            Instantiate(brique, this.gameObject.transform.position,Quaternion.identity); // Quaternion.identity -> "sans rotation"
        }
    }
}
