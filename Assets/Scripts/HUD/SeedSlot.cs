using UnityEngine;
using UnityEngine.UI;

public class SeedSlot : MonoBehaviour
{
    private Image _currentSeed;
    [SerializeField] Sprite[] _seeds;
    void Start()
    {
        _currentSeed = GetComponent<Image>();
    }

    void Update()
    {
        
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
