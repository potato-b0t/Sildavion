using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Torch;
    [Range(0, 1)]
    public float time;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(Torch.position, transform.position, time);
    }
}
