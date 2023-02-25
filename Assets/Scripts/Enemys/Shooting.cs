using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] float attackRate = 1f;
    private float nextAttackTime = 0f;

    public float bulletForce = 20f;
    private Vector2 mousePos;
    [SerializeField] private Camera cam;
    public float offset;
    private bool facingRight;

    private void Awake()
    {
     
    }
    void Update()
    {

        if (Time.time >= nextAttackTime && Input.GetButtonDown("Fire1"))
        {
            Shoot();
            nextAttackTime = Time.time + 1f / attackRate;
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (!facingRight && player.movement.x < 0)
        {
            Flip();
        }
        else if (facingRight && player.movement.x > 0)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        Vector3 lookDir = (Vector3)mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + offset);
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        //bulletRb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
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
