using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = player.dashDuration;
    }

    public override void Exit()
    {
        base.Exit();

        player.SetVelocity(0, rb.velocity.y);  // 停止水平移动，保持垂直速度不变
    }

    public override void Update()
    {
        base.Update();

        if (!player.IsGroundedDetected() && player.IsWalledDetected())
            stateMachine.ChangeState(player.wallSlideState);

        player.SetVelocity(player.facingDir * player.dashSpeed,0);  

        if (stateTimer < 0)
            stateMachine.ChangeState(player.idleState);

    }
}
