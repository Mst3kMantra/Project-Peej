using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAttackSM : StateMachine
{
    [HideInInspector] public Neutral neutralState;
    [HideInInspector] public ComboA_1 comboA_1State;

    public PlayerSMBlackboard blackboard;
    public new Rigidbody2D rigidbody;
    public Animator animator;

    private void Awake()
    {
        neutralState = new Neutral(this);
        comboA_1State = new ComboA_1(this);
    }

    protected override BaseState GetInitialState()
    {
        return neutralState;
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 80, 200, 60));
        GUILayout.BeginHorizontal();
        string content = GetCurrentState() ?? "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }
}
