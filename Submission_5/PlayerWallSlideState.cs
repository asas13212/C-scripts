using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.wallJumpState);
            return;
        }

        if (xInput != 0 && player.facingDir != xInput)  // 之所以要玩家输入的方向和当前朝向相反，是因为如果玩家输入的方向和当前朝向相同，说明玩家想要继续贴着墙面滑行，而不是跳离墙面
            stateMachine.ChangeState(player.idleState);  // 如果玩家输入的方向和当前朝向相反，切换到空中状态
        if(yInput < 0)  // 如果玩家按下了向下的输入，说明玩家想要加速下落，增加垂直速度
            rb.velocity = new Vector2(0, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y * .75f);

        if(player.IsGroundedDetected())  // 如果没有检测到墙面，说明玩家已经跳离墙面，切换到空中状态
            stateMachine.ChangeState(player.idleState);
    }
}
