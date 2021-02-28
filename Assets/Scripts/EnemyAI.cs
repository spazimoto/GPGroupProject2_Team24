using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject eyes;
    float maxFOVAngle = 62;
    float lookRadius = 15f;

    public Transform player;

    public GameObject playerCharacter;
    private PlayerController playerScript;

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = true; //allows for continuous movement when set to false
        GoToNextPoint();

        playerScript = playerCharacter.GetComponent<PlayerController>();

    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return; //gets value if no points have been set up
        }

        agent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length; //chooses next point in array as destination
    }

    void ChasePlayer()
    {
        transform.LookAt(player);
        //Debug.Log("I see you!");
        agent.speed = 25f;

        agent.SetDestination(player.position);//need to figure out how to make it stop following it's patrol path to chase player
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }

        Vector3 fovRadius = eyes.gameObject.transform.forward * lookRadius;

        float distanceToPlayer = Vector3.Distance(player.gameObject.transform.position - eyes.gameObject.transform.position, fovRadius);
        float playerAngle = Vector3.Angle(player.gameObject.transform.position - eyes.gameObject.transform.position, fovRadius);

        if (playerAngle < maxFOVAngle) //enemy sees player within a certain range
        {
            RaycastHit hit;

            if (Physics.Linecast(eyes.transform.position, player.transform.position, out hit))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    ChasePlayer();
                }
            }
            else
            {
                SlowDown();
            }
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            ChasePlayer();
            Debug.Log("Who's there?!");
            playerCharacter.SendMessage("TakeDamage", 1);
            Invoke("SlowDown", 3f);
        }

        if(collision.CompareTag("Restricted Area"))
        {
            GoToNextPoint();
        }

    }

    void SlowDown()
    {
        agent.speed = 20f;
        Debug.Log("Slowing Down...");
    }
}
