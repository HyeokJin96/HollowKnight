using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static partial class GFunc
{
    //! 다른 씬을 로드하는 함수
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }   //  LoadScene()
}
