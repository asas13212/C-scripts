using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 所有状态的父类，包含了状态机和玩家的引用，以及一个动画参数的名字
public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    private string animBoolName;
    protected float xInput; // the input from the player, used for movement
    protected float yInput;
    protected Rigidbody2D rb;
    protected bool triggerCalled;

    protected float stateTimer;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);  // 进入状态时设置动画参数为true
        rb = player.rb;  // 获取玩家的Rigidbody2D组件
        triggerCalled = false;  // 重置触发器调用状态
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);  // 退出状态时设置动画参数为false
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;  // 更新状态计时器

        xInput = Input.GetAxisRaw("Horizontal");  // 获取水平输入
        yInput = Input.GetAxisRaw("Vertical");
        player.anim.SetFloat("yVelocity", rb.velocity.y);  // 设置动画参数yVelocity为当前的垂直速度

        

    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;  // 当动画完成时调用，设置触发器调用状态为true
    }
}
