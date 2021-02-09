using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonController : MonoBehaviour
{
    public GameObject ModelObject, player;
    public Animator animator;
    public float moveSpeed;
    public NavMeshAgent agent;
    public enum States
    {
       EnterIdle, Idle, EnterChasing, Chasing, EnterFighting, Fighting, EnterDamaged, Damaged, EnterDying, Dying, EnterDead, Dead
    }
    public States State;
    // Start is called before the first frame update
    void Start()
    {
        State = States.EnterIdle;
        animator = ModelObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case States.EnterIdle:
                animator.SetBool("isIdle", true);
                State = States.Idle;
                break;
            case States.Idle:
                if(Vector3.Distance(transform.position, player.transform.position) < 15.0f)
                { Debug.Log("Player in Range"); State = States.EnterChasing; }

                break;

            case States.EnterChasing:
                animator.SetBool("isChasing", true);
                animator.SetBool("isIdle", false);
                animator.SetBool("isFighting", false);
                State = States.Chasing;
                break;
            case States.Chasing:
                if (Vector3.Distance(transform.position, player.transform.position) < 4.5f)
                { State = States.EnterFighting; }
                else
                {
                    agent.isStopped = false;
                    agent.SetDestination(player.transform.position);
                }
                    break;
            case States.EnterFighting:
                animator.SetBool("isFighting", true);
                animator.SetBool("isIdle", false);
                animator.SetBool("isChasing", false);
                agent.isStopped = true;
                State = States.Fighting;
                break;
            case States.Fighting:
                if (Vector3.Distance(transform.position, player.transform.position) > 4.5f)
                { State = States.EnterChasing; }
                var lookPos = player.transform.position - transform.position;
                lookPos.y = 0;
                var rot = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * .1f);
                              
                break;
            case States.Damaged:
                break;
            case States.Dying:
                break;
            case States.Dead:
                break;
            default:
                break;
        }
    }

    void GotHit(int Damage)
    {
        Debug.Log("Skeleton Hit");
    }
}
