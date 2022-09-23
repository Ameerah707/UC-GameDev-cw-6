using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    public float rad;

    public Transform groundCheck2;

    public LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 

    }

    // Update is called once per frame
    void Update()
    {
        patrol();
    }

    void patrol()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck2.position, rad, ground);
        rb.velocity = new Vector2(speed, 0f);

        if(!isGrounded)
        {
            speed *= -1;

            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
    void OnColliderEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")

        {

            SceneManager.LoadScene(0);

        }

    }
}
