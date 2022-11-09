using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPush : MonoBehaviour
{

    public float distance = 0.5f;
    public LayerMask boxMask;

    private Lever lever;
    private LeverTimed leverTimed;
    private Dialogue dialogueBox;
    public bool isObjectCollected = false;

    public AudioSource audioSource;
    public AudioClip objectAudio;

    [SerializeField] public string[] levels;
    [SerializeField] private static int levelNum = 0;



    GameObject box;

    [SerializeField] public Sprite pushRight;
    [SerializeField] public Sprite pushLeft;
    [SerializeField] public Sprite idle;


    [SerializeField] public string m_sceneName;

    Vector3 raycastPos;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.D))
        {
            ChangeSprite(pushRight);
            return;
        }
        if (Input.GetKey(KeyCode.A))
        {
            ChangeSprite(pushLeft);
            return;
        }

        if (!Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D) && this.GetComponent<SpriteRenderer>().sprite != idle)
        {
            ChangeSprite(idle);
        }

    }

    void ChangeSprite(Sprite _NewSprite)
    {
        this.GetComponent<SpriteRenderer>().sprite = _NewSprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnSceneChanged(Scene current, Scene next)
    {
        if(next.name != "Corridor")
        {
            levelNum++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        raycastPos = transform.position;
   
       RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        //if (hit.collider != null && Input.GetKey(KeyCode.A))
        //{
        //    //box = hit.collider.gameObject;

        //    ChangeSprite(pushLeft);
        //}


        if (lever != null && Input.GetKeyDown(KeyCode.E))
        {
            lever.FlipLever();
        }
        if (leverTimed != null && Input.GetKeyDown(KeyCode.E))
        {
            leverTimed.FlipLever();
        }
        if (dialogueBox != null && Input.GetKeyDown(KeyCode.E))
        {
            dialogueBox.ShowDialogue();
            audioSource.Play();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LeverTimed"))
        {
            leverTimed = collision.GetComponent<LeverTimed>();
        }
        if (collision.CompareTag("Lever"))
        {
            lever = collision.GetComponent<Lever>();
        }
        if (collision.CompareTag("GoalTile"))
        {
            if( SceneManager.GetActiveScene().name == "Corridor")
            {
                SceneManager.LoadScene(levels[levelNum]);
            }
            else
            {
                if(isObjectCollected)
                {
                    SceneManager.LoadScene("Corridor");
                }
            }
           
        }
        if (collision.CompareTag("Object"))
        {
            isObjectCollected = true;
            audioSource.Play();
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Crush"))
        {
            dialogueBox = collision.GetComponent<Dialogue>();
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Lever"))
        {
            lever = null;
           
        }
        if (collision.CompareTag("Crush"))
        {
            dialogueBox.HideDialogue();
            audioSource.Stop();
            //dialogueBox = null;


        }
    }
}
