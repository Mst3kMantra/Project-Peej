using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airborne : BaseState
{
    private MovementStanceSM _sm;

    public Airborne(MovementStanceSM stateMachine) : base ("Airborne", stateMachine)
    {
        _sm = (MovementStanceSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        EventManager.TriggerEvent("movementStanceStateChange", new Dictionary<string, object> { { "movementStanceState", _sm.GetCurrentState() } });
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (isGrounded() && Mathf.Abs(_sm.rigidbody.velocity.y) < Mathf.Epsilon)
        {
            stateMachine.ChangeState(_sm.groundedState);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(_sm.groundCheck.position, 0.2f, _sm.groundLayer);
    }

}
