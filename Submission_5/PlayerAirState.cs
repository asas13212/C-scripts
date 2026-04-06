using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        if(player.IsWalledDetected())
            stateMachine.ChangeState(player.wallSlideState);  // ÇÐ»»µ½Ç½Ãæ»¬ÐÐ×´Ì¬

        if ( player.IsGroundedDetected() )
            stateMachine.ChangeState(player.idleState);  // ÇÐ»»µ½¿ÕÖÐ×´Ì¬
        
        if(xInput != 0)
            player.SetVelocity(player.moveSpeed * 0.8f * xInput, rb.velocity.y);  // ¿ÕÖÐÒÆ¶¯

        //if (player.IsWalledDetected())
        //    stateMachine.ChangeState(player.wallSlideState);  // ÇÐ»»µ½Ç½Ãæ»¬ÐÐ×´Ì¬

    }
}
