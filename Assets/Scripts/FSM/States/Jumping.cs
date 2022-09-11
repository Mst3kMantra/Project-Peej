using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : BaseState
{
    private MovementSM _sm;
    private float _horizontalInput;
    private bool isFacingRight;

    public Jumping(MovementSM stateMachine) : base ("Jumping", stateMachine)
    {
        _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _sm.spriteRenderer.color = Color.green;
        _sm.rigidbody.velocity = new Vector2(_sm.rigidbody.velocity.x, _sm.jumpingPower);
        Debug.Log("Current State is " + _sm.blackboard.currentMovementState);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonUp("Jump") && _sm.rigidbody.velocity.y > 0f)
        {
            _sm.rigidbody.velocity = new Vector2(_sm.rigidbody.velocity.x, _sm.rigidbody.velocity.y * 0.5f);
        }
        if (_sm.blackboard.currentMovementStanceState == "Grounded")
        {
            stateMachine.RevertState();
        }

        Flip();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        _sm.rigidbody.velocity = new Vector2(_horizontalInput * _sm.speed, _sm.rigidbody.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
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
        }
    }
}
