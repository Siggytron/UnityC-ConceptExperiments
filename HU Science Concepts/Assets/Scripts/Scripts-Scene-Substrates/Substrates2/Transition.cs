using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject transitionOb;
    public static GameObject transitionClone;
    public float waitTime;
    Transform transTransform;
    bool shouldInstantiate = true;
    public static bool startProducts = false;

    void Start()
    {
        transTransform = transitionOb.transform;
    }

    void Update()
    {
        if (Reaction2.isReaction == true)
        {
            if (shouldInstantiate == true)
            {
                Invoke("CreateTransition", waitTime);
            }
        }
    }
    public void CreateTransition()
    {
        transitionClone = Instantiate(transitionOb, Reaction2.colliderPos, transTransform.rotation);
        Reaction2.parentSubA.SetActive(false);
        Reaction2.parentSubB.SetActive(false);
        shouldInstantiate = false;
        startProducts = true;
        Reaction2.isReaction = false;
    }
}
