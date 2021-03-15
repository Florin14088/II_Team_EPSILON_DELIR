using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class F_ENDGAME : MonoBehaviour
{
    public string sceneName;
    public GameObject[] interestObjects;


    private void Update()
    {
        if(interestObjects[0] == null && interestObjects[1] == null)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") StartCoroutine(EndMePLS());
    }


    IEnumerator EndMePLS()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(sceneName);
    }

}
