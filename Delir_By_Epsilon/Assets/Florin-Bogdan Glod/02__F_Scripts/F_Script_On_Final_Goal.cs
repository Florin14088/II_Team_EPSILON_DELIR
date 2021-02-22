using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class F_Script_On_Final_Goal : MonoBehaviour
{

    public string sceneToLoad;
    [HideInInspector] public bool b_loadIt = false;
    public GameObject panelInfo;




    void Start()
    {

        panelInfo.SetActive(false);
    }



    void Update()
    {
        if (b_loadIt)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            b_loadIt = true;
            panelInfo.SetActive(true);
        }
    }

}
