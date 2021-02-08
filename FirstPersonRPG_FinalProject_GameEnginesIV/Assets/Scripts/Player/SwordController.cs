using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public Animator animator;
    private bool isAttacking, checkHit;
    private float delayAttack;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("PressedAttack", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttacking)
        {
            delayAttack += Time.deltaTime;
            if (delayAttack > 1.5) { isAttacking = false; delayAttack = 0; }

        }
        if(!isAttacking)
        if(InputManager.Instance.PressedMouse0())
        {
            isAttacking = true;
            animator.SetBool("PressedAttack", true);
        }
    }

    public void AttackFinished()
    {
        animator.SetBool("PressedAttack", false);
    }
    public void AttackHit()
    {
        checkHit = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(checkHit)
        {
            if(collision.gameObject.tag == "EnemyAttackable")
            {
                collision.gameObject.SendMessage("GotHit", 10, SendMessageOptions.RequireReceiver);
            }
        }
    }
}

