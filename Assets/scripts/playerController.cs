using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    private Rigidbody2D rb;
    //public float speed;
    private int speed = 10;
    private int v;
    private int jumpSpeed;
    private int jumpForce = 700;
    private int count;
    private float startPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = rb.position.y;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 5)
        {//jumpSpeed = 9;
            rb.AddForce(Vector3.up * jumpForce);
        }
        else
        {
            if (rb.velocity.y <0)
                rb.AddForce(Vector3.down * jumpForce);
            //jumpSpeed = 0;
        }
  

        if (Input.GetKey(KeyCode.RightArrow))
            v = speed;
        else if (Input.GetKey(KeyCode.LeftArrow))
            v = -speed;
        else
            v = 0;

        rb.velocity = new Vector2(v, jumpSpeed);
    }
    /*
    void FixedUpdate()
    {
        float moveHoriz = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");
        Vector2 mv = new Vector2 (moveHoriz,moveVert);
        rb.AddForce(mv*speed);
    }
    */
}
