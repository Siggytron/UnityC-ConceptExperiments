using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReactionProducts : MonoBehaviour
{
    /* A note about this script. Currently it is attached to 1 of 2 molecule objects in the scene.
 * The trigger controls the animations for both molecule objects, which means they are 
 * almost exactly synchronized. We could configure it so that each molecule has
 * its own reaction script --In fact, with more molecules we'll almost have to do that --
 * but I predict that will cause the animations to not be quite as 
 * synchronized as they are now and will require tweaking. */

    public static Vector3 colliderPos;

    public float waitTimeTransition = 5;
    public float waitTimeFinal = 20;
    private RandomMovement2 randomMovement;
    private ColliderCntllr2 colliderCntllr;
    // "What we're...referencing is an instance of the class, [RandomMovement], defined in the 
    // [RandomMovement.cs] script." - Unity manual

    public static bool isReaction = false;     // referred to in Transition
    public static bool isAfter;        // referred to in ColliderCntllr2
    public static bool stopMoving;     // referred to in RandomMovement2
                                       // Making this boolean 'static' makes it a member of the class, Reaction,
                                       // instead of a member of any particular instance of that class. 
                                       // Therefore it will persist for the run of the program and allow me to 
                                       // refer to it in other scripts. 




    // Experiment to see if I can get one of the objects to teleport
    // to a specific spot
    void PlaceMolecule()
    {
        //stopMoving = true;
        isReaction = true;
    }

    void Awake()
    {
        randomMovement = GetComponent<RandomMovement2>();
        colliderCntllr = GetComponent<ColliderCntllr2>();
        //transition = GetComponent<Transition>();
        isReaction = false;
        isAfter = false;
        stopMoving = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // We have to use OnTriggerEnter instead of OnCollisionEnter because
    // the Capsule objects we're using as a corner collider to trigger
    // the reaction does not have a rigidbody attached to it. Therefore,
    // the Unity physics engine does not recognize the collisions it makes
    // with the other Capsule object which ALSO has no rigidbody. The 
    // collider component can work as a trigger however. Make sure the
    // 'Is Trigger' box is checked on the Collider component of the capsule
    // to which this script is attached.
    /*
    void OnTriggerEnter(Collider other)
    {
        colliderPos = other.transform.position;
        print("Collider other " + other.transform.position);
        print("colliderPos " + colliderPos);
        // print(GetComponent<Collider>().gameObject.name);
        // The above prints the name of the gameObject this script is attached to.
        // other.GetComponent...  gets the name of the object associated with the
        // collider that just triggered the trigger event.

        if (other.GetComponent<Collider>().gameObject.name == "ColliderObjectB")
        {
            print("B Reaction");
            print("ColliderB position " + other.GetComponent<Collider>().gameObject.transform.position);


            if (firstCollide == true)
            {
                //PlaceMolecule();
            }

            firstCollide = false;
        }

    }
    */

}

