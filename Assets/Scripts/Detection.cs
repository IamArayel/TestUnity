using UnityEngine;

public class Detection : MonoBehaviour
{

  private void OnTriggerEnter(Collider other)
  {
    Debug.Log("Collision détectée avec le déclencheur " + other.gameObject.name);
  }

  private void OnTriggerStay(Collider other)
  {
    
  }

  private void OnTriggerExit(Collider other)
  {
    
  }
}
