using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCntllr2 : MonoBehaviour
{
    public GameObject colliderA;
    public GameObject colliderB;
    bool isAfter;
    public static bool first;

    void Start()
    {
        first = true;
    }

    // Update is called once per frame
    void Update()
    {
        isAfter = Reaction2.isAfter;

        if (isAfter && (first == true))
        {
            print("isAfter ="+isAfter);
            colliderA.SetActive(false);
            colliderB.SetActive(false);
            first = false;
        }
    }
}
