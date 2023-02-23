using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    [SerializeField] public Transform target = default;

    private void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y + 2f, transform.position.z);
    }
}
