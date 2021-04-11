using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is the manager that acts as a middle-man whenever player wants to swith a scene. Triggers placed at certain doors (with their own script) are making the corresponding bools from below true
/// </summary>
public class F_Scenes_Elevator_Manager : MonoBehaviour
{
    public GameObject player;//that's the player. This is the moved object
    [Space]
    public GameObject unu_floor_G_Haunted;//this one is enabled
    public GameObject doi_floor_G_Playable;//this one starts disabled. it's another scene
    public GameObject trei_floor_2nd_Term2;//this one starts disabled. it's another scene
    [Space]
    public bool b_do_trans_1_2 = false;//if this is true, teleport player from "unu_floor_G_Haunted" to "doi_floor_G_Playable"
    public bool b_do_trans_2_1 = false;//if this is true, teleport player from "doi_floor_G_Playable" to "unu_floor_G_Haunted"
    public GameObject destination_from_unu_to_doi;//if coming from floor unu and going to floor doi, spawn here
    public GameObject destination_from_doi_to_unu;//if coming from floor doi and going to floor unu, spawn here
    //public GameObject trans_1_to_2;
    //public GameObject trans_2_to_1;
    [Space]
    public bool b_do_trans_2_3 = false;//if this is true, teleport player from "doi_floor_G_Playable" to "trei_floor_2nd_Term2"
    public bool b_do_trans_3_2 = false;//if this is true, teleport player from "trei_floor_2nd_Term2" to "doi_floor_G_Playable"
    public GameObject destination_from_doi_to_trei;//if coming from floor doi and going to floor trei, spawn here
    public GameObject destination_from_trei_to_doi;//if coming from floor trei and going to floor doi, spawn here
    //public GameObject trans_2_to_3;
    //public GameObject trans_3_to_2;



    void Start()
    {
        doi_floor_G_Playable.SetActive(false);
        trei_floor_2nd_Term2.SetActive(false);

    }//Start



    void Update()
    {
        //each IF below has the same instructions, but with differite variables. Only the first IF will be commented, the others are similar

        if (b_do_trans_1_2)//do transitin from scene 1 to scene 2//____________________________________________________________________
        {
            b_do_trans_1_2 = false;//make sure we do this only once per use

            doi_floor_G_Playable.SetActive(true);//make destination active and enabled
            unu_floor_G_Haunted.SetActive(false);//make origin inactive and disabled

            player.transform.position = destination_from_unu_to_doi.transform.position;//teleport player from source to destination
        }//____________________________________________________________________________________________________________________________


        if (b_do_trans_2_1)//__________________________________________________________________________________________________________
        {
            b_do_trans_2_1 = false;

            unu_floor_G_Haunted.SetActive(true);
            doi_floor_G_Playable.SetActive(false);

            player.transform.position = destination_from_doi_to_unu.transform.position;
        }//____________________________________________________________________________________________________________________________


        if (b_do_trans_2_3)//__________________________________________________________________________________________________________
        {
            b_do_trans_2_3 = false;

            trei_floor_2nd_Term2.SetActive(true);
            doi_floor_G_Playable.SetActive(false);

            player.transform.position = destination_from_doi_to_trei.transform.position;
        }//____________________________________________________________________________________________________________________________


        if (b_do_trans_3_2)//__________________________________________________________________________________________________________
        {
            b_do_trans_3_2 = false;

            doi_floor_G_Playable.SetActive(true);
            trei_floor_2nd_Term2.SetActive(false);

            player.transform.position = destination_from_trei_to_doi.transform.position;
        }//____________________________________________________________________________________________________________________________


    }//Update


}//END