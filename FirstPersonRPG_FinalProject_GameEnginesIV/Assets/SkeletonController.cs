using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    public GameObject ModelObject, player;
    private Animator animator;
    public float moveSpeed;
    public enum States
    {
        Idle, Chasing, Fighting, Damaged, Dying, Dead
    }
    public States State;
    // Start is called before the first frame update
    void Start()
    {
        State = States.Idle;
        animator = ModelObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case States.Idle:
                if(Vector3.Distance(transform.position, player.transform.position) < 10.0f)
                { Debug.Log("Player in Range"); State = States.Chasing; }

                break;
            case States.Chasing:
                break;
            case States.Fighting:
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
}
