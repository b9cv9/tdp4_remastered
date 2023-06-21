using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    /*public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }*/
    public float timeDestroy = 3f;
    public float speed = 0.3f;
    public int damagee = 10;
    public Rigidbody2D rb;
    public Enemy enemy_damage;


    void Start()
    {
        enemy_damage = FindObjectOfType<Enemy>();
        rb = GetComponent<Rigidbody2D>();

        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        rb.velocity = transform.right * speed;
        Invoke("DestroyBullet", timeDestroy);

    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            enemy_damage.TakeDamage(damagee);
        }
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }

}
