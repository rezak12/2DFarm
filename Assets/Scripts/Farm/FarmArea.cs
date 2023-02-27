using System;
using UnityEngine;

public class FarmArea : MonoBehaviour
{
    [Header("Managements")]
    [SerializeField] private QuestManager _questManager;
    public static Action<string> OnPlant;
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private AudioClip _audio;

    [Header("Graphics")]
    [SerializeField] private Sprite _uncultivatedGround;
    [SerializeField] private Sprite _cultivatedGround;

    [Header("For Interact")]
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _carrotPlant;
    [SerializeField] private GameObject _potatoPlant;
    [SerializeField] private GameObject _pumpkinPlant;
    [SerializeField] private GameObject _strawberryPlant;
    [SerializeField] private GameObject _tomatoPlant;
    [SerializeField] private GameObject _turnipPlant;

    private enum AreaType { Uncultivated, Cultivated, ReadyForPlant, WithPlant};
    private AreaType areaType;
    private bool _canInteract = false;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (_canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

        if (areaType == AreaType.WithPlant)
        {
            bool shouldRetype = true;
            Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, 0.1f);
            if (collider2Ds.Length > 0)
            {
                foreach (Collider2D item in collider2Ds)
                {
                    if (item.tag == "Plant")
                    {
                        shouldRetype = false;
                    }
                }
            }
            if (shouldRetype)
            {
                _spriteRenderer.color = Color.white;
                _spriteRenderer.sprite = _uncultivatedGround;
                areaType = AreaType.Uncultivated;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
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
                Plant();
                areaType = AreaType.WithPlant;
                break;
            case AreaType.WithPlant:
                break;
            default:
                Debug.Log("Wrong type of area: " + gameObject.name);
                break;
        }
        _soundManager.PlaySound(_audio);
    }

    private void Plant()
    {
        Inventory inventory = _player.GetComponent<Inventory>();
        string seed = _player.GetCurrentSeed().ToLower();
        GameObject plant = new GameObject();
        switch (seed)
        {
            case "carrot":
                Destroy(plant);
                plant = _carrotPlant;
                break;
            case "potato":
                Destroy(plant);
                plant = _potatoPlant;
                break;
            case "pumpkin":
                Destroy(plant);
                plant = _pumpkinPlant;
                break;
            case "strawberry":
                Destroy(plant);
                plant = _strawberryPlant;
                break;
            case "tomato":
                Destroy(plant);
                plant = _tomatoPlant;
                break;
            case "turnip":
                Destroy(plant);
                plant = _turnipPlant;
                break;
            default:
                Debug.Log("Have not a current seed");
                break;
        }

        Instantiate(plant, transform.position, transform.rotation, this.transform);
        OnPlant?.Invoke(seed);
    }

}
