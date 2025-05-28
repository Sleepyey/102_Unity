using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelObject : MonoBehaviour
{
    public string nextLevel;
    // nextLevel -> Inspector ���� ����

    public void MoveToNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
        // Inspector ���� ���� nextLevel ���� ������ �̵�
    }
}
