using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRR : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    public float lTime = 20f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed, 0, 0 * Time.deltaTime);         //x�� �������� �̵�

        lTime -= Time.deltaTime;

        if (lTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
