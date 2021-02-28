using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    private float speed = 16f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public GameObject staminaBar;

    void Start()
    {
        var livesScript = gameObject.GetComponent<LivesScript>();
        staminaBar.GetComponent<StaminaScript>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * hozMovement + transform.forward * verMovement;

        controller.Move(moveDirection * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if((Input.GetKey(KeyCode.LeftShift)) || (Input.GetButton("Run")))
        {
            if (staminaBar.GetComponent<StaminaScript>().currentStamina > 0)
            {
                speed = 25f;
                StaminaScript.instance.UseStamina(1);

                //Debug.Log("Gotta go fast!");
            }

            else if (staminaBar.GetComponent<StaminaScript>().currentStamina <= 0)
            {
                speed = 16f;
            }
        }
        else
        {
            speed = 16f;
        }
    }

        void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("Collided with the player!");
            gameObject.SendMessage("TakeDamage", 1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Maze"))
        {

        }
        if(other.gameObject.CompareTag("Ending"))
        {
            
        }
    }

}
