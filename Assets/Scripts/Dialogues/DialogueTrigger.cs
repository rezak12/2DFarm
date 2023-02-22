using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    [SerializeField] private GameObject tipImage;
    private DialogueManager dm;

    private void Start()
    {
        tipImage.SetActive(false);
        dm = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {
        if(tipImage.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            dm.StartDialogue(dialogue);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tipImage.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tipImage.SetActive(false);
    }
}
