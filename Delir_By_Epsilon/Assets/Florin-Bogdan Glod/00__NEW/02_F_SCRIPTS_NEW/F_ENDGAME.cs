using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//THIS SCRIPT NO LONGER ENDS THE GAME
public class F_ENDGAME : MonoBehaviour
{
    [Header("THIS SCRIPT NO LONGER ENDS THE GAME")]
    //public string sceneName;
    public GameObject enableObjectiveObject;
    public GameObject[] interestObjects;


    private void Update()
    {
        if (interestObjects[0] == null && interestObjects[1] == null || interestObjects[0].GetComponent<Collider>().enabled == false && interestObjects[1].GetComponent<Collider>().enabled == false)
        {
            //gameObject.GetComponent<BoxCollider>().enabled = true;

            enableObjectiveObject.SetActive(true);
            enableObjectiveObject.GetComponent<Collider>().enabled = true;
        }

        

    }


    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Player") StartCoroutine(EndMePLS());
        //if (other.gameObject.tag == "Player")
        //{
        //    enableObjectiveObject.SetActive(true);
        //    enableObjectiveObject.GetComponent<Collider>().enabled = true;
        //}
    }


    //IEnumerator EndMePLS()
    //{
    //    yield return new WaitForSeconds(5);
    //    SceneManager.LoadScene(sceneName);
    //}

}
