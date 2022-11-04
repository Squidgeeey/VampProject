using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfTrigger : MonoBehaviour
{
    [SerializeField] private StateController targetController;
    [SerializeField] private int targetState;
    [SerializeField] private int originalState;
    [SerializeField] Collider2D targetPosition;
    [SerializeField] private bool isMoveable = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision == targetPosition)
        {
            targetController.SetState(targetState);
            
            
            if(!isMoveable)
            {
                transform.position = collision.transform.position;
                Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
                rigidbody.isKinematic = true;
                rigidbody.velocity = Vector2.zero;
            }
           
            
        }
        else
        {
            targetController.SetState(originalState);
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == targetPosition)
        {
            targetController.SetState(originalState);


        }

    }
}
