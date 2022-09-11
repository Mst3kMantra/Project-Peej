using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : BaseState
{
    private MovementSM _sm;
    private float _horizontalInput;
    private bool isFacingRight = true;

    public Moving(MovementSM stateMachine) : base("Moving", stateMachine) {
        _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
        _sm.spriteRenderer.color = Color.red;
        _sm.blackboard.currentMovementState = _sm.GetCurrentState();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
        {
            stateMachine.ChangeState(_sm.idleState);
        }
        if (Input.GetButtonDown("Jump") && _sm.blackboard.currentMovementStanceState == "Grounded")
        {
            stateMachine.ChangeState(_sm.jumpingState);
        }

        Flip();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 vel = _sm.rigidbody.velocity;
        vel.x = _horizontalInput * (_sm.speed);
        _sm.rigidbody.velocity = vel;
    }

    private void Flip()
    {
        if (isFacingRight && _horizontalInput < 0f || !isFacingRight && _horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            if (!isFacingRight)
            {
                _sm.spriteRenderer.flipX = true;
            }
            else _sm.spriteRenderer.flipX = false;
            EventManager.TriggerEvent("changeFacing", new Dictionary<string, object> { { "isFacingRight", isFacingRight } });
        }
    }
}
