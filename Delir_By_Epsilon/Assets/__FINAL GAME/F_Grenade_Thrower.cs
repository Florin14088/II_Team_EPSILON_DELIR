using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class F_Grenade_Thrower : MonoBehaviour
{
    public Key throwGrenadeKey = Key.R;
    public float throwForce = 40f;
    public GameObject grenadePrefab;
    public GameObject spawnPOint;




    void Start()
    {

    }





    void Update()
    {
        if (Keyboard.current[throwGrenadeKey].wasPressedThisFrame)
        {
            ThrowGrenade();
        }

    }




    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, spawnPOint.transform.position, spawnPOint.transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);



    }//ThrowGrenade





}