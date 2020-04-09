using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySeekPlayer : MonoBehaviour
{
    public float PlayerDetectionDistance;
    public float HowCloseToGetToPlayer;

    private NavMeshAgent navMeshAgent;
    private Transform myTransform; 

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        myTransform = this.transform;
        print(navMeshAgent.destination);
        navMeshAgent.SetDestination(PlayerSingleton.S.PlayerTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //float distance = Vector3.Distance(myTransform.position, PlayerSingleton.S.PlayerTransform.position);
        //if (distance  < PlayerDetectionDistance)
        //{
        //    navMeshAgent.SetDestination(PlayerSingleton.S.PlayerTransform.position);
        //}

        //else
        //{
        //    navMeshAgent.isStopped = true;
        //}
    }
}
