using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_Scenes_Elevator_Helper : MonoBehaviour
{
    [Header("4 is 2nd_Term2 to G_Playable")]
    [Header("3 is G_Playable to 2nd_Term2")]
    [Header("2 is G_Playable to G_Haunted")]
    [Header("1 is G_Haunted to G_Playable")]
    [Header("Slider info:")]
    [Range(1, 4)] public int destination = 1;

    [Space]
    [Space]
    public GameObject canvasFadeObject;


    private F_Scenes_Elevator_Manager __script_Elevator;



    void Start()
    {
        __script_Elevator = FindObjectOfType<F_Scenes_Elevator_Manager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (destination)
            {
                case 1:
                    __script_Elevator.b_do_trans_1_2 = true;
                    canvasFadeObject.GetComponent<Animator>().SetTrigger("PainTrigger");
                    break;

                case 2:
                    __script_Elevator.b_do_trans_2_1 = true;
                    canvasFadeObject.GetComponent<Animator>().SetTrigger("PainTrigger");
                    break;

                case 3:
                    __script_Elevator.b_do_trans_2_3 = true;
                    canvasFadeObject.GetComponent<Animator>().SetTrigger("PainTrigger");
                    break;

                case 4:
                    __script_Elevator.b_do_trans_3_2 = true;
                    canvasFadeObject.GetComponent<Animator>().SetTrigger("PainTrigger");
                    break;

                default:
                    break;
            }
        
        }


    }//OnTriggerEnter



}//END