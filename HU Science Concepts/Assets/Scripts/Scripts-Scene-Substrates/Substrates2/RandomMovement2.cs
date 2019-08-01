using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  RandomMovement2: MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    public float timerForNewPath;   // You probably want this to be greater than 0 so the molecules don't just shake in place 
    private bool inCoroutine;
    public float randSpeed;

    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMeshAgent.speed = randSpeed;
    }

    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-40, 40);
        float z = Random.Range(-40, 40);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }
  
    IEnumerator doSomething()
    {
        inCoroutine = true;
        yield return new WaitForSeconds(timerForNewPath);
        GetNewPath();
        inCoroutine = false;
    }

    void GetNewPath()
    {
        navMeshAgent.SetDestination(getNewRandomPosition());
    }
    
    void Update()
    {
        if (!inCoroutine && (Reaction2.stopMoving==false))
        {
            StartCoroutine(doSomething());
        }
    }
}

