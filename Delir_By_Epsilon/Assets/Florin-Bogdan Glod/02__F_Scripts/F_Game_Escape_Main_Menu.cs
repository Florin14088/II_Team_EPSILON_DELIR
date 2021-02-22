using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class F_Game_Escape_Main_Menu : MonoBehaviour
{
    public string sceneToLoad;


    void Start()
    {



    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(sceneToLoad);
        }



    }





}
