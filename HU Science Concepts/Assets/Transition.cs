using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject transitionOb;

    // Start is called before the first frame update
    void Start()
    {
        //CreateTransition();
    }

    public void CreateTransition()
    {
        Instantiate(transitionOb);
    }
}
