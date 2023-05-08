using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private bool isFacingRight = true;


    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    [Header("Dashing")]
    [SerializeField] public HasDash Dash;
    [SerializeField] TrailRenderer trailRenderer;
    [SerializeField] private float dashSpeed = 14f;
    [SerializeField] private float dashTime = 0.5f;
    private Vector2 dashDir;
    private bool isDashing;
    private bool canDash = true;
    private enum MovementState { idle, running, jumping, falling }

    //[SerializeField] private AudioSource jumpsound;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        trailRenderer= GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        var dashInput = Input.GetButtonDown("Dash");

        if (dashInput && canDash && Dash.hasDash)
        {
            
            isDashing= true;
            canDash= false;
            trailRenderer.emitting = true;
            dashDir = new Vector2(dirX, Input.GetAxisRaw("Vertical"));
            if (dashDir == Vector2.zero)
            {
                dashDir = new Vector2(transform.localScale.x, 0);
            }
            if (isDashing)
            {
                rb.velocity = dashDir.normalized * dashSpeed;
                
            }

            
            Debug.Log("dash anim");
            anim.SetBool("dash", isDashing);
            
            StartCoroutine(StopDashing());
            
        }
        if (Grounded())
        {
            canDash = true;
        }
        if (Input.GetButtonDown("Jump") && Grounded() == true)
        {
            //jumpsound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
        Flip();


    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }
    private IEnumerator StopDashing() 
    {
        
        yield return new WaitForSeconds(dashTime);
        trailRenderer.emitting= false;
        isDashing = false;
        anim.SetBool("dash", isDashing);
        Debug.Log("Stop Dash");
    }
    private bool Grounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    private void Flip()
    {
        if (isFacingRight && dirX < 0f || !isFacingRight && dirX > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
