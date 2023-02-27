using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 7f;

    private Animator animator;
    private float moveSpeed;
    private bool isRunning = false;
    private Player player;
    private Rigidbody2D rb;
    public Vector2 movement { get; private set; }
    private bool facingRight;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = walkSpeed;
    }
    void Update()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        movement = new Vector2(X, Y).normalized;

        if (movement.x == 0 && movement.y == 0)
        {
            animator.SetBool("IsWalk", false);
        }
        else
        {
            animator.SetBool("IsWalk", true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetRunning(true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            SetRunning(false);
        }

        if (isRunning)
        {
            player.stamina -= Time.deltaTime * 4;
            if (player.stamina < 0)
            {
                player.stamina = 0;
                SetRunning(false);
            }
        }
        else if (player.stamina < player.maxStamina)
        {
            player.stamina += Time.deltaTime * 2;
        }

        if(!facingRight && movement.x < 0)
        {
            Flip();
        }
        else if(facingRight && movement.x > 0)
        {
            Flip();
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        if (facingRight)
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }
        else if (!facingRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void SetRunning(bool isRunning)
    {
        this.isRunning = isRunning;
        moveSpeed = isRunning ? runSpeed : walkSpeed;
    }
}
