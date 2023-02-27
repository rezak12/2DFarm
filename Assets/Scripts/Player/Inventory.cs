using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    private int _carrotCount = 0;
    private int _potatoCount = 0;
    private int _pumpkinCount = 0;
    private int _strawberryCount = 0;
    private int _tomatoCount = 0;
    private int _turnipCount = 0;

    private int _carrotSeedCount = 3;
    private int _potatoSeedCount = 3;
    private int _pumpkinSeedCount = 3;
    private int _strawberrySeedCount = 3;
    private int _tomatoSeedCount = 3;
    private int _turnipSeedCount = 3;

    public int carrotCount => _carrotCount;
    public int potatoCount => _potatoCount;
    public int pumpkinCount => _pumpkinCount;
    public int strawberryCount => _strawberryCount;
    public int tomatoCount => _tomatoCount;
    public int turnipCount => _turnipCount;
    public int carrotSeedCount => _carrotSeedCount;
    public int potatoSeedCount => _potatoSeedCount;
    public int pumpkinSeedCount => _pumpkinSeedCount;
    public int strawberrySeedCount => _strawberrySeedCount;
    public int tomatoSeedCount => _tomatoSeedCount;
    public int turnipSeedCount => _turnipSeedCount;

    [Header("Seeds")]
    [SerializeField] private SeedSlot _seedslot;
    [SerializeField] private string[] _seedTypes;
    private int _currentSeed = 0;

    [Header("UI")]
    [SerializeField] private GameObject inventoryTable;
    [SerializeField] private TMP_Text _carrot;
    [SerializeField] private TMP_Text _potato;
    [SerializeField] private TMP_Text _pumpkin;
    [SerializeField] private TMP_Text _strawberry;
    [SerializeField] private TMP_Text _tomato;
    [SerializeField] private TMP_Text _turnip;
    [SerializeField] private TMP_Text _carrotSeed;
    [SerializeField] private TMP_Text _potatoSeed;
    [SerializeField] private TMP_Text _pumpkinSeed;
    [SerializeField] private TMP_Text _strawberrySeed;
    [SerializeField] private TMP_Text _tomatoSeed;
    [SerializeField] private TMP_Text _turnipSeed;

    private void Awake()
    {
        inventoryTable.SetActive(false);
        Initialize();
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I) && !inventoryTable.activeSelf)
        {
            ShowInventory();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.I))
        {
            CloseInventory();
        }
    }

    public string GetCurrentSeed()
    {
        return _seedTypes[_currentSeed];
    }

    public void ChangeSeedInHand()
    {
        if (_currentSeed < _seedTypes.Length - 1)
        {
            _currentSeed++;
        }
        else if (_currentSeed == _seedTypes.Length - 1)
        {
            _currentSeed = 0;
        }
        _seedslot.ChangeCurrentSeed(_currentSeed);
    }

    public void AddItem(string type, int count)
    {
        ref int itemCount = ref _carrotCount;
        switch (type.ToLower())
        {
            case "carrot":
                itemCount = ref _carrotCount;
                break;
            case "potato":
                itemCount = ref _potatoCount;
                break;
            case "pumpkin":
                itemCount = ref _pumpkinCount;
                break;
            case "strawberry":
                itemCount = ref _strawberryCount;
                break;
            case "tomato":
                itemCount = ref _tomatoCount;
                break;
            case "turnip":
                itemCount = ref _turnipCount;
                break;
            case "carrotseed":
                itemCount = ref _carrotSeedCount;
                break;
            case "potatoseed":
                itemCount = ref _potatoSeedCount;
                break;
            case "pumpkinseed":
                itemCount = ref _pumpkinSeedCount;
                break;
            case "strawberryseed":
                itemCount = ref _strawberryCount;
                break;
            case "tomatoseed":
                itemCount = ref _tomatoSeedCount;
                break;
            case "turnipseed":
                itemCount = ref _turnipSeedCount;
                break;
            default:
                Debug.LogError("The wrong item type was passed");
                break;
        }
        if (itemCount + count > 99)
        {
            Debug.Log("Inventory could not have more then 100 items of the same type");
            return;
        }
        itemCount += count;
    }

    public void RemoveItem(string type, int count)
    {
        ref int itemCount = ref _carrotCount;
        switch (type)
        {
            case "carrot":
                itemCount = ref _carrotCount;
                break;
            case "potato":
                itemCount = ref _potatoCount;
                break;
            case "pumpkin":
                itemCount = ref _pumpkinCount;
                break;
            case "strawberry":
                itemCount = ref _strawberryCount;
                break;
            case "tomato":
                itemCount = ref _tomatoCount;
                break;
            case "turnip":
                itemCount = ref _turnipCount;
                break;
            case "carrotseed":
                itemCount = ref _carrotSeedCount;
                break;
            case "potatoseed":
                itemCount = ref _potatoSeedCount;
                break;
            case "pumpkinseed":
                itemCount = ref _pumpkinSeedCount;
                break;
            case "strawberryseed":
                itemCount = ref _strawberrySeedCount;
                break;
            case "tomatoseed":
                itemCount = ref _tomatoSeedCount;
                break;
            case "turnipseed":
                itemCount = ref _turnipSeedCount;
                break;
            default:
                Debug.LogError("The wrong item type was passed");
                break;
        }
        if (itemCount - count < 0)
        {
            Debug.Log("Inventory could not have less then 0 items of the same type");
            return;
        }
        itemCount -= count;
    }

    public void ShowInventory()
    {
        Time.timeScale = 0f;
        Initialize();
        inventoryTable.SetActive(true);
    }

    public void CloseInventory()
    {
        Time.timeScale = 1f;
        inventoryTable.SetActive(false);
    }

    private void Initialize()
    {
        _carrot.text = carrotCount.ToString();
        _potato.text = potatoCount.ToString();
        _pumpkin.text = pumpkinCount.ToString();
        _strawberry.text = strawberryCount.ToString();
        _tomato.text = tomatoCount.ToString();
        _turnip.text = turnipCount.ToString();
        _carrotSeed.text = carrotSeedCount.ToString();
        _potatoSeed.text = potatoSeedCount.ToString();
        _pumpkinSeed.text = pumpkinSeedCount.ToString();
        _strawberrySeed.text = strawberrySeedCount.ToString();
        _tomatoSeed.text = tomatoSeedCount.ToString();
        _turnipSeed.text = turnipSeedCount.ToString();
    }
}
