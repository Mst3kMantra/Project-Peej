using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementSM : StateMachine
{
    private Idle _idleState;
    [HideInInspector] public Idle IdleState
    {
        get { return _idleState; }
        set { _idleState = value; }
    }
    private Moving _movingState;
    [HideInInspector] public Moving MovingState
    {
        get { return _movingState; }
        set { _movingState = value; }
    }
    private Jumping _jumpingState;
    [HideInInspector] public Jumping JumpingState
    {
        get { return _jumpingState; }
        set { _jumpingState = value; }
    }
    private Running _runningState;
    [HideInInspector] public Running RunningState
    {
        get { return _runningState; }
        set { _runningState = value; }
    }

    [SerializeField] private Rigidbody2D _rigidbody;
    public Rigidbody2D Rigidbody
    {
        get { return _rigidbody; }
        set { _rigidbody = value; }
    }
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public SpriteRenderer SpriteRenderer
    {
        get { return _spriteRenderer;}
        set { _spriteRenderer = value; }
    }
    [SerializeField] private PlayerSMBlackboard _blackboard;
    public PlayerSMBlackboard Blackboard
    {
        get { return _blackboard;}
        set { _blackboard = value; }
    }

    [SerializeField] private float _jumpingPower = 16f;
    public float JumpingPower
    {
        get { return _jumpingPower; }
        set { _jumpingPower = value; }
    }
    [SerializeField] private float _speed = 4f;
    public float Speed
    {
        get { return _speed;}
        set { _speed = value; }
    }
    private float _runSpeed = 8f;
    public float RunSpeed
    {
        get { return _runSpeed;}
        set { _runSpeed = value; }
    }

    private void Awake()
    {
        IdleState = new Idle(this);
        MovingState = new Moving(this);
        JumpingState = new Jumping(this);
        RunningState = new Running(this);
    }


    protected override BaseState GetInitialState()
    {
        return IdleState;
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
