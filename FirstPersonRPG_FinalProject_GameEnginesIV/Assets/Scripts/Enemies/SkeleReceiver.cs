using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeleReceiver : MonoBehaviour
{
    public GameObject mParent;
    void SkeleAttacked()
    {
        GameObject mplayer = GameObject.Find("Player");
        mplayer.SendMessage("SkeleAttacked");
    }
    void hitFinished()
    {
        mParent.SendMessage("hitFinished");
    }
}
