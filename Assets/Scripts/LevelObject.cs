using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelObject : MonoBehaviour
{
    public string nextLevel;
    // nextLevel -> Inspector 에서 설정

    public void MoveToNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
        // Inspector 에서 받은 nextLevel 값의 씬으로 이동
    }
}
