using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float enemyHp = 5f;

    private Rigidbody2D rb;
    private bool isMovingRight = true;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (enemyHp <= 0)
        {
            Destroy(gameObject);
        }
        if (isMovingRight)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1f);
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            isMovingRight = !isMovingRight;
        }
        if (collision.CompareTag("Attack"))
        {
            enemyHp--;
        }
    }
}
