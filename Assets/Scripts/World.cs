using UnityEngine;

public class World : MonoBehaviour
{
    public GameObject brique;
    public GameObject personnage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    for (int i = 0; i < 10; i++)
        {
        for (int j = 0; j < 10; j++)
            Instantiate(brique, new Vector3(1*j,0,1*i), Quaternion.identity);
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
            
            personnage.transform.position = Vector3.zero; // Vector3.zero correspond à (0, 0, 0)
            
            if (cc != null) cc.enabled = true;
        }
    }
}
