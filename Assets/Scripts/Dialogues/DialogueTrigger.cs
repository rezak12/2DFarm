using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    [SerializeField] private GameObject tipImage;

    [Header("Coordinate")]
    [SerializeField] private Vector2 positionToLeave;
    [SerializeField] bool shouldFlip;

    private bool shouldLeave = false;
    private bool isSpeaked;
    private DialogueManager dm;
    private QuestTrigger questTrigger;

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
                DialogueManager.OnDialogueEnd += questTrigger.TriggerQuest;
        }

        if (shouldLeave)
        {
            transform.position = Vector2.MoveTowards(transform.position, positionToLeave, 2 * Time.deltaTime);
            if((Vector2)transform.position == positionToLeave)
            {
                Destroy(gameObject);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tipImage.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isSpeaked && positionToLeave != new Vector2(0, 0))
        {
            if (shouldFlip)
            {
                bool flip = GetComponent<SpriteRenderer>().flipX;
                GetComponent<SpriteRenderer>().flipX = !flip;
            }
            shouldLeave = true;
        }
        tipImage.SetActive(false);
    }
}
