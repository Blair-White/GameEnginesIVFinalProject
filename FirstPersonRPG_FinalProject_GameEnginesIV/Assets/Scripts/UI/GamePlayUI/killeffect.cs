using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killeffect : MonoBehaviour
{
    float killtime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        killtime += Time.deltaTime;
        if (killtime > 1) Destroy(gameObject);
    }
}
