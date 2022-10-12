using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("LightTile")) // You can name this tag whatever you want, just make sure to tag all your death triggers with this
        {
            //Reset game here:
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    [SerializeField] float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D rb;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        // Input 

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        

    }

    void FixedUpdate()
    {
        // Movement

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);


    }
}
