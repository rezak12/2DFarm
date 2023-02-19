using UnityEngine;

public class FarmArea : MonoBehaviour
{
    private enum AreaType { Uncultivated, Cultivated, ReadyForPlant, WithPlant};
    [SerializeField] private AreaType areaType;
    private bool _canInteract = false;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _uncultivatedGround;
    [SerializeField] private Sprite _cultivatedGround;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _plantsTable;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(_canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _canInteract = false;
        }
    }

    private void Interact()
    {
        Debug.Log("Interacting with " + gameObject.name);

        switch (areaType)
        {
            case AreaType.Uncultivated:
                _spriteRenderer.sprite = _cultivatedGround;
                areaType = AreaType.Cultivated;
                break;
            case AreaType.Cultivated:
                _spriteRenderer.color = new Color(0.87f, 0.65f, 0.65f, 1f);
                areaType = AreaType.ReadyForPlant;
                break;
            case AreaType.ReadyForPlant:
                //interact
                areaType = AreaType.WithPlant;
                break;
            case AreaType.WithPlant:
                //
                break;
            default:
                Debug.Log("Wrong type of area: " + gameObject.name);
                break;
        }
    }

    private void Plant()
    {
        string seed = _player.GetCurrentSeed();
        GameObject plant;
        //spawn plant of this type seed
    }

}
