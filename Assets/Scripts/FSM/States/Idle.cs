using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BaseState
{
    readonly MovementSM _sm;
    private float _horizontalInput;

    public Idle(MovementSM stateMachine) : base("Idle", stateMachine)
    {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _sm.transform.localScale = new Vector3(-1, 1, 1);
        _horizontalInput = 0f;
        _sm.SpriteRenderer.color = Color.white;
        Vector2 vel = _sm.Rigidbody.velocity;
        vel.x *= 0.8f;
        _sm.Rigidbody.velocity = vel;
        _sm.Blackboard.CurrentMovementState = _sm.GetCurrentState();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (!_sm.Blackboard.IsAttacking)
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
            {
                StateMachine.ChangeState(_sm.MovingState);
            }
            if (Input.GetButtonDown("Jump") && _sm.Blackboard.CurrentMovementStanceState == "Grounded")
            {
                StateMachine.ChangeState(_sm.JumpingState);
            }
        }
    }
}