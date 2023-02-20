using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    public Transform target = default;

    private void Update()
    {
        transform.position = new Vector3(target.position.x, 0f, transform.position.z);
    }
}
