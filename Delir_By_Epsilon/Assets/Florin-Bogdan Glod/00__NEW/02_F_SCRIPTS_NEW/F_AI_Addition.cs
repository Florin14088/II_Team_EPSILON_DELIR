using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class F_AI_Addition : MonoBehaviour
{
    [ReadOnly] public int actionTaken = -1; // -1 is not initialized, 0 is idle, 1 is run away, 2 is attack
    [ReadOnly] public bool b_Action_Idle = false;
    [ReadOnly] public bool b_Action_Run_Away = false;
    [ReadOnly] public bool b_Action_Attack = false;
    public bool b_STATIC_PAIN = false;
    [Space]
    //[MinMax(1.5f, 4f)] public Vector2 distance_too_close; //if player gets at this distance and actionTaken is 0, the NPC will take another random action
    public float rangeRunAway = 20;
    [Space]
    public float cooldownAction = 5;//after picking an action, how many seconds before pick another action
    [ReadOnly] public float nextCooldown = 0;
    [Space]
    [Space]


    [ReadOnly, SerializeField] private ZombieBehaviourAI __script_AI;//reference to the AI script from the NPC gameobject
    [ReadOnly, SerializeField] private bool b_firstInit = true;
    [ReadOnly, SerializeField] private bool b_pendingApproval = false;
    private GameObject player;
    private float currDistance = 0;//distance between player and NPC;
    


    void Start()
    {
        __script_AI = gameObject.GetComponent<ZombieBehaviourAI>();
        player = GameObject.FindGameObjectWithTag("Player");

        InvokeRepeating("ResetStatic", 1, 1);
    }//Start



    void Update()
    {
        if (b_STATIC_PAIN)
        {
            __script_AI.enabled = false;
            gameObject.GetComponent<Animator>().SetInteger("Pain", 1);
            return;
        }
        else
        {
            gameObject.GetComponent<Animator>().SetInteger("Pain", 0);
        }

        if (__script_AI.primaryBehaviour == ZombieBehaviourAI.PrimaryBehaviour.Sleep)
        {
            return; //NPC is sleeping, check back later
        }

        if (b_firstInit)
        {
            if (b_pendingApproval == false)
            {
                b_pendingApproval = true;
                StartCoroutine(PainInit());
            }
            return;
        }


        if (__script_AI.primaryBehaviour == ZombieBehaviourAI.PrimaryBehaviour.Chase || __script_AI.primaryBehaviour == ZombieBehaviourAI.PrimaryBehaviour.Attracted)
        {            
            if (Time.time > nextCooldown)
            {
                nextCooldown = Time.time + cooldownAction;
                actionTaken = Random.Range(0, 3);//random between, 0, 1 and 2
            }
        }


        switch (actionTaken)
        {
            case 0://idle
                __script_AI.playerInvisible = true;

                b_Action_Idle = true;
                b_Action_Run_Away = false;
                b_Action_Attack = false;

                actionTaken = 3;

                break;



            case 1://run away
                __script_AI.playerInvisible = true;

                b_Action_Idle = false;
                b_Action_Run_Away = true;
                b_Action_Attack = false;
                
                gameObject.transform.position = RandomNavmeshLocation(rangeRunAway);
                actionTaken = 3;

                break;



            case 2://attack
                __script_AI.playerInvisible = false;

                b_Action_Idle = false;
                b_Action_Run_Away = false;
                b_Action_Attack = true;
                actionTaken = 3;

                break;

            case 3:
                break;


            default:
                break;
        }


    }//Update


    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }


    IEnumerator PainInit()
    {
        yield return new WaitForSeconds(Random.Range(5f, 5.5f)); 
        b_firstInit = false;
    }


    void ResetStatic()
    {
        b_STATIC_PAIN = false;
    }



}//END