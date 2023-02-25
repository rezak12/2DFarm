using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private enum EnemyType { Melee, Shooting };
    [SerializeField] EnemyType enemyType;

    private enum MovingTo { toPlayer, outOfPlayer, stay };
    private MovingTo movingTo = MovingTo.stay;
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float startFollowRadious = 3f;
    [SerializeField] private float stopDistance = 7;
    [SerializeField] private float nearDistance = 5;
    public Vector2 movement;
    private Rigidbody2D rb;
    public bool targetIsVisible;
    public bool shouldFollow;
    private bool facingRight;


    //[SerializeField] private HealthBar healthBar;
    public int maxHealth = 10;
    private int health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        health = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (shouldFollow)
        {
            Vector2 direction = (target.position - transform.position);
            direction.Normalize();
            movement = direction;


            if (Vector2.Distance(transform.position, target.position) >= stopDistance)
            {
                movingTo = MovingTo.toPlayer;
            }
            else if (Vector2.Distance(transform.position, target.position) < stopDistance && Vector2.Distance(transform.position, target.position) > nearDistance)
            {
                movingTo = MovingTo.stay;
            }
            else if (Vector2.Distance(transform.position, target.position) <= nearDistance)
            {
                movingTo = MovingTo.outOfPlayer;
            }
        }
        else
        {
            Collider2D[] hitTargets = Physics2D.OverlapCircleAll(transform.position, startFollowRadious);

            foreach (Collider2D target in hitTargets)
            {
                if (target.tag == "Player")
                {
                    shouldFollow = true;
                }
            }
        }

        if (!facingRight && movement.x > 0)
        {
            Flip();
        }
        else if (facingRight && movement.x < 0)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if (shouldFollow)
        {
            if (movingTo == MovingTo.toPlayer)
            {
                rb.MovePosition((Vector2)transform.position + (movement * moveSpeed * Time.fixedDeltaTime));
            }
            else if (movingTo == MovingTo.stay)
            {
                //go around the player
            }
            else if (movingTo == MovingTo.outOfPlayer)
            {
                rb.MovePosition((Vector2)transform.position - (movement * moveSpeed * Time.fixedDeltaTime));
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, startFollowRadious);
    }

    //void moveCharacter(Vector2 direction)
    //{
    //    // delete this
    //    rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.fixedDeltaTime));
    //}

    public void TakeDamage(int damage)
    {
        health -= damage;
        //healthBar.SetHealth(health);
        if (health <= 0)
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
