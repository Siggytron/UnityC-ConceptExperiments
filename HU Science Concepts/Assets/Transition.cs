using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject transitionOb;
    bool shouldInstantiate = true;

    // Start is called before the first frame update
    void Start()
    {
        //CreateTransition();
    }

    void Update()
    {
        print("isReaction " + Reaction2.isReaction);
        print("firstCollide" + Reaction2.firstCollide);
        if ((Reaction2.firstCollide == true) && (shouldInstantiate == true))
        {
            CreateTransition();
            shouldInstantiate = false;
        }
    }
    public void CreateTransition()
    {
        Instantiate(transitionOb);
    }
}
