using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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
        if(Input.GetKeyDown(KeyCode.Mouse0))
            stateMachine.ChangeState(player.primaryAttack);

        if (Input.GetKeyDown(KeyCode.Space) && player.IsGroundedDetected())  // 如果按下空格键，切换到跳跃状态
            stateMachine.ChangeState(player.jumpState);

        if (!player.IsGroundedDetected() && player.rb.velocity.y < 0)
            stateMachine.ChangeState(player.airState);
    }
}
    // Start is called before the first frame update
   

