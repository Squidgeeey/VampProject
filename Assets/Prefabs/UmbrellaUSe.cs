using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UmbrellaUSe : MonoBehaviour
{

    public bool isHoldingUmbrella = false;
    [SerializeField] public int umbrellaUseCount;
    [SerializeField] public int delay;

void OnTriggerEnter2D(Collider2D col)
{
    if (col.CompareTag("LightTile") && !(isHoldingUmbrella)) // You can name this tag whatever you want, just make sure to tag all your death triggers with this
    {
        //Reset game here:
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

    void HoldUmbrellaStop()
    {
        isHoldingUmbrella = false;
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
                }
            }
            
            
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
