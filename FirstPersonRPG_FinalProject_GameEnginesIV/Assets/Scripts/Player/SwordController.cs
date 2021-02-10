using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private GameObject mplayer;
    public Animator animator;
    private bool isAttacking, checkHit;
    public bool isWalking;
    private float delayAttack;
    // Start is called before the first frame update
    void Start()
    {
        mplayer = GameObject.Find("Player");
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
        mplayer.SendMessage("AttackEnded");
    }
    public void AttackHit()
    {
        checkHit = true;
        mplayer.SendMessage("Attacked");
    }

    private void Walking()
    {
        animator.SetBool("isWalking", true);
        isWalking = true;
    }
    private void StoppedWalking()
    {
        animator.SetBool("isWalking", false);
        isWalking = false;
    }
}

