using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A utility script that makes the camera follow the player.
/// Not part of the tutorial.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    public float minY;
    public float maxY;

    // Update is called once per frame
    void Update()
    {
        float oldZ = transform.position.z;
        Vector3 target = followTarget.transform.position;
        target.y = Mathf.Clamp(target.y, minY, maxY);
        target.z = oldZ;
        transform.position = target;
    }
}
