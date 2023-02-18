using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private Transform target;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private float attackRate = 2f;
    //[SerializeField] private int damage = 3;
    public LayerMask targetLayer;
    private float nextAttackTime = 0f;
    private bool facingRight;


    void Update()
    {
        bool shouldAttack = false;
        if (Time.time >= nextAttackTime)
        {
            Collider2D[] hitTargets = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);

            foreach (Collider2D target in hitTargets)
            {
                if (target.tag == "Player")
                    shouldAttack = true;
                   
            }
            if (shouldAttack)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        if (!facingRight && enemy.movement.x > 0)
        {
            Flip();
        }
        else if (facingRight && enemy.movement.x < 0)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if (enemy.shouldFollow)
        {
            Vector3 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void Attack()
    {
        // animation {}

        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayer);

        //foreach (Collider2D target in hitTargets)
        //{
        //    target.GetComponent<Player>().TakeDamage(damage);
        //}

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
