using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject deathpanel;

    public void ToggleDeathPanel()
    {
        deathpanel.SetActive(!deathpanel.activeSelf);
    }
}
