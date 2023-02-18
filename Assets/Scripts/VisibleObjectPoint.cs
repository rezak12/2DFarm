using UnityEngine;

public class VisibleObjectPoint : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Transform checkPoint;
    private Vector2 mousePos;
    [SerializeField] private Camera cam;
    [SerializeField] private float checkRadius;
    private bool facingRight;
    [SerializeField] private LayerMask farmArea;
    [SerializeField] private GameObject select;
    void Start()
    {
    
    }

    void Update()
    {
        GameObject selectObj;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (!facingRight && player.movement.x < 0)
            Flip();

        else if (facingRight && player.movement.x > 0)
            Flip();

        Collider2D selectArea = Physics2D.OverlapCircle(checkPoint.position, checkRadius, farmArea);
        if(selectArea != null)
            selectObj = Instantiate(select, selectArea.GetComponent<Transform>());
    }

    private void FixedUpdate()
    {
        Vector3 lookDir = (Vector3)mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkPoint.position, checkRadius);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        Scaler.y *= -1;
        transform.localScale = Scaler;
    }
}
