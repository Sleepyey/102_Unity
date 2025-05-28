using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void GameStartButtonAction()
    {
        SceneManager.LoadScene("Level_1");      //�̵��� �� �̸� �ۼ�
    }
    public void EndGame()
    {
        Application.Quit();
    }

    // RankPage Script�� ����ִ� ������Ʈ �ҷ�����
    public RankPage rankPage;

    //�������� ��ŷ ��ư
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
