using UnityEngine;
using TMPro;

public class Plant : MonoBehaviour
{

    private Inventory _inventory;
    private bool _readyForDrop = false;
    private float dropTime;
    [SerializeField] private string _itemToDrop;
    [SerializeField] private float _timeForPrepare;
    [SerializeField] private float checkRadius = 0.5f;
    [SerializeField] private TMP_Text _timer;

    private SoundManager _soundManager;
    [SerializeField] private AudioClip _audioPlant;
    [SerializeField] private AudioClip _audioTake;

    void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        _soundManager = FindObjectOfType<SoundManager>();
        _timer.text = _timeForPrepare.ToString();
        _timer.enabled = true;
        _readyForDrop = false;
        dropTime = Time.time + _timeForPrepare;
        _soundManager.PlaySound(_audioPlant);
    }

    void Update()
    {
        if(Time.time < dropTime)
        {
            _timer.text = ((int)dropTime - (int)Time.time).ToString();
        }
        else
        {
            _readyForDrop = true;
            _timer.enabled = false;
        }

        if (_readyForDrop)
        {
            Collider2D[] checkInfo = Physics2D.OverlapCircleAll(transform.position, checkRadius);
            foreach (Collider2D item in checkInfo)
            {
                if(item.tag == "Player" && Input.GetKeyDown(KeyCode.E))
                {
                    _soundManager.PlaySound(_audioTake);
                    DropAndDestroy();
                }
            }
        }
    }

    public void DropAndDestroy()
    {
        _inventory.AddItem(_itemToDrop, Random.Range(1, 3));
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
