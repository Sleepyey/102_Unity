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
            // 0~5 사이에서 랜덤으로 위치 인덱스 선택
            int randomIndex = Random.Range(0, attackPositions.Length);

            // 0~9 중 랜덤 숫자
            int randomP = Random.Range(0, 10);

            // 위치 가져오기
            Vector3 spawnPosition = attackPositions[randomIndex].position;

            // 디버그 확인

            // 조건에 따라 다른 프리팹 생성
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
