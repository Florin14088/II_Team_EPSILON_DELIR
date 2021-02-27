using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class F_TUT_Time_Text : MonoBehaviour
{
    public string interestTag = "Player";
    [Space]
    public bool b_stopTime = true;//true = will stop time on touch    false = will not stop time on touch
    public bool b_useOnce = true;// false = object will not be destroyed after 1 use
    [HideInInspector] public bool b_Player_Triggered = false; //true = player entered trigger
    [Space]
    public string message_UI = "Your UI Message";
    public Text msg_txt;//UI text to show your message_UI
    public GameObject backgroundTXT;//in case your text has a background


    private void Start()
    {
        if (backgroundTXT == null) Debug.Log($"Forgot to add the panel from _GAMEUI / Canvas / UI_Root / Pain UI / Panel_Tutorial Text. The object {gameObject.name} on script F_TUT_Time_Text does not have backgroundTXT component set.");
        if (backgroundTXT) backgroundTXT.SetActive(false);
        msg_txt.text = " ";

    }//Start



    private void Update()
    {
        if(b_Player_Triggered && Keyboard.current.enterKey.wasPressedThisFrame)
        {
            b_Player_Triggered = false;

            if(b_useOnce) Destroy(gameObject);
            if (b_stopTime) Time.timeScale = 1;
            if (b_stopTime) GameObject.FindGameObjectWithTag(interestTag).GetComponent<PlayerController>().enabled = true;
            if (b_stopTime) GameObject.FindGameObjectWithTag(interestTag).GetComponentInChildren<MouseLook_HFPS>().enabled = true;
            msg_txt.text = " ";
            if (backgroundTXT) backgroundTXT.SetActive(false);
        }


    }//Update



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == interestTag)
        {
            b_Player_Triggered = true;
            if (b_stopTime) Time.timeScale = 0;
            if (b_stopTime) GameObject.FindGameObjectWithTag(interestTag).GetComponent<PlayerController>().enabled = false;
            if (b_stopTime) GameObject.FindGameObjectWithTag(interestTag).GetComponentInChildren<MouseLook_HFPS>().enabled = false;
            if (backgroundTXT) backgroundTXT.SetActive(true);
            msg_txt.text = message_UI;

        }


    }//OnTriggerEnter


}//END
