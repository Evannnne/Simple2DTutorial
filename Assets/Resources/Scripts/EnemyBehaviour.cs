using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float endOffset = 10;
    public float speed = 1;

    private SpriteRenderer m_renderer;
    private Vector3 m_start;

    private void Awake()
    {
        m_renderer = GetComponent<SpriteRenderer>();
        m_start = transform.position;

        StartCoroutine(WalkLoop());
    }

    private IEnumerator WalkLoop()
    {
        Vector3 end = m_start + Vector3.right * endOffset;

        Vector3 currentStart = m_start;
        Vector3 currentTarget = end;

        while (true)
        {
            // Move towards target
            float t = 0;
            while(t < 1)
            {
                // Flip if moving left
                m_renderer.flipX = currentTarget.x - currentStart.x > 0;

                // Move towards end
                transform.position = Vector3.Lerp(currentStart, currentTarget, t);
                t += Time.deltaTime * (speed / endOffset);
                yield return new WaitForEndOfFrame();
            }

            // Swap variables
            Vector3 tmp = currentStart;
            currentStart = currentTarget;
            currentTarget = tmp;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerController.Instance.Damage();
        }
    }
}
