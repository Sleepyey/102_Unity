using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
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
    
    public int stageNum = 0;
    public void ClickStage1()
    {
        stageNum = 1;
    }
    public void ClickStage2()
    {
        stageNum = 2;
    }
    public void ClickStage3()
    {
        stageNum = 3;
    }
    public void ClickStage4()
    {
        stageNum = 4;
    }
    public void ClickStage5()
    {
        stageNum = 5;
    }
}
