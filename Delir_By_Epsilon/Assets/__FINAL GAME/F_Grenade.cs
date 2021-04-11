using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class F_Grenade : MonoBehaviour
{
    //public float delay = 3f;
    //[ReadOnly] public float countdown;
    [ReadOnly] public bool b_activated = false;
    [Space]
    public GameObject explosionEffect;
    //public float explosionRadius = 5f;
    //public float explosionForce = 700f;





    void Start()
    {
        //countdown = delay;



    }//Start





    void Update()
    {
        //countdown -= Time.deltaTime;



        //if (countdown <= 0f && b_activated == false)
        //{
        //    b_activated = true;
        //    countdown = 0;
        //    Explode();
        //}
        if(b_activated) Explode();

    }//Update




    void Explode()
    {
        Instantiate(explosionEffect, gameObject.transform.position, gameObject.transform.rotation);



        //Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);



        //foreach (Collider nearbyObject in colliders)
        //{
        //    Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
        //    if (rb != null)
        //    {
        //        rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        //    }
        //}



        Destroy(gameObject);



    }//Explode


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
              b_activated = true;

        }
    }


}//END