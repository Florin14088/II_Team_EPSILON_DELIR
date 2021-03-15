using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class F_Scene_Switch_Trigger : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") SceneManager.LoadScene(sceneName);
    }

}
