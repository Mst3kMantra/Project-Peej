using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStanceSM : StateMachine
{
    [HideInInspector] public Grounded groundedState;
    [HideInInspector] public Airborne airborneState;

    public PlayerSMBlackboard blackboard;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public new Rigidbody2D rigidbody;

    private void Awake()
    {
        groundedState = new Grounded(this);
        airborneState = new Airborne(this);
    }

    protected override BaseState GetInitialState()
    {
        return groundedState;
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, 200, 60));
        GUILayout.BeginHorizontal();
        string content = GetCurrentState() != null ? GetCurrentState() : "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }
}
