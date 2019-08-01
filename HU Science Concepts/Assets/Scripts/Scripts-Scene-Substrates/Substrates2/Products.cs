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

    void Update()
    {
        if ((Transition.startProducts == true) && (shouldDestroy == true)) 
        {
            Invoke("TransToProductCycle", waitTimeDestroyTransition);
            Transition.startProducts = false;
        }
    }
    void TransToProductCycle()
    {
        print("TransToProductCycle: Transition.transitionClone status is =" + Transition.transitionClone);
        print("Transition.startProducts =" + Transition.startProducts);

        //Destroy Transition object
        if ((Transition.transitionClone != null)&&(shouldDestroy == true))
        {
            // Destroy clone
            //Invoke("DestroyTransition", waitTimeDestroyTransition);
            DestroyTransition();
            shouldDestroy = false;
        }
    }

    void DestroyTransition()
    {
        // Get current position of the transition object
        currentTransitionPos = Transition.transitionClone.transform.position;
        print("DestroyTransition: Transition.transitionClone status is =" + Transition.transitionClone);

        // Destroy Transition objects
        Destroy(Transition.transitionClone);

        CreateProducts();
    }

    void CreateProducts()
    {
        print("in CreateProducts");
        prodAClone = Instantiate(prodA, transform.position, transform.rotation);
        prodBClone = Instantiate(prodB, transform.position, transform.rotation);
        //prodAClone = Instantiate(prodA, (currentTransitionPos - Transition.subAdistFrom), Transition.subARot);
        //prodBClone = Instantiate(prodB, (currentTransitionPos - Transition.subBdistFrom), Transition.subBRot);

    }
}
