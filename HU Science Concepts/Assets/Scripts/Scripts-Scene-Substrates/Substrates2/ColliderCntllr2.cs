using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCntllr2 : MonoBehaviour
{
    // Since we're planning on making the chemical reaction reversible
    // some of this logic will change in the future. For now, the reaction
    // just has one direction so there is a boolean 'first' that only
    // switches on time. 


    public GameObject colliderA;
    public GameObject colliderB;
    //public GameObject colliderAafter;
    //public GameObject colliderBafter;
    bool isAfter;
    public static bool first;

    // Start is called before the first frame update
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
            //colliderAafter.SetActive(true);
            //colliderBafter.SetActive(true);
            first = false;
        }
    }
}
