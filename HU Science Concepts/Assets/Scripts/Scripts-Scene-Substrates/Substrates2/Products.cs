using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Products : MonoBehaviour
{
    public GameObject prodA;
    public GameObject prodB;
    GameObject prodAClone;
    GameObject prodBClone;
    //Vector3 subAPos;
    //Vector3 subBPos;
    //Vector3 subAdistFrom;
    //Vector3 subBdistFrom;
    Vector3 currentTransitionPos;
    //Quaternion subARot;
    //Quaternion subBRot;
    public float waitTimeDestroyTransition;
    bool shouldDestroy = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if ((Transition.startProducts == true) && (shouldDestroy == true)) 
        {
            Invoke("StartProductCycle", waitTimeDestroyTransition);
            Transition.startProducts = false;
        }
    }
    void StartProductCycle()
    {
        print("StartProductCycle: Transition.transitionClone status is =" + Transition.transitionClone);

        print("Transition.startProducts =" + Transition.startProducts);

        //CreateProducts();
        if ((Transition.transitionClone != null)&&(shouldDestroy == true))
        {
            // Destroy clone
            //Invoke("DestroyTransition", waitTimeDestroyTransition);
            DestroyTransition();
            shouldDestroy = false;
        }

        //CreateProducts();
        
    }

    void DestroyTransition()
    {
        // Get current position of the transition object
        currentTransitionPos = Transition.transitionClone.transform.position;
        print("DestroyTransition: Transition.transitionClone status is =" + Transition.transitionClone);

        // Destroy Transition objects
        Destroy(Transition.transitionClone);

        CreateProducts();

        /*
         * 
         * Below is the message I got when I was trying to destroy the game object 
         * to which the prefab was attached. Instead I created a game object variable to hold the 
         * instantiated clone and destroyed that instead. That process did not lead to the
         * error message below.
        "Destroying assets is not permitted to avoid data loss.
        If you really want to remove an asset use DestroyImmediate(theObject, true);"
        */
    }

    void CreateProducts()
    {
        print("in CreateProducts");
        //prodAClone = Instantiate(prodA, transform.position, transform.rotation);
        //prodBClone = Instantiate(prodB, transform.position, transform.rotation);
        prodAClone = Instantiate(prodA, (currentTransitionPos - Transition.subAdistFrom), Transition.subARot);
        prodBClone = Instantiate(prodB, (currentTransitionPos - Transition.subBdistFrom), Transition.subBRot);

    }
}
