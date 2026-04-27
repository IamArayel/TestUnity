using UnityEngine;

public class SerpGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject personnage;
    public GameObject cube;
    
    public Vector3 a = new Vector3(0,0,0);
    public Vector3 b = new Vector3(-7,0,30);
    public Vector3 c = new Vector3(13,0,29);

    public Vector3 origine;
    public Vector3 destination;


    
    void Start()
    {
        // 1. Origine : on choisit de commencer sur le point 'a'
        origine = a;

        // 2. On répète l'action 10 000 fois
        for (int i = 0; i < 10000; i++)
        {
            // 3. lancer un dé (0, 1 ou 2) pour choisir une destination au hasard
            int deMagique = Random.Range(0, 3);
            if (deMagique == 0) destination = a;

            else if (deMagique == 1) destination = b;

            else destination = c;

            // 4. calculer le point situé pile au milieu de l'origine et de la destination
            Vector3 milieu = Vector3.Lerp(origine, destination, 0.5f);

            // 5. faire apparaître un cube à ce milieu
            Instantiate(cube, milieu, Quaternion.identity);

            // 6. nouveau point de départ pour le prochain tour
            origine = milieu;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reset position personnage");
            
            // Il faut désactiver le CharacterController temporairement pour autoriser la téléportation
            CharacterController cc = personnage.GetComponent<CharacterController>();
            if (cc != null) cc.enabled = false;
            
            personnage.transform.position = new Vector3(0, 0.5f, 0); // Positionné en X=0 Y=0 Z=0
            
            if (cc != null) cc.enabled = true;
        }
    }
}
