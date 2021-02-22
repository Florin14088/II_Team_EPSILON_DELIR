using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class F_Prologue_to_Ground_Floor : MonoBehaviour
{
    public string level_GroundFloor;

    void Start()
    {
        StartCoroutine(DelayIt());
    }


    IEnumerator DelayIt()
    {
        yield return new WaitForSecondsRealtime(38);
        SceneManager.LoadScene(level_GroundFloor);

    }



}
