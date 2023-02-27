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
    [SerializeField] private Inventory _playerInventory;
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
        string seed = _playerInventory.GetCurrentSeed().ToLower();
        int seedCount = 0;
        GameObject plant = new GameObject();
        switch (seed)
        {
            case "carrot":
                Destroy(plant);
                seedCount = _playerInventory.carrotSeedCount;
                if (seedCount > 0)
                {
                    plant = _carrotPlant;
                    _playerInventory.RemoveItem("carrotseed", 1);
                }
                break;
            case "potato":
                Destroy(plant);
                seedCount = _playerInventory.potatoSeedCount;
                if(seedCount > 0)
                {
                    plant = _potatoPlant;
                    _playerInventory.RemoveItem("potatoseed", 1);
                }
                break;
            case "pumpkin":
                Destroy(plant);
                seedCount = _playerInventory.pumpkinSeedCount;
                if( seedCount > 0)
                {
                    plant = _pumpkinPlant;
                    _playerInventory.RemoveItem("pumpkinseed", 1);
                }
                break;
            case "strawberry":
                Destroy(plant);
                seedCount = _playerInventory.strawberrySeedCount;
                if(seedCount > 0)
                {
                    plant = _strawberryPlant;
                    _playerInventory.RemoveItem("strawberryseed", 1);
                }
                break;
            case "tomato":
                Destroy(plant);
                seedCount = _playerInventory.tomatoSeedCount;
                if(seedCount > 0)
                {
                    plant = _tomatoPlant;
                    _playerInventory.RemoveItem("tomatoseed", 1);
                }
                break;
            case "turnip":
                Destroy(plant);
                seedCount = _playerInventory.turnipSeedCount;
                if(seedCount > 0)
                {
                    plant = _turnipPlant;
                    _playerInventory.RemoveItem("turnipseed", 1);
                }
                break;
            default:
                Debug.Log("Have not a current seed");
                break;
        }
        if (plant != null)
        {
        Instantiate(plant, transform.position, transform.rotation, this.transform);
        OnPlant?.Invoke(seed);
        }
    }

}
