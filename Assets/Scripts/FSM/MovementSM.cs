using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementSM : StateMachine
{
    [HideInInspector] public Idle idleState;
    [HideInInspector] public Moving movingState;
    [HideInInspector] public Jumping jumpingState;
    [HideInInspector] public Running runningState;

    public new Rigidbody2D rigidbody;
    public SpriteRenderer spriteRenderer;
    public PlayerSMBlackboard blackboard;
    public Animator animator;
    public float jumpingPower = 16f;

    public float speed = 4f;
    public float runSpeed = 8f;

    private void Awake()
    {
        idleState = new Idle(this);
        movingState = new Moving(this);
        jumpingState = new Jumping(this);
        runningState = new Running(this);
    }


    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 40, 200, 60));
        GUILayout.BeginHorizontal();
        string content = GetCurrentState() ?? "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }
}
