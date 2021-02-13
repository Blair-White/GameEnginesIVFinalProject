using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGameSceneControl : MonoBehaviour
{
private float cnt;
        private void Update()
    {
        cnt += Time.deltaTime;
        if (cnt > 4.5) SceneManager.LoadScene(0);
    }
}
