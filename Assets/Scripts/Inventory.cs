using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    private int _woodCount = 0;
    private int _stoneCount = 0;
    private int _carrotCount = 0;
    private int _potatoCount = 0;
    private int _pumpkinCount = 0;
    private int _strawberryCount = 0;
    private int _tomatoCount = 0;
    private int _turnipCount = 0;

    public int woodCount => _woodCount;
    public int stoneCount => _stoneCount;
    public int carrotCount => _carrotCount;
    public int potatoCount => _potatoCount;
    public int pumpkinCount => _pumpkinCount;
    public int strawberryCount => _strawberryCount;
    public int tomatoCount => _tomatoCount;
    public int turnipCount => _turnipCount;

    [SerializeField] private GameObject inventoryTable;
    [SerializeField] private TMP_Text _wood;
    [SerializeField] private TMP_Text _stone;

    private void Awake()
    {
        inventoryTable.SetActive(false);
        Initialize();
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I) && !inventoryTable.activeSelf)
            ShowInventory();
        else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.I))
            CloseInventory();

        //if (Input.GetKeyDown(KeyCode.Space))
        //    AddItem("wood", 2);
        //else if (Input.GetKeyDown(KeyCode.LeftControl))
        //    RemoveItem("wood", 2);
    }

    public void AddItem(string type, int count)
    {
        ref int itemCount = ref _woodCount;
        switch (type.ToUpper())
        {
            case "WOOD":
                itemCount = ref _woodCount;
                break;
            case "STONE":
                itemCount = ref _stoneCount;
                break;
            default:
                Debug.LogError("The wrong item type was passed");
                break;
        }
        if (itemCount + count > 100)
        {
            Debug.Log("Inventory could not have more then 100 items of the same type");
            return;
        }
        itemCount += count;
    }

    public void RemoveItem(string type, int count)
    {
        ref int itemCount = ref _woodCount;
        switch (type.ToUpper())
        {
            case "WOOD":
                itemCount = ref _woodCount;
                break;
            case "STONE":
                itemCount = ref _stoneCount;
                break;
            default:
                Debug.LogError("The wrong item type was passed");
                break;
        }
        if (itemCount - count <= 0)
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
        _wood.text = _woodCount.ToString();
        _stone.text = _stoneCount.ToString();
    }
}
