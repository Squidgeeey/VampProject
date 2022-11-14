using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Dialogue : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private Image speaker;
    [SerializeField] private Image dialogueBox;

    private bool updatedDialogue;

    void Start()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
        updatedDialogue = false;
    }

    private void OnSceneChanged(Scene current, Scene next)
    {
        if(next.name == "Corridor" && updatedDialogue == false)
        {
            dialogueIdx = Mathf.Clamp(dialogueIdx + 1, 0, dialogues.Length);
            updatedDialogue = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] public string[] dialogues;

    //Static variables persist through script destruction / scene load
    [SerializeField] private static int dialogueIdx = 0;
    

    
    public string GetDialogue()
    {
        Assert.IsTrue(dialogueIdx < dialogues.Length); //Assertion sanity check, you can omit this if you want, I just like them
        string dialogue = dialogues[dialogueIdx];

        return dialogue;
    }

    public void ShowDialogue()
    {
        //...

        string dialogue = GetDialogue();
        textBox.text = dialogue;
        speaker.gameObject.SetActive(true);
        dialogueBox.gameObject.SetActive(true);
        textBox.gameObject.SetActive(true);

        //...
    }

    public void HideDialogue()
    {
        //...
        speaker.gameObject.SetActive(false);
        dialogueBox.gameObject.SetActive(false);
        textBox.gameObject.SetActive(false);

        //...
    }
}
