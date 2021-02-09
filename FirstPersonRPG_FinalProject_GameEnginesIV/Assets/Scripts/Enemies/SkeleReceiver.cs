using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeleReceiver : MonoBehaviour
{
    void SkeleAttacked()
    {
        GameObject mplayer = GameObject.Find("Player");
        mplayer.SendMessage("SkeleAttacked");
    }
}
