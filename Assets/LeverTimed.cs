using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTimed : MonoBehaviour
{
    [SerializeField] private StateController targetController;
    [SerializeField] private int leverState;
    [SerializeField] private int[] targetStates;
    [SerializeField] private int delay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReturnState()
    {
        targetController.SetState(targetStates[0]);
    }

    public void FlipLever()
    {
        leverState = (leverState + 1) % 2;
        targetController.SetState(targetStates[leverState]);

        Invoke("ReturnState", delay); //2 is the time

    }


}
