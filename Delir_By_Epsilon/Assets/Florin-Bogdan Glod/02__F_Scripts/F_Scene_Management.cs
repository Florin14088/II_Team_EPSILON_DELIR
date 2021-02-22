using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class F_Scene_Management : MonoBehaviour
{
    public string sceneToLoad_UP;
    public string sceneToLoad_DOWN;
    [HideInInspector] public bool b_loadIt = false;
    public bool b_canLoadUp = false;
    public bool b_canLoadDown = false;
    public GameObject panelInfo;


    void Start()
    {



    }


    void Update()
    {
        

        if (b_loadIt)
        {
            if (Input.GetKeyDown(KeyCode.K) && b_canLoadDown)
            {
                SceneManager.LoadScene(sceneToLoad_DOWN);
            }

            if (Input.GetKeyDown(KeyCode.O) && b_canLoadUp)
            {
                SceneManager.LoadScene(sceneToLoad_UP);
            }

        }



    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("Intra");
            b_loadIt = true;
            panelInfo.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("Iese");
            b_loadIt = false;
            panelInfo.SetActive(false);
        }
    }


}
