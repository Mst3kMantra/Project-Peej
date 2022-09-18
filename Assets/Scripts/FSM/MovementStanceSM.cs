using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStanceSM : StateMachine
{
    private Grounded _groundedState;
    [HideInInspector] public Grounded GroundedState
    {
        get { return _groundedState; }
        set { _groundedState = value; }
    }
    private Airborne _airborneState;
    [HideInInspector] public Airborne AirborneState
    {
        get { return _airborneState;}
        set { _airborneState = value; }
    }

    [SerializeField] private PlayerSMBlackboard _blackboard;
    public PlayerSMBlackboard Blackboard
    {
        get { return _blackboard; }
        set { _blackboard = value; }
    }
    [SerializeField] private Transform _groundCheck;
    public Transform GroundCheck
    {
        get { return _groundCheck; }
        set { _groundCheck = value; }
    }
    [SerializeField] private LayerMask _groundLayer;
    public LayerMask GroundLayer
    {
        get { return _groundLayer; }
        set { _groundLayer = value; }
    }
    [SerializeField] private Rigidbody2D _rigidbody;
    public Rigidbody2D Rigidbody
    {
        get { return _rigidbody; }
        set { _rigidbody = value; }
    }

    private void Awake()
    {
        GroundedState = new Grounded(this);
        AirborneState = new Airborne(this);
    }

    protected override BaseState GetInitialState()
    {
        return GroundedState;
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, 200, 60));
        GUILayout.BeginHorizontal();
        string content = GetCurrentState() ?? "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }
}
