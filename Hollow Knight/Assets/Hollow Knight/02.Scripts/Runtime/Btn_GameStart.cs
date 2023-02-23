using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_GameStart : MonoBehaviour
{
    public void OnGameStartButton()
    {
        GFunc.LoadScene(GData.SCENE_NAME_LEVEL01);
    }   //  OnGameStartButton()
}
