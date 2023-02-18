using UnityEngine;

public class ResourcesPoint : MonoBehaviour
{

    [SerializeField] private string resourceToDrop;
    private Inventory inventory;
    
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            DropAndDestroy();
    }

    

    public void DropAndDestroy()
    {
        inventory.AddItem(resourceToDrop, Random.Range(0, 3));
        Destroy(gameObject);
    }

}
