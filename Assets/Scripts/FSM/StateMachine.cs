using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    BaseState currentState;
    BaseState previousState;

    private void Start()
    {
        currentState = GetInitialState();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateLogic();
        }
    }

    void LateUpdate()
    {
        if (currentState != null)
        {
            currentState.UpdatePhysics();
        }
    }

    public void ChangeState(BaseState newState)
    {
        if (currentState != null)
        {
            previousState = currentState;
        }
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    public void RevertState()
    {
        if (previousState != null)
        {
            currentState.Exit();

            currentState = previousState;
            currentState.Enter();
        }
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    public string GetCurrentState()
    {
        return currentState.name;
    }

    public string GetPreviousState()
    {
        return previousState.name;
    }

    private void OnGUI()
    {
        string content = currentState != null ? currentState.name : "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
    }
}
