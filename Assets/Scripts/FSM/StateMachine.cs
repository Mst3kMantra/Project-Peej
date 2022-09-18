using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    BaseState CurrentState;
    BaseState PreviousState;

    private void Start()
    {
        CurrentState = GetInitialState();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.UpdateLogic();
        }
    }

    void LateUpdate()
    {
        if (CurrentState != null)
        {
            CurrentState.UpdatePhysics();
        }
    }

    public void ChangeState(BaseState newState)
    {
        if (CurrentState != null)
        {
            PreviousState = CurrentState;
        }
        CurrentState.Exit();

        CurrentState = newState;
        CurrentState.Enter();
    }

    public void RevertState()
    {
        if (PreviousState != null)
        {
            CurrentState.Exit();

            CurrentState = PreviousState;
            CurrentState.Enter();
        }
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    public string GetCurrentState()
    {
        return CurrentState.Name;
    }

    public string GetPreviousState()
    {
        return PreviousState.Name;
    }

}
