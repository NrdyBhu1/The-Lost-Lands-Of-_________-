using UnityEngine;

public class WaterScript : MonoBehaviour
{
    #region Variables
    private float buoyancy;
    #endregion

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            buoyancy = other.gameObject.GetComponent<PlayerMovement>().gravity;
            other.gameObject.GetComponent<PlayerMovement>().gravity = 0f;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")){
            other.gameObject.GetComponent<PlayerMovement>().gravity = buoyancy;
        }
    }
}
