using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialScript : MonoBehaviour
{
    private static bool hasMoved = false;
    private static bool hasInteracted = false;

    public TextMeshProUGUI listenText;
    public Image blackboardImage;
    public TextMeshProUGUI moveText;
    public Image blackboardImageMove;



    // Start is called before the first frame update
    void Start()
    {
        
        if (hasInteracted)
        {
            listenText.gameObject.SetActive(false);
            blackboardImage.gameObject.SetActive(false);
        }
        if (hasMoved)
        {
            moveText.gameObject.SetActive(false);
            blackboardImageMove.gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            if(!hasMoved)
            {
                hasMoved = true;
            }
            
        }


        if (hasMoved)
        {
            moveText.gameObject.SetActive(false);
            blackboardImageMove.gameObject.SetActive(false);
            if(!hasInteracted)
            {
                listenText.gameObject.SetActive(true);
                blackboardImage.gameObject.SetActive(true);
            }
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Crush"))
        {
            if(Input.GetKeyDown(KeyCode.E) && !hasInteracted)
            {
                listenText.gameObject.SetActive(false);
                blackboardImage.gameObject.SetActive(false);
                hasInteracted = true;
            }

        }
    }
}
