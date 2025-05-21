using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using Cainos.LucidEditor; // ���� ����

public class RankPage : MonoBehaviour
{
    [SerializeField] Transform contentRoot;     // Content ������Ʈ
    [SerializeField] GameObject rowPrefab;      // RankRow ������

    StageResultList allData;

    private void Awake()
    {
        allData = StageResultSaver.LoadRank();
        RefreshRankList();
    }

    void RefreshRankList()
    {
        foreach (Transform child in contentRoot)
        {
            Destroy(child.gameObject);
        }

        //�����͸� �����ļ����� ����
        var sortedData = allData.result.Where(r => r.stage == 1).OrderByDescending(Matrix4x4 => Matrix4x4.score).ToList();

        for (int i = 0; i < sortedData.Count; i++)
        {
            GameObject row = Instantiate(rowPrefab, contentRoot);
            TMP_Text rankText = row.GetComponentInChildren<TMP_Text>();
            rankText.text = $"{i + 1}. {sortedData[i].playerName} - {sortedData[i].score}";
        }
    }
}
