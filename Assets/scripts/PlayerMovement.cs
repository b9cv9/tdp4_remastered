using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //speed
    [SerializeField] private float speed;
    private Rigidbody2D body;
    public float JumpingHeight;
    private bool grounded;
    public static bool check_rotation_right;
    private bool check_crouching;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        //moving
        float HorizontalInput = Input.GetAxis("Horizontal");
        body.velocity= new Vector2(HorizontalInput * speed,body.velocity.y);


        if (HorizontalInput > 0)
        {
            transform.localScale = new Vector3(0.5f, 1.5f, 0.5f);
            check_rotation_right = true;
        }
            
        if (HorizontalInput < 0)
        {
            transform.localScale = new Vector3(-0.5f, 1.5f, 0.5f);
            check_rotation_right = false;
        }
            



        //flip player when moving left or right
        


        //jumping
        if (Input.GetKeyDown(KeyCode.W) && grounded == true && check_crouching == false)
        {
            Jump(); 
        }


        //crouching
        /*if (Input.GetKeyDown(KeyCode.S) && grounded == true)
        {
            if(check_rotation_right == true)
            {
                transform.rotation = Quaternion.Euler(0,0,-90);
            }
            if (check_rotation_right == false)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                
            }
        }*/
        /*else if (Input.GetKeyUp(KeyCode.S) && grounded == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }*/

    }


    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed * JumpingHeight);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            grounded = true;
    }
}
