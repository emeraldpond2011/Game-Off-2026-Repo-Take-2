using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float horizontal;
    public float speed = 8f;
    public float jumpingPower = 7f;
    public bool isFacingRight = true;
    public bool isGrounded;
    public float groundLayer = 3f;
    public float timer;
    public float airTimeMax = 0.5f;
    public float gravityMulti = 0f;
    public float gravityBaseForce = 1f;
    public float airTimeMulti = 40f;
    public GroundCheckScript checkScript;
    public bool onSlidingPlatform;
    public bool onRotatingPlatform;

    [SerializeField] private Rigidbody2D rb;
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            }
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space))
        {
            if (rb.linearVelocity.y > 0f)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
                GravityLogic();
            }
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void GravityLogic()
    {
        if (timer < airTimeMax)
        {
            timer = timer + Time.deltaTime;
            gravityMulti = timer * airTimeMulti;
            rb.gravityScale = gravityBaseForce + gravityMulti;
        }
        else
        {
            rb.gravityScale = gravityBaseForce + gravityMulti;
        }
    }
    public void ResetGravity()
    {
        gravityMulti = 0f;
        timer = 0f;
        rb.gravityScale = gravityBaseForce;
    }
}
