using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    // The player's speed
    public float playerSpeed = 10;
    // The player's jump velocity
    public float jumpVelocity = 10;
    // The amount of health the player has
    public int health = 3;

    public CollisionChecker groundChecker;
    public CollisionChecker sideCheckerLeft;
    public CollisionChecker sideCheckerRight;

    private Rigidbody2D m_rigidbody;
    private Animator m_animator;
    private SpriteRenderer m_renderer;

    private float m_lastDamageTime;

    // Called once at the very beginning
    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_renderer = GetComponent<SpriteRenderer>();

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetVelocity = m_rigidbody.velocity;

        // If touching ground and pressing jump, apply upwards velocity
        if (groundChecker.Colliding && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))) targetVelocity.y = jumpVelocity;

        // Get horizontal movement
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && !sideCheckerLeft.Colliding) targetVelocity.x = -playerSpeed;
        else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && !sideCheckerRight.Colliding) targetVelocity.x = playerSpeed;
        else targetVelocity.x = 0;

        // Apply velocity
        m_rigidbody.velocity = targetVelocity;

        // Apply animations
        m_animator.SetBool("Running", targetVelocity.x != 0);
        m_animator.SetBool("Jumping", !groundChecker.Colliding);

        // Flip sprite
        if(targetVelocity.x != 0) m_renderer.flipX = targetVelocity.x < 0;
    }

    public void Damage()
    {
        // If you haven't been damaged in the last second
        if (Time.time - m_lastDamageTime >= 1)
        {
            m_animator.SetTrigger("Damage");
            m_lastDamageTime = Time.time;
            health--;

            if(health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
