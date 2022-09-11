using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : BaseState
{
    private MovementStanceSM _sm;

    public Grounded(MovementStanceSM stateMachine) : base("Grounded", stateMachine) {
        _sm = (MovementStanceSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _sm.blackboard.currentMovementStanceState = _sm.GetCurrentState();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (Mathf.Abs(_sm.rigidbody.velocity.y) > Mathf.Epsilon)
        {
            _sm.ChangeState(_sm.airborneState);
        }
        if (!isGrounded())
        {
            _sm.ChangeState(_sm.airborneState);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(_sm.groundCheck.position, 0.2f, _sm.groundLayer);
    }
}
