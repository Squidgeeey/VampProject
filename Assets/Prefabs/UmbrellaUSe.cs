using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UmbrellaUSe : MonoBehaviour
{

    public AudioSource umbrellaAudio;
    public AudioClip umbrellaClip;
    public AudioClip umbrellaClose;

    public bool isHoldingUmbrella = false;
    [SerializeField] public int umbrellaUseCount;
    [SerializeField] public int delay;
    [SerializeField] private Image image;
    public Sprite fullUmbrella;
    public Sprite damagedUmbrella;
    public Sprite brokenUmbrella;
    public Sprite unusableUmbrella;
   

void OnTriggerStay2D(Collider2D col)
{
    if (col.CompareTag("LightTile") && !(isHoldingUmbrella)) // You can name this tag whatever you want, just make sure to tag all your death triggers with this
    {
        //Reset game here:
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        //fullUmbrella = Resources.Load<Sprite>("UmbrellaUINormal");
        //damagedUmbrella = Resources.Load<Sprite>("UmbrellaUIDamaged");
        //brokenUmbrella = Resources.Load<Sprite>("UmbrellaUIBroken");
        //unusableUmbrella = Resources.Load<Sprite>("UmbrellaUIUnusable");
    }

    void HoldUmbrellaStop()
    {
        isHoldingUmbrella = false;
        umbrellaAudio.clip = umbrellaClose;
        umbrellaAudio.Play();

    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(umbrellaUseCount > 0)
            {
                
                if (!isHoldingUmbrella)
                {
                    isHoldingUmbrella = true;
                    Invoke("HoldUmbrellaStop", delay);
                    umbrellaUseCount = umbrellaUseCount - 1;
                    Debug.Log("Used Umbrella");
                    umbrellaAudio.clip = umbrellaClip;
                    umbrellaAudio.Play();

                   
                }
            }
        }

        if(umbrellaUseCount >= 3)
        {
            image.sprite = fullUmbrella;
        }
        else if (umbrellaUseCount == 2)
        {
            image.sprite = damagedUmbrella;
        }
        else if (umbrellaUseCount == 1)
        {
            image.sprite = brokenUmbrella;
        }
        else if (umbrellaUseCount == 0)
        {
            image.sprite = unusableUmbrella;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
