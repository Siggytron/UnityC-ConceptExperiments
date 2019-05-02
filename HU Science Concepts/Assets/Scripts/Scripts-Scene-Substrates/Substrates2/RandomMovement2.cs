using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  RandomMovement2: MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    public float timerForNewPath;
        // You probably want this to be greater than 0 so the molecules don't just shake in place not going anywhere
        // and changing direction before they've moved forward on any particular path
        // but you don't want it to be too high either.
    private bool inCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-40, 40);
        float z = Random.Range(-40, 40);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }
    /*   Have to figure out how to get substrates to stick together and drift upon collision
     *   Then separate and continue random motion after transition is complete.
     *   
    Rigidbody rBody = GetComponent<Rigidbody>();
    void EnableRagdoll()
    {
        rBody.isKinematic = false;
        rBody.detectCollisions = true;
    }
    void DisableRagdoll()
    {
        rBody.isKinematic = true;
        rBody.detectCollisions = false;
    }
    */
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
    // Update is called once per frame
    void Update()
    {
        if (!inCoroutine && (Reaction2.stopMoving==false))
        {
            StartCoroutine(doSomething());
        }
    }
}

