using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static partial class GFunc
{
    //! �ٸ� ���� �ε��ϴ� �Լ�
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }   //  LoadScene()
}
