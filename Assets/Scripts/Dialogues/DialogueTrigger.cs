using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    [SerializeField] private GameObject tipImage;
    private DialogueManager dm;
    private QuestTrigger questTrigger;
    private bool isSpeaked;

    private void Start()
    {
        tipImage.SetActive(false);
        dm = FindObjectOfType<DialogueManager>();
        questTrigger = GetComponent<QuestTrigger>();
    }

    private void Update()
    {
        if(tipImage.activeSelf && Input.GetKeyDown(KeyCode.E) && !isSpeaked)
        {
            dm.StartDialogue(dialogue);
            isSpeaked = true;
        }
        else if(tipImage.activeSelf && Input.GetKeyDown(KeyCode.E) && isSpeaked)
        {
            dm.DisplayNextSentence();
            if (questTrigger != null)
                questTrigger.TriggerQuest();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tipImage.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isSpeaked = false;
        tipImage.SetActive(false);
    }
}
