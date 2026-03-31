using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public Animator anim;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 12f;

    [Header("碰撞信息")]
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] public float groundCheckDistance;

    [Header("冲刺信息")]
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashSpeed = 12f;
    [SerializeField] private float dashCooldown = 1f; // 冲刺冷却持续时间

    [Header("攻击信息")]
    [SerializeField] private bool isAttacking = false;
    [SerializeField] public int comboCounter;
    private float dashTime;
    private float dashCooldownTimer; // 冲刺冷却时间
    [SerializeField] private float comboTime = .3f ; // 连击最小时间
    [SerializeField] private float comboTimeWindow;

    private bool isGrounded;
    private float xInput;
    private int facingDir = 1;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

    }

    private void Update()
    {
        Movement();
        CheckPoint();
        CollisionChecks();
        FlipController();
        AnimatorControllers();

        dashTime -= Time.deltaTime;
        dashCooldownTimer -= Time.deltaTime;

        comboTimeWindow -= Time.deltaTime;

    }

    private void CollisionChecks()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void CheckPoint()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartAttack();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashAbility();
        }
    }

    private void StartAttack()
    {
        if (!isGrounded)
            return;

        if (comboTimeWindow < 0)
            comboCounter = 0;

        isAttacking = true;
        comboTimeWindow = comboTime;
        //comboCounter++;
    }

    private void DashAbility()
    {
        if (dashCooldownTimer < 0 && !isAttacking )
        {
            dashCooldownTimer = dashCooldown;
            dashTime = dashDuration;
        }
    }

    public void  AttackOver()
    {
        //return isAttacking;
        isAttacking = false;
        comboCounter++;
        if(comboCounter > 2) 
            comboCounter = 0;
     
    }
    private void Movement()
    {
        if (isAttacking)
        {
            rb.velocity = Vector2.zero;
        }
        else if (dashTime > 0)
        {
            //float dashDir = xInput != 0 ? Mathf.Sign(xInput) : facingDir;

            rb.velocity = new Vector2(facingDir * dashSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void AnimatorControllers()
    {
        bool isMoving = xInput != 0 ? true : false;
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isMoving", isMoving);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isDashing", dashTime > 0f);
        anim.SetBool("isAttacking", isAttacking);
        anim.SetInteger("comboCounter", comboCounter);
    }

    private void Flip()
    {
        facingDir *= -1;
        facingRight = !facingRight;
        this.transform.localScale = new Vector3(facingDir, 1, 1);
    }

    private void FlipController()
    {
        if (facingRight && xInput < 0)
        {
            Flip();
        }
        else if (!facingRight && xInput > 0)
        {
            Flip();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheckDistance));
    }
}
