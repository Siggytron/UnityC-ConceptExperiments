using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject transitionOb;
    //public GameObject prodA;
    //public GameObject prodB;
    //GameObject prodAClone;
    //GameObject prodBClone;
    public static GameObject transitionClone;
    Transform transTransform;
    Vector3 pos;
    bool shouldInstantiate = true;
    public static bool startProducts = false;
    //spublic float waitTimeDestroyTransition;
    Vector3 subAPos;
    Vector3 subBPos;
    public static Vector3 subAdistFrom;
    public static Vector3 subBdistFrom;
    Vector3 currentTransitionPos;
    public static Quaternion subARot;
    public static Quaternion subBRot;


    // Start is called before the first frame update
    void Start()
    {
        transTransform = transitionOb.transform;
        pos = transTransform.position;
    }

    void Update()
    {
        if (Reaction2.isReaction == true)
        {
            if (shouldInstantiate == true)
            {
                CreateTransition();
            }
        }
    }
    public void CreateTransition()
    {
        subAPos = Reaction2.parentSubA.transform.position;
        subBPos = Reaction2.parentSubB.transform.position;
        subAdistFrom = Reaction2.colliderPos - subAPos;
        subBdistFrom = Reaction2.colliderPos - subBPos;
        subARot = Reaction2.parentSubA.transform.rotation;
        print("subA rotation " + subARot);
        subBRot = Reaction2.parentSubB.transform.rotation;

        // vector from colliderPos to parentSubA position

        // vector from colliderPos to parentSubB position


        transitionClone = Instantiate(transitionOb, Reaction2.colliderPos, transform.rotation);
        //Instantiate(transitionOb, Reaction2.colliderPos , transform.rotation);
        Reaction2.parentSubA.SetActive(false);
        Reaction2.parentSubB.SetActive(false);
        shouldInstantiate = false;
        startProducts = true;
    }
    
    /*
    void StartProductCycle()
    {
        // Destroy clone
        Invoke("DestroyTransition", waitTimeDestroyTransition);

    }
    */

    /*
    void DestroyTransition()
    {
        // Get current position of the transition object
        currentTransitionPos = transitionClone.transform.position;

        // Destroy Transition objects
        Destroy(transitionClone);

        /*
         * 
         * Below is the message I got when I was trying to destroy the game object 
         * to which the prefab was attached. Instead I created a game object variable to hold the 
         * instantiated clone and destroyed that instead. That process did not lead to the
         * error message below.
        "Destroying assets is not permitted to avoid data loss.
        If you really want to remove an asset use DestroyImmediate(theObject, true);"
        */

        // Create Products
        //CreateProducts();
        /*
    }
    */
    /*
    void CreateProducts()
    {
        prodAClone = Instantiate(prodA, (currentTransitionPos + subAdistFrom) , subARot);
        prodBClone = Instantiate(prodB, (currentTransitionPos + subBdistFrom) , subBRot);
    }
    */

}
