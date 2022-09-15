using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimManager : MonoBehaviour
{
    public Animator animator;

    private string currentStatusState = "Alive";
    private string currentMovementState;
    private string currentMovementStanceState;
    private string currentWarriorAttackState;

    private bool isAttacking = false;

    void OnEnable()
    {
        EventManager.StartListening("statusStateChange", OnStatusStateChange);
        EventManager.StartListening("movementStateChange", OnMovementStateChange);
        EventManager.StartListening("movementStanceStateChange", OnMovementStanceStateChange);
        EventManager.StartListening("warriorAttackStateChange", OnWarriorAttackStateChange);
        EventManager.StartListening("playerAttacking", OnPlayerAttacking);
    }

    void OnDisable()
    {
        EventManager.StopListening("statusStateChange", OnStatusStateChange);
        EventManager.StopListening("movementStateChange", OnMovementStateChange);
        EventManager.StopListening("movementStanceStateChange", OnMovementStanceStateChange);
        EventManager.StopListening("warriorAttackStateChange", OnWarriorAttackStateChange);
        EventManager.StopListening("playerAttacking", OnPlayerAttacking);
    }

    void Update()
    {
        if (currentStatusState == "Alive")
        {
            if (isAttacking)
            {
                if (currentWarriorAttackState == "ComboA_1")
                {
                    animator.Play("Base Layer.Attack");
                    EventManager.TriggerEvent("attackAnimStart", null);
                }
                if (isAnimFinished(animator, 0))
                {
                    EventManager.TriggerEvent("attackAnimEnd", null);
                }
            }
            else
            {
                if (currentMovementState == "Idle")
                {
                    animator.Play("Base Layer.Idle");
                }
                if (currentMovementState == "Moving" || currentMovementState == "Running" && !isAnyAnimPlaying(animator, 0))
                {
                    animator.Play("Base Layer.Run");
                }
                if (currentMovementState == "Jumping" && !isAnimPlaying(animator, "Jump", 0))
                {
                    animator.Play("Base Layer.Jump");
                }
            }
        }
    }

    bool isAnyAnimPlaying(Animator anim, int animLayer)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
        {
            return true;
        }
        else return false;
    }

    bool isAnimFinished(Animator anim, int animLayer)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime >= 1.0f)
        {
            return true;
        }
        else return false;
    }

    bool isAnimPlaying(Animator anim, string stateName, int animLayer)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }

    void OnStatusStateChange(Dictionary<string, object> message)
    {
        currentStatusState = (string)message["statusState"];
    }

    void OnMovementStateChange(Dictionary<string, object> message)
    {
        currentMovementState = (string)message["movementState"];
    }

    void OnMovementStanceStateChange(Dictionary<string, object> message)
    {
        currentMovementStanceState = (string)message["movementStanceState"];
    }

    void OnWarriorAttackStateChange(Dictionary<string, object> message)
    {
        currentWarriorAttackState = (string)message["warriorAttackState"];
    }

    void OnPlayerAttacking(Dictionary<string, object> message)
    {
        isAttacking = (bool)message["isAttacking"];
    }
}
