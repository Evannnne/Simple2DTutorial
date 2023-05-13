using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A helper script to allow for parallax backgrounds.
/// Not part of tutorial.
/// </summary>
public class Parallax : MonoBehaviour
{
    public Vector2 dragFactor;
    public Transform followTarget;

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(followTarget.transform.position.x * dragFactor.x, followTarget.transform.position.y * dragFactor.y);
        transform.position = target;
    }
}
