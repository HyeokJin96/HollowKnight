using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutDoor : MonoBehaviour
{
    [SerializeField] public GameObject gameobject = default;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Slash"))
        {
            GFunc.LoadScene(GData.SCENE_NAME_LEVEL02);
        }
    }
}
