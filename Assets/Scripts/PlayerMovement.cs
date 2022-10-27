using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool isHoldingUmbrella = false;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("LightTile") && !(isHoldingUmbrella)) // You can name this tag whatever you want, just make sure to tag all your death triggers with this
        {
            //Reset game here:
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    [SerializeField] float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D rb;

    Vector2 movement;

    [SerializeField] public Sprite moveRight;
    [SerializeField] public Sprite moveLeft;
    [SerializeField] public Sprite idle;
    [SerializeField] public Sprite pushRight;
    [SerializeField] public Sprite pushLeft;
    [SerializeField] public int delay;
    void ChangeSprite(Sprite _NewSprite)
    {
        this.GetComponent<SpriteRenderer>().sprite = _NewSprite;
    }
    

    // Update is called once per frame
    void Update()
    {
        // Input 

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        

    }

    void HoldUmbrellaStop()
    {
        isHoldingUmbrella = false;
    }

    void FixedUpdate()
    {
        // Movement

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if(this.GetComponent<SpriteRenderer>().sprite != pushLeft && this.GetComponent<SpriteRenderer>().sprite != pushRight)
        {
            if (Input.GetKey(KeyCode.D))
            {
                ChangeSprite(moveRight);
                return;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                ChangeSprite(moveLeft);
                return;
            }
            
        }

        if(!Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D) && this.GetComponent<SpriteRenderer>().sprite != idle)
        {
            ChangeSprite(idle);
        }
        
        
        if(Input.GetKey(KeyCode.Space))
        {
            isHoldingUmbrella = true;
            Invoke("HoldUmbrellaStop", delay);
        }



    }
}
