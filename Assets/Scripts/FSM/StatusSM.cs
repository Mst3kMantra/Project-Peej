using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusSM : StateMachine
{
    [HideInInspector] public Alive aliveState;
    [HideInInspector] public Dead deadState;

    public PlayerSMBlackboard blackboard;

    private void Awake()
    {
        aliveState = new Alive(this);
        deadState = new Dead(this);
    }

    protected override BaseState GetInitialState()
    {
        return aliveState;
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
