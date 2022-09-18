using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAttackSM : StateMachine
{
    private Neutral _neutralState;
    [HideInInspector] public Neutral NeutralState
    {
        get { return _neutralState; }
        set { _neutralState = value; }
    }
    private ComboA_1 _comboA_1State;
    [HideInInspector] public ComboA_1 ComboA_1State
    {
        get { return _comboA_1State; }
        set { _comboA_1State = value; }
    }

    [SerializeField] private PlayerSMBlackboard _blackboard;
    public PlayerSMBlackboard Blackboard
    {
        get { return _blackboard; }
        set { _blackboard = value; }
    }
    [SerializeField] private Rigidbody2D _rigidbody;
    public Rigidbody2D Rigidbody
    {
        get { return _rigidbody; }
        set { _rigidbody = value; }
    }

    private void Awake()
    {
        NeutralState = new Neutral(this);
        ComboA_1State = new ComboA_1(this);
    }

    protected override BaseState GetInitialState()
    {
        return NeutralState;
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
