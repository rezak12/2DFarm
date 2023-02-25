using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public float distance;
    public int damage = 5;
    public LayerMask whatIsSolid;
    public GameObject hitEffect;

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, Time.deltaTime, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                Destroy(gameObject);
            }

            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            Destroy(gameObject);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    //    Destroy(effect, 0.5f);
    //    Destroy(gameObject);
    //    if (collision.gameObject.tag == "Enemy")
    //        collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
    //}
}
