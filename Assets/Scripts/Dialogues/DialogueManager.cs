using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject _dialogueBox;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _messageText;

    private Queue<string> _sentences;

    [SerializeField] private Animator _animator;

    public static Action OnDialogueEnd;

    private void Start()
    {
        _dialogueBox.SetActive(true);
        _sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation");
        
        _animator.SetBool("IsOpen", true);
        _nameText.text = dialogue.NPCName;

        _sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = _sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void EndDialogue()
    {
        OnDialogueEnd?.Invoke();
        _animator.SetBool("IsOpen", false);
        Debug.Log("End of conversation");
        OnDialogueEnd = null;
    }

    IEnumerator TypeSentence(string sentence)
    {
        _messageText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            _messageText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
