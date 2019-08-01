using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Reaction2 : MonoBehaviour
{
    /* A note about this script. Currently it is attached to 1 of 2 molecule objects in the scene.
 * The trigger controls the animations for both molecule objects, which means they are 
 * almost exactly synchronized. We could configure it so that each molecule has
 * its own reaction script --In fact, with more molecules we'll almost have to do that --
 * but I predict that will cause the animations to not be quite as 
 * synchronized as they are now and will require tweaking. */

    public static GameObject parentSubA;
    public static GameObject parentSubB;
    Animator animatorA;
    Animator animatorB;
    public static Vector3 colliderPos;

    public float waitTimeTransition = 5;
    public float waitTimeFinal = 20;
    private RandomMovement2 randomMovement;
    private ColliderCntllr2 colliderCntllr;
    // "What we're...referencing is an instance of the class, [RandomMovement], defined in the 
    // [RandomMovement.cs] script." - Unity manual

    public static bool firstCollide = true;   // referred to in Transition
    public static bool isReaction = false;     // referred to in Transition
    public static bool isAfter;        // referred to in ColliderCntllr2
    public static bool stopMoving;     // referred to in RandomMovement2
                                       // Making this boolean 'static' makes it a member of the class, Reaction,
                                       // instead of a member of any particular instance of that class. 
                                       // Therefore it will persist for the run of the program and allow me to 
                                       // refer to it in other scripts. 






    void Awake()
    {
        randomMovement = GetComponent<RandomMovement2>();
        colliderCntllr = GetComponent<ColliderCntllr2>();
        //transition = GetComponent<Transition>();
        isReaction = false;
        firstCollide = true;
        isAfter = false;
        stopMoving = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (ColliderCntllr2.first == true)
        {
            animatorA = GameObject.Find("Water").GetComponent<Animator>();
            animatorB = GameObject.Find("Hydronium").GetComponent<Animator>();
            parentSubA = GameObject.Find("parentSubstrateA");
            parentSubB = GameObject.Find("parentSubstrateB");

            /*
            animatorA.SetBool("isPause", false);
            animatorA.SetBool("isTransition", false);
            animatorA.SetBool("isFinal", false);
            animatorB.SetBool("isPause", false);
            animatorB.SetBool("isTransition", false);
            animatorB.SetBool("isFinal", false);
            */
        }
    }
    
    // We have to use OnTriggerEnter instead of OnCollisionEnter because
    // the Capsule objects we're using as a corner collider to trigger
    // the reaction does not have a rigidbody attached to it. Therefore,
    // the Unity physics engine does not recognize the collisions it makes
    // with the other Capsule object which ALSO has no rigidbody. The 
    // collider component can work as a trigger however. Make sure the
    // 'Is Trigger' box is checked on the Collider component of the capsule
    // to which this script is attached.
    void OnTriggerEnter(Collider other)
    {
        colliderPos = other.transform.position;
        print("Collider other " + other.transform.position);      // gets the name of the object associated with the collider that just triggered the trigger event.
        print("colliderPos " + colliderPos);

        if (other.GetComponent<Collider>().gameObject.name == "ColliderObjectB")
        {
            print("B Reaction");
            print("ColliderB position " + other.GetComponent<Collider>().gameObject.transform.position);

            if (firstCollide == true)
            {
                SetTransitionFlag();
            }

            firstCollide = false;
        }
        
    }
    void SetTransitionFlag()
    {
        isReaction = true;
        stopMoving = true;
    }
}

