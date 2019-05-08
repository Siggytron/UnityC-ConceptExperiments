using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  randomMovementXY: MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    public float timerForNewPath;
    private bool inCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    Vector2 getNewRandomPosition()
    {
        float x = Random.Range(-40, 40);
        float y = Random.Range(-40, 40);

        Vector2 pos = new Vector3(x, y);
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
    // Update is called once per frame
    void Update()
    {
        if (!inCoroutine)
        {
            StartCoroutine(doSomething());
        }
    }
}

