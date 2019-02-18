using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCntllr : MonoBehaviour
{
    public GameObject colliderA;
    public GameObject colliderB;
    public GameObject colliderAafter;
    public GameObject colliderBafter;
    bool isAfter;
    bool first;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isAfter = Reaction.isAfter;
        if (isAfter && (first == true))
        {
            print("isAfter ="+isAfter);
            colliderA.SetActive(false);
            colliderB.SetActive(false);
            colliderAafter.SetActive(true);
            colliderBafter.SetActive(true);
            first = false;
        }
    }
}
