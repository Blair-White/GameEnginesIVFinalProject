using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonController : MonoBehaviour
{
    public GameObject ModelObject, player, poisoneffect;
    public bool ishit, isPoisoned;
    public Animator animator;
    public float moveSpeed, health;
    private float poisonTick;
    public NavMeshAgent agent;
    public Collider mcollider;
    public float myExpValue;
    
    public enum States
    {
       EnterIdle, Idle, EnterChasing, Chasing, EnterFighting, Fighting, EnterDamaged, Damaged, EnterDying, Dying, EnterDead, Dead
    }
    public States State;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        State = States.EnterIdle;
        animator = ModelObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isPoisoned) { poisonTick += Time.deltaTime; if (poisonTick > 3) {GotHit(10); poisonTick = 0; Instantiate(poisoneffect, this.transform); } }

        switch (State)
        {
            case States.EnterIdle:
                animator.SetBool("isIdle", true);
                animator.SetBool("isHit", false);
                ishit = false;
                State = States.Idle;
                break;
            case States.Idle:
                if(Vector3.Distance(transform.position, player.transform.position) < 15.0f)
                { State = States.EnterChasing; }

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
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, 5.0f);
                
                break;
            case States.Damaged:
                break;
            case States.Dying:
                break;
            case States.EnterDead:
                if (isPoisoned) isPoisoned = false;
                mcollider.enabled = false;
                animator.SetBool("isFighting", false);
                animator.SetBool("isIdle", false);
                animator.SetBool("isChasing", false);
                animator.SetBool("isHit", false);
                animator.SetBool("isDead", true);
                State = States.Dead;
                player.SendMessage("GrantExp", myExpValue);
                agent.isStopped = true;
                break;
            case States.Dead:
               
                break;
            default:
                break;
        }
    }

    public void hitFinished() 
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 4.5f)
        { State = States.EnterFighting; animator.SetBool("isFighting", true); }
        else
        {
            State = States.EnterIdle;
            
        }
        animator.SetBool("isHit", false);
    }
    void GotHit(int Damage)
    {
        health -= Damage;
        if (State == States.Dead) {   return; }
        if (health <= 0) { State = States.EnterDead; if (isPoisoned) isPoisoned = false; }
        ishit = true;
        animator.SetBool("isHit", true);
        animator.SetBool("isFighting", false);
        animator.SetBool("isIdle", false);
        animator.SetBool("isChasing", false);
      
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "PlayerWeapon")
        {
            player.SendMessage("SkeleHit", this.gameObject);
        }
    }

    private void Poisoned() { isPoisoned = true; }
}
