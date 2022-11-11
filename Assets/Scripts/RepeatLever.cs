using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatLever : MonoBehaviour
{
    [SerializeField] private StateController targetController;
    [SerializeField] private int leverState;
    [SerializeField] private int[] targetStates;
    [SerializeField] private float delay;
   private bool isSwitching;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipLever()
    {
        leverState = (leverState + 1) % 2;
        targetController.SetState(targetStates[leverState]);
        isSwitching = false;

  

    }

    private void FixedUpdate()
    {
        if (!isSwitching)
        {
            isSwitching = true;
            Invoke("FlipLever", delay);
        }
            

        
    }


}
