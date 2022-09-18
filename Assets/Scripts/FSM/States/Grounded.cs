using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : BaseState
{
    private readonly MovementStanceSM _sm;

    public Grounded(MovementStanceSM stateMachine) : base("Grounded", stateMachine) {
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
        if (Mathf.Abs(_sm.Rigidbody.velocity.y) > Mathf.Epsilon)
        {
            _sm.ChangeState(_sm.AirborneState);
        }
        if (!IsGrounded())
        {
            _sm.ChangeState(_sm.AirborneState);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_sm.GroundCheck.position, 0.2f, _sm.GroundLayer);
    }
}
