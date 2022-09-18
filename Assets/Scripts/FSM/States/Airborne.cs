using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airborne : BaseState
{
    private readonly MovementStanceSM _sm;

    public Airborne(MovementStanceSM stateMachine) : base ("Airborne", stateMachine)
    {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _sm.Blackboard.CurrentMovementStanceState = _sm.GetCurrentState();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (IsGrounded() && Mathf.Abs(_sm.Rigidbody.velocity.y) < Mathf.Epsilon)
        {
            StateMachine.ChangeState(_sm.GroundedState);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_sm.GroundCheck.position, 0.2f, _sm.GroundLayer);
    }

}
