using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelTutorial : MonoBehaviour
{
    private static bool hasPushed = false;
    //private static bool hasObject = false;
    private static bool hasSwitched = false;

    public GameObject bookshelf;
    public GameObject character;

    public TextMeshProUGUI pushText;
    public Image pushBlackboard;

    public TextMeshProUGUI objectText;
    public Image objectBlackboard;

    public TextMeshProUGUI switchText;
    public Image switchBlackboard;



    // Start is called before the first frame update
    void Start()
    {
        
  
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bookshelf.GetComponent<Rigidbody2D>().velocity.magnitude != 0)
        {
            if(!hasPushed)
            {
                pushBlackboard.gameObject.SetActive(false);
                pushText.gameObject.SetActive(false);
                hasPushed = true;
                
            }
            
        }


        if (hasPushed)
        {
            pushText.gameObject.SetActive(false);
            pushBlackboard.gameObject.SetActive(false);
            if(!character.GetComponent<PlayerPush>().isObjectCollected)
            {
                objectText.gameObject.SetActive(true);
                objectBlackboard.gameObject.SetActive(true);
                //hasObject = true;
            }
        }

        if(character.GetComponent<PlayerPush>().isObjectCollected)
        {
            objectText.gameObject.SetActive(false);
            objectBlackboard.gameObject.SetActive(false);
            if(!hasSwitched)
            {
                switchText.gameObject.SetActive(true);
                switchBlackboard.gameObject.SetActive(true);
            }

            if(hasSwitched)
            {
                switchText.gameObject.SetActive(false);
                switchBlackboard.gameObject.SetActive(false);
            }
           
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Lever"))
        {
            Debug.Log("Interacting Crush");
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(" Released E");
                if (!hasSwitched)
                {

                    Debug.Log(" Destroying text");
                    //switchText.gameObject.SetActive(false);
                    //switchBlackboard.gameObject.SetActive(false);
                    hasSwitched = true;
                }
               
            }

        }
    }
}
