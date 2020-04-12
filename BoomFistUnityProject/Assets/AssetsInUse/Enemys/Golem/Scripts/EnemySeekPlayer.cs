using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySeekPlayer : MonoBehaviour
{
    public float PlayerDetectionDistance;
    public float GolemStandingRotationSpeed;

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private Transform myTransform;

    private float attackCoolDownAmount = 1f;
    private float attackCoolDown;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        myTransform = this.transform;
        animator = this.GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        if (IsAttacking())
            return;

        DepleteAttackCoolDown();

        float distance = Vector3.Distance(myTransform.position, PlayerSingleton.PlayerPosition);
        if (distance < PlayerDetectionDistance)
        {
            navMeshAgent.SetDestination(PlayerSingleton.PlayerPosition);
        } 
        else
        {
            navMeshAgent.SetDestination(myTransform.position);
        }

        if (navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);

            if (distance < PlayerDetectionDistance)
            {
                if (FacingTarget(PlayerSingleton.PlayerPosition) == false)
                {
                    FaceTarget(PlayerSingleton.PlayerPosition);
                }
                else
                {
                    AttackIfReady();
                }
            }
        }
    }

    private void DepleteAttackCoolDown()
    {
        if (attackCoolDown > 0)
            attackCoolDown -= Time.deltaTime;
    }

    private void AttackIfReady()
    {
        //&& animator.GetAnimatorTransitionInfo(0).
        //print(attackCoolDown);
        //print(animator.GetBool("Attack"));
        if (animator.GetBool("Attack") == false && IsAttacking() == false && attackCoolDown <= 0)
        {
            animator.SetTrigger("Attack");
            attackCoolDown = attackCoolDownAmount;
        }
    }

    private bool IsAttacking()
    {
        return animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Attack02";
    }

    private void FaceTarget(Vector3 target)
    {
        Vector3 lookPos = target - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, GolemStandingRotationSpeed);
    }

    private bool FacingTarget(Vector3 target)
    {
        Vector3 lookPos = target - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        return Quaternion.Angle(myTransform.rotation, rotation) < 5;
    }
}
