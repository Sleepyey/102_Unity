using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackL : MonoBehaviour
{

    public float moveSpeed = 0.4f;
    public float lTime = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-moveSpeed, 0, 0 * Time.deltaTime);         //x축 방향으로 이동

        lTime -= Time.deltaTime;

        if (lTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("EnemyB"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
