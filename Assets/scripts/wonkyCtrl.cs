using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wonkyCtrl : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject projectile;
    public Transform circle;
    //public float speed;
    private int speed = 5;
    private int v;
    private int jumpForce = 300;
    private int count;
    private float scaleFactor = 0.01F;
    float lowerbound = 0.1F;
    float upperbound = 0.5F;
    float pscale;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pscale = transform.localScale.x;
    }

    bool scale_lowB()
    {
        if (transform.localScale.x > lowerbound && transform.localScale.y > lowerbound)
            return true;
        else
        {
            return false;
        }
    }

    bool scale_upB() {
        if (transform.localScale.y < upperbound && transform.localScale.x < upperbound)
            return true;
        else
            return false;
    }

    void Update()
    {
        //int yPos = transform.position.y;
        if (scale_upB() && Input.GetKey(KeyCode.UpArrow))
        {
            /*&& transform.position.y < 2*/
            //rb.AddForce(Vector3.up * jumpForce);
            transform.localScale += new Vector3(scaleFactor, scaleFactor, 0);
        }
        else if (scale_lowB() && Input.GetKey(KeyCode.DownArrow))
        {
            //&& transform.position.y < 2
            //rb.AddForce(Vector3.up * jumpForce);
            transform.localScale += new Vector3(-scaleFactor, -scaleFactor, 0);
            transform.position += new Vector3(0, -0.02F, 0);
            // transform.localScale = new Vector3(pscale, pscale, 0);
        }


        if (Input.GetKey(KeyCode.RightArrow)) {
            GameObject bullet = Instantiate(projectile, new Vector3(transform.position.x +1, transform.position.y), Quaternion.identity) as GameObject;
            Rigidbody2D bulletRB = bullet.AddComponent<Rigidbody2D>();
            //bullet.GetComponent<Rigidbody2D>().AddForce(transform.forward*10);
            Destroy(bullet, 2);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)){
            GameObject bullet = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y-1), Quaternion.identity) as GameObject;
            Rigidbody2D bulletRB = bullet.AddComponent<Rigidbody2D>();
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector3(0,10,0));
            Destroy(bullet, 2);
        }
        else
            v = 0;
        /*
        if (Input.GetKey(KeyCode.RightArrow))
        {
            v = speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
            v = -speed;
        else
            v = 0;
        rb.velocity = new Vector3(v,0, 0);
        */
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
