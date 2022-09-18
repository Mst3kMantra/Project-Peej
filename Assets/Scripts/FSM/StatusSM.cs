using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusSM : StateMachine
{
    private Alive _aliveState;
    [HideInInspector] public Alive AliveState
    {
        get { return _aliveState; }
        set { _aliveState = value; }
    }
    private Dead _deadState;
    [HideInInspector] public Dead DeadState
    {
        set { _deadState = value; }
        get { return _deadState; }
    }

    [SerializeField] private PlayerSMBlackboard _blackboard;
    public PlayerSMBlackboard Blackboard
    {
        get { return _blackboard; }
        set { _blackboard = value; }
    }

    private void Awake()
    {
        AliveState = new Alive(this);
        DeadState = new Dead(this);
    }

    protected override BaseState GetInitialState()
    {
        return AliveState;
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
