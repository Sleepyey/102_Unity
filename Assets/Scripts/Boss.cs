using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject bossAttackRPrefabs;
    public GameObject bossAttackPPrefabs;
    public Transform[] attackPositions;

    public Slider bosshpSli;

    public float bossHp = 200f;
    public float attackR = 50f;
    public float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BossAttack());
    }

    // Update is called once per frame
    void Update()
    {
       bosshpSli.value = bossHp;

        if (bossHp <= 0)
        {
            SceneManager.LoadScene("Level_0");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            bossHp--;
        }
        if (collision.CompareTag("Attack_R"))
        {
            bossHp -= attackR;
        }
    }

    IEnumerator BossAttack()
    {
        while (true)
        {
            // 0~5 ���̿��� �������� ��ġ �ε��� ����
            int randomIndex = Random.Range(0, attackPositions.Length);

            // 0~9 �� ���� ����
            int randomP = Random.Range(0, 10);

            // ��ġ ��������
            Vector3 spawnPosition = attackPositions[randomIndex].position;

            // ����� Ȯ��

            // ���ǿ� ���� �ٸ� ������ ����
            if (randomP <= 7)
            {
                Instantiate(bossAttackPPrefabs, spawnPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(bossAttackRPrefabs, spawnPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(1f);

        }
    }
}
