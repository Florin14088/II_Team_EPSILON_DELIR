using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_Replace_Trigger_Enter : MonoBehaviour
{
    public bool b_replace = false;
    public GameObject replaceWithThis;
    [Space]
    public GameObject soundCrack;



    void Start()
    {
        Instantiate(soundCrack, gameObject.transform.position, Quaternion.identity);
    }


    void Update()
    {
        if (b_replace)
        {
            Instantiate(replaceWithThis, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }


    IEnumerator Init()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<Collider>().isTrigger = true;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
    }


}
