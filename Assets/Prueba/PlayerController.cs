using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float speed;
    [SerializeField] private int jumpForce;
    [SerializeField] private bool isGround;


    float horizontal;



    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }


    private void OnEnable()
    {
        InputManager.OnPlayerMovement += Move;
        InputManager.Jump += Jump;
    }

    private void OnDisable()
    {
        InputManager.OnPlayerMovement -= Move;
        InputManager.Jump -= Jump;
    }


    public void Move(float input)
    {
        this.horizontal = input;
    }

    public void Jump()
    {
        if(isGround == true)
        {
            rb2D.AddForce(new Vector2(0f, 4f * jumpForce), ForceMode2D.Impulse);
        }
    }

   

    private void FixedUpdate()
    {
        rb2D.position += new Vector2(horizontal *speed *Time.fixedDeltaTime,0);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            isGround = false;
        }
    }
}
