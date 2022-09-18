using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private string CurrentStatusState = "Alive";
    private string CurrentMovementState;
    private string CurrentMovementStanceState;
    private string CurrentWarriorAttackState;

    private bool _isAttacking = false;

    void OnEnable()
    {
        EventManager.StartListening("StatusStateChange", OnStatusStateChange);
        EventManager.StartListening("MovementStateChange", OnMovementStateChange);
        EventManager.StartListening("MovementStanceStateChange", OnMovementStanceStateChange);
        EventManager.StartListening("WarriorAttackStateChange", OnWarriorAttackStateChange);
        EventManager.StartListening("PlayerAttacking", OnPlayerAttacking);
    }

    void OnDisable()
    {
        EventManager.StopListening("StatusStateChange", OnStatusStateChange);
        EventManager.StopListening("MovementStateChange", OnMovementStateChange);
        EventManager.StopListening("MovementStanceStateChange", OnMovementStanceStateChange);
        EventManager.StopListening("WarriorAttackStateChange", OnWarriorAttackStateChange);
        EventManager.StopListening("PlayerAttacking", OnPlayerAttacking);
    }

    void Update()
    {
        if (CurrentStatusState == "Alive")
        {
            if (_isAttacking)
            {
                if (CurrentWarriorAttackState == "ComboA_1")
                {
                    _animator.Play("Base Layer.Attack");
                    EventManager.TriggerEvent("AttackAnimStart", null);
                }
                if (IsAnimFinished(_animator, 0))
                {
                    EventManager.TriggerEvent("AttackAnimEnd", null);
                }
            }
            else
            {
                if (CurrentMovementState == "Idle")
                {
                    _animator.Play("Base Layer.Idle");
                }
                if (CurrentMovementState == "Moving")
                {
                    _animator.Play("Base Layer.Run");
                }
                if (CurrentMovementState == "Running")
                {
                    _animator.Play("Base Layer.Run");
                }
                if (CurrentMovementState == "Jumping")
                {
                    _animator.Play("Base Layer.Jump");
                }
            }
        }
    }

    bool IsAnyAnimPlaying(Animator anim, int animLayer)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
        {
            return true;
        }
        else return false;
    }

    bool IsAnimFinished(Animator anim, int animLayer)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime >= 1.0f)
        {
            return true;
        }
        else return false;
    }

    bool IsAnimPlaying(Animator anim, string stateName, int animLayer)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }

    void OnStatusStateChange(Dictionary<string, object> message)
    {
        CurrentStatusState = (string)message["StatusState"];
    }

    void OnMovementStateChange(Dictionary<string, object> message)
    {
        CurrentMovementState = (string)message["MovementState"];
    }

    void OnMovementStanceStateChange(Dictionary<string, object> message)
    {
        CurrentMovementStanceState = (string)message["MovementStanceState"];
    }

    void OnWarriorAttackStateChange(Dictionary<string, object> message)
    {
        CurrentWarriorAttackState = (string)message["WarriorAttackState"];
    }

    void OnPlayerAttacking(Dictionary<string, object> message)
    {
        _isAttacking = (bool)message["IsAttacking"];
    }
}
