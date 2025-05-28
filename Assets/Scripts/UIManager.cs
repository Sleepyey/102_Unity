using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void GameStartButtonAction()
    {
        SceneManager.LoadScene("Level_1");      //이동할 씬 이름 작성
    }
    public void EndGame()
    {
        Application.Quit();
    }

    // RankPage Script가 들어있는 오브젝트 불러오기
    public RankPage rankPage;

    //스테이지 랭킹 버튼
    public static int stageNum = 0;
    public void ClickStage1()
    {
        stageNum = 1;
        rankPage.RefreshRankList();
    }
    public void ClickStage2()
    {
        stageNum = 2;
        rankPage.RefreshRankList();
    }
    public void ClickStage3()
    {
        stageNum = 3;
        rankPage.RefreshRankList();
    }
    public void ClickStage4()
    {
        stageNum = 4;
        rankPage.RefreshRankList();
    }
    public void ClickStage5()
    {
        stageNum = 5;
        rankPage.RefreshRankList();
    }
}
