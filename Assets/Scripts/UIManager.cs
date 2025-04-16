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
}
