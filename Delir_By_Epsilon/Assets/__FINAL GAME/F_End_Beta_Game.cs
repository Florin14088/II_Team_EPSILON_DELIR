using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class F_End_Beta_Game : MonoBehaviour
{
    public float countdownEndGame = 7f;
    public string sceneMainMenu = "MainMenu";
    public Electricity __script_Electricity;
    public GameObject finalGoal;

    private bool b_onceOnly = false;


    void Start()
    {
        
    }


    void Update()
    {
        if (__script_Electricity.isPoweredOn)
        {
            countdownEndGame -= Time.deltaTime;
        }

        if(countdownEndGame <= 0 && b_onceOnly == false)
        {
            b_onceOnly = true;
            finalGoal.SetActive(true);
            finalGoal.GetComponent<Collider>().enabled = true;
            SceneManager.LoadScene(sceneMainMenu);
        }

    }


}
