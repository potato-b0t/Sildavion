using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FollowPlayer : MonoBehaviour
{
    private Transform playerMain;
    private Vector3 DefaultRespawn;
    private Animator anim;
    private NavMeshAgent agent;
    [Min(0)]
    public float maxDistance;
    [Min(0)]
    public float minDistance;
    private void Start()
    {
        playerMain = GameObject.Find("PlayerParent").transform;

        anim = transform.Find("Model").GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(playerMain.position, transform.position) <= minDistance)
        {
            agent.SetDestination(transform.position);
            anim.SetBool("Walking", false);
        }
        else if (Vector3.Distance(playerMain.position, transform.position) > minDistance)
        {
            agent.SetDestination(playerMain.position);
            anim.SetBool("Walking", true);

            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(playerMain.position, path);

            if (Vector3.Distance(playerMain.position, transform.position) > maxDistance || path.status == NavMeshPathStatus.PathPartial)
            {
                DefaultRespawn = playerMain.Find("ReSpawnSecondPlayer").position;
                transform.position = DefaultRespawn;
            }
        }

    }
}
