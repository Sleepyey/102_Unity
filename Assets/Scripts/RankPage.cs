using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using Cainos.LucidEditor; // 정렬 도움

public class RankPage : MonoBehaviour
{
    [SerializeField] Transform contentRoot;     // Content 오브젝트
    [SerializeField] GameObject rowPrefab;      // RankRow 프리팹

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

        //데이터를 내림파순으로 정렬
        var sortedData = allData.result.Where(r => r.stage == 1).OrderByDescending(Matrix4x4 => Matrix4x4.score).ToList();

        for (int i = 0; i < sortedData.Count; i++)
        {
            GameObject row = Instantiate(rowPrefab, contentRoot);
            TMP_Text rankText = row.GetComponentInChildren<TMP_Text>();
            rankText.text = $"{i + 1}. {sortedData[i].playerName} - {sortedData[i].score}";
        }
    }
}
