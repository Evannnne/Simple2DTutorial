using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10;
    public float jumpVelocity = 12.5f;
    public int health = 3;

    public CollisionChecker bottomChecker;
    public CollisionChecker leftChecker;
    public CollisionChecker rightChecker;

    private Rigidbody2D m_rigidbody;
    private Animator m_animator;
    private SpriteRenderer m_renderer;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetVelocity = m_rigidbody.velocity;

        if(bottomChecker.Colliding && Input.GetKeyDown(KeyCode.Space)) {
            targetVelocity.y = jumpVelocity;
        }

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            targetVelocity.x = -playerSpeed;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            targetVelocity.x = playerSpeed;
        }
        else
        {
            targetVelocity.x = 0;
        }

        m_rigidbody.velocity = targetVelocity;
        m_animator.SetBool("Running", m_rigidbody.velocity.x != 0);
        m_animator.SetBool("Jumping", !bottomChecker.Colliding);
        if(targetVelocity.x != 0) {
            m_renderer.flipX = targetVelocity.x < 0;
        }
    }
}
