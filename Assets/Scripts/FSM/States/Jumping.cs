using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : BaseState, IFlip
{
    private readonly MovementSM _sm;
    private float _horizontalInput;
    private bool _isFacingRight;

    public Jumping(MovementSM stateMachine) : base ("Jumping", stateMachine)
    {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _sm.SpriteRenderer.color = Color.green;
        _sm.Rigidbody.velocity = new Vector2(_sm.Rigidbody.velocity.x, _sm.JumpingPower);
        _sm.Blackboard.CurrentMovementState = _sm.GetCurrentState();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonUp("Jump") && _sm.Rigidbody.velocity.y > 0f)
        {
            _sm.Rigidbody.velocity = new Vector2(_sm.Rigidbody.velocity.x, _sm.Rigidbody.velocity.y * 0.5f);
        }
        if (_sm.Blackboard.CurrentMovementStanceState == "Grounded")
        {
            StateMachine.RevertState();
        }

        Flip();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        if (_sm.GetPreviousState() == "Running")
        {
            _sm.Rigidbody.velocity = new Vector2(_horizontalInput * _sm.RunSpeed, _sm.Rigidbody.velocity.y);
        }
        else _sm.Rigidbody.velocity = new Vector2(_horizontalInput * _sm.Speed, _sm.Rigidbody.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public void Flip()
    {
        if (_isFacingRight && _horizontalInput < 0f || !_isFacingRight && _horizontalInput > 0f)
        {
            _isFacingRight = !_isFacingRight;
            if (!_isFacingRight)
            {
                _sm.SpriteRenderer.flipX = true;
            }
            else _sm.SpriteRenderer.flipX = false;
            _sm.Blackboard.IsFacingRight = _isFacingRight;
        }
    }
}
