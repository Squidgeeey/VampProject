using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject deathpanel;

    public void ToggleDeathPanel()
    {
         deathpanel.SetActive(!deathpanel.activeSelf);
    }

    public void Update()
    {
            
    }
}
