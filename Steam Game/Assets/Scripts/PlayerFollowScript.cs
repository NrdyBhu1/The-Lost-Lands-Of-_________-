using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerFollowScript : MonoBehaviour
{
    #region Variables
    public Camera mycam;
    public float speed = 5f;
    public float range = 20f;
    public Volume volume;
    public Canvas deathCanvas;
    #endregion

    private void Start() {
        deathCanvas.gameObject.SetActive(false);
        volume.weight = 0f;
    }

    void FixedUpdate(){
        Shoot();
    }
    void Shoot(){
        RaycastHit hit;
        if (Physics.Raycast(mycam.transform.position, mycam.transform.forward, out hit, range)){
            if (hit.transform.gameObject.CompareTag("Player")){
                Move(hit.transform.position);
                transform.LookAt(hit.transform.position);
            }
        }
    }

    void Move(Vector3 position){
        transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
    }

    private void OnCollisionStay(Collision other) {
        if (other.collider.CompareTag("Player")){
            if(volume.weight >= 1f){
                other.gameObject.GetComponent<PlayerMovement>().enabled = false;
                other.gameObject.GetComponentInChildren<MouseLook>().enabled = false;
                deathCanvas.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }else{
                volume.weight += 0.1f;
            }
        }
    }
}
