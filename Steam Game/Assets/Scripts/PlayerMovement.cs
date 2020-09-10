using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour {

    public CharacterController controller;

    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;

    public float speed;
    Vector3 velocity;
    public float gravity = -100f;
    public float jumpHeight;
    public AudioSource walkingSound = null;

    bool isGrounded;

    void Update () {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float x = Input.GetAxisRaw ("Horizontal");
        float z = Input.GetAxisRaw ("Vertical");

        if(isGrounded == true){
            if(walkingSound != null){
                if(x != 0 || z != 0){
                    walkingSound.mute = false;
                }else{
                    walkingSound.mute = true;
                }
            }
        }

        Vector3 move = transform.right * x + transform.forward * z;

        // if (Input.GetKeyDown("shift")){
        //     if (controller.height == 1.5f){
        //         controller.height = 3.8f;
        //     }else{
        //         controller.height = 1.5f;
        //     }
        // }

        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -5 * gravity);
        }
        if (!isGrounded && velocity.y < 0f){
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
