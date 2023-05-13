using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A utility class that helps determine when an object is touching something adjacent. Requires a collider with 'IsTrigger' set to true to function.
/// Not part of the tutorial.
/// </summary>
public class CollisionChecker : MonoBehaviour
{
    public LayerMask checkMask;
    public bool Colliding;

    private bool IsLayerMatch(int layer, LayerMask value) => ((1 << layer) & value) != 0;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsLayerMatch(collision.gameObject.layer, checkMask))
            Colliding = true;
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (IsLayerMatch(collision.gameObject.layer, checkMask))
            Colliding = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (IsLayerMatch(collision.gameObject.layer, checkMask))
            Colliding = false;
    }
}
