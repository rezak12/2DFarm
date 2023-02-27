using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeedSlot : MonoBehaviour
{
    private Image _currentSeed;
    [SerializeField] private Sprite[] _seeds;
    [SerializeField] private TMP_Text _seedCount;
    [SerializeField] private Inventory inventory;
    void Start()
    {
        _currentSeed = GetComponent<Image>();
    }

    private void Update()
    {
        string currentSeed = inventory.GetCurrentSeed();
        int count = 0;

        if (currentSeed == "carrot")
        {
            count = inventory.carrotSeedCount;
        }
        else if (currentSeed == "potato")
        {
            count = inventory.potatoSeedCount;
        }
        else if (currentSeed == "pumpkin")
        {
            count = inventory.pumpkinSeedCount;
        }
        else if (currentSeed == "strawberry")
        {
            count = inventory.strawberrySeedCount;
        }
        else if (currentSeed == "tomato")
        {
            count = inventory.tomatoSeedCount;
        }
        else if (currentSeed == "turnip")
        {
            count = inventory.turnipSeedCount;
        }

        _seedCount.text = count.ToString();
    }

    public void ChangeCurrentSeed(int seedNumber)
    {
        if(seedNumber > _seeds.Length || seedNumber < 0)
        {
            Debug.LogError("Pushed not valid value");
            return;
        }
        _currentSeed.sprite = _seeds[seedNumber];
    }

}
