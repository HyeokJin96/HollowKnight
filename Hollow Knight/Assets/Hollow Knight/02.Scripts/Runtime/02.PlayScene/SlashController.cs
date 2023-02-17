using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashController : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {

        if (GData.isAttacking == true)
        {
            gameObject.SetActive(true);
        }
    }

}
