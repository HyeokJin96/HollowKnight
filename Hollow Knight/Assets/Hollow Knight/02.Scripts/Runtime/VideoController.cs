using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VideoController : MonoBehaviour
{
    [SerializeField] public GameObject skipTxt;

    private void Start()
    {
        skipTxt.SetActive(false);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            skipTxt.SetActive(true);
        }

    }
}
