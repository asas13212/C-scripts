using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 玩家信息
    [Header("玩家移动")]
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float jumpForce = 10f;
    public int facingDir = 1;
    public bool facingRight = true;
    #endregion
    #region 玩家冲刺
    [Header("玩家冲刺")]
    [SerializeField] public float dashDuration = 200f;
    [SerializeField] public float dashSpeed = 20f;
    [SerializeField] private float dashUsageTimer;
    [SerializeField] private float dashCooldown;
    public float dashDir { get; private set; }

    #endregion
    #region 动画区域
    public Animator anim { get; private set; } 
    #endregion
    #region 状态区域
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; } 
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }

    public PlayerWallJumpState wallJumpState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerPrimaryAttack primaryAttack { get; private set; }

    #endregion
    #region 碰撞信息
    [Header("碰撞信息")]
    [SerializeField] public Transform groundCheck; // 地面检测点
    [SerializeField] public float groundCheckDistance;
    [SerializeField] public Transform wallCheck;
    [SerializeField] public float wallCheckDistance;
    [SerializeField] public LayerMask whatIsGround;
    [SerializeField] public LayerMask whatIsWall;
    #endregion
    public Rigidbody2D rb { get; private set; }

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSlideState = new PlayerWallSlideState(this, stateMachine, "WallSlide");
        wallJumpState = new PlayerWallJumpState(this, stateMachine, "Jump");
        primaryAttack = new PlayerPrimaryAttack(this, stateMachine, "Attack");
    }
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();  // 获取子物体上的Animator组件
        rb = GetComponent<Rigidbody2D>();  // 获取Rigidbody2D组件
        stateMachine.Initailize(idleState);
    }

     private void Update()
    {
        stateMachine.currentState.Update();
         CheckForDashInput();
        
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);                 // 在移动脚本中存入x速度，调用翻转函数，根据x速度判断是否需要翻转
    }

    public bool IsGroundedDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance,whatIsGround);

    public bool IsWalledDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance * facingDir, wallCheck.position.y));
    }
     
    public void Flip()
    {
        facingDir = (-1) * facingDir;  // 改变朝向
        facingRight = !facingRight;  // 更新朝向状态
        this.transform.Rotate(0, 180, 0);
    }
    
    public void FlipController( float _x )    // x可以是刚体速度，也可以是xInput
    {
           if( _x > 0 && !facingRight || _x < 0 && facingRight)
            Flip();
    }   

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();
    public void CheckForDashInput()
    {
        if (IsWalledDetected())
            return;

        dashUsageTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashUsageTimer < 0)
        {
            dashUsageTimer = dashCooldown;
            dashDir = Input.GetAxisRaw("Horizontal");

            if(dashDir == 0)
            {
                dashDir = facingDir;
            }

            stateMachine.ChangeState(dashState);
        }
    }
}

