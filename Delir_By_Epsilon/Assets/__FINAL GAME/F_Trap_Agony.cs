using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_Trap_Agony : MonoBehaviour
{
    public float rangeTrap;
    [ReadOnly] public List<GameObject> trappedObjects;
    [ReadOnly] public float dist;




    private void Update()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, rangeTrap);



        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.GetComponent<F_AI_Addition>())
            {
                nearbyObject.GetComponent<F_AI_Addition>().b_STATIC_PAIN = true;

                if(trappedObjects.Contains(nearbyObject.gameObject) == false)
                {
                    trappedObjects.Add(nearbyObject.gameObject);
                }

            }

        }


       // CheckDistance();

    }//Update


    private void CheckDistance()
    {
        foreach (GameObject g in trappedObjects)
        {
            dist = Vector3.Distance(g.transform.position, gameObject.transform.position);
            if(dist > rangeTrap)
            {
                g.GetComponent<F_AI_Addition>().b_STATIC_PAIN = false;
                trappedObjects.Remove(g);
            }
        
        }

    }//CheckDistance


}
