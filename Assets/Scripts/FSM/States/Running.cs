using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : BaseState, IFlip
{
    private readonly MovementSM _sm;
    private float _horizontalInput;
    public bool isFacingRight {get; set;}

    public Running(MovementSM stateMachine) : base("Running", stateMachine) {
        _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
        _sm.spriteRenderer.color = Color.blue;
        EventManager.TriggerEvent("movementStateChange", new Dictionary<string, object> { { "movementState", _sm.GetCurrentState() } });
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (_sm.blackboard.isAttacking)
        {
            _sm.ChangeState(_sm.idleState);
        }
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
        vel.x = _horizontalInput * (_sm.runSpeed);
        _sm.rigidbody.velocity = vel;
    }

    public void Flip()
    {
        if (isFacingRight && _horizontalInput < 0f || !isFacingRight && _horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            if (!isFacingRight)
            {
                _sm.spriteRenderer.flipX = true;
            }
            else _sm.spriteRenderer.flipX = false;
            EventManager.TriggerEvent("facingChange", new Dictionary<string, object>{ { "isFacingRight", isFacingRight} });
        }
    }
}
