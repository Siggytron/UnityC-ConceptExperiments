using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    public float timerForNewPath;
    private bool inCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-20, 20);
        float y = Random.Range(-20, 20);

        Vector3 pos = new Vector3(x, y, 0);
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
