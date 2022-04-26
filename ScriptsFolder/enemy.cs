using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Enemy class
 * 
 * this script gets the enemy to wander around for wanderTimer seconds
 * and then set a new random destination
 * if it is within the radius of the player, it will follow the player
 */

public class enemy : MonoBehaviour
{
    // need to use NavMeshAgent to use A* pathfinding by Unity
    public GameObject player;
    private UnityEngine.AI.NavMeshAgent reaperNav;
    public float wanderRadius;
    public float wanderTimer;
    private float timer;
    private float distance;
    public float followRadius;
 
    // Start is called before the first frame update
    void Start()
    {
        reaperNav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        timer = wanderTimer;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        distance = Vector3.Distance(player.transform.position, reaperNav.transform.position);
        if (distance < followRadius)
        {
            // follow the player
            reaperNav.SetDestination(player.transform.position);
        } else if (timer >= wanderTimer)
            
        {
            // wander around
            Vector3 newPos = RandomNavSphere(reaperNav.transform.position, wanderRadius, -1);
            reaperNav.SetDestination(newPos);
            timer = 0;
        }
    }
    // random position around a point
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        UnityEngine.AI.NavMeshHit navHit;
        UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }
    
    // we can use nav mesh obstable instead of this. It is more accurate and auto handles rigid/not pass through
    private void OnTriggerEnter(Collider other)
    {
        // if hit an obstacle, set a new random destination
        if (other.gameObject.tag == "obstacle")
        {
            Vector3 newPos = RandomNavSphere(reaperNav.transform.position, wanderRadius, -1);
            reaperNav.SetDestination(newPos);
        }
    }
    // this is uncessary
    // follow the player on contact
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.tag == "Player")
    //     {
    //         reaperNav.SetDestination(target.transform.position);
    //     }
    // }
}
