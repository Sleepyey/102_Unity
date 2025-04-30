using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    public float lTime = 4f;

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
}
