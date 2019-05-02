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

    Rigidbody rigidbodyA;
    Rigidbody rigidbodyB;
    GameObject parentSubA;
    GameObject parentSubB;
    HingeJoint hj;
    Animator animatorA;
    Animator animatorB;
    bool firstCollide;
    public float waitTimeTransition = 5;
    public float waitTimeFinal = 20;
    private RandomMovement2 randomMovement;
    // "What we're...referencing is an instance of the class, [RandomMovement], defined in the 
    // [RandomMovement.cs] script." - Unity manual

    public static bool isAfter;        // referred to in ColliderCntllr2
    public static bool stopMoving;     // referred to in RandomMovement2
                                       // Making this boolean 'static' makes it a member of the class, Reaction,
                                       // instead of a member of any particular instance of that class. 
                                       // Therefore it will persist for the run of the program and allow me to 
                                       // refer to it in other scripts. 

    // All of this makes rigidbodyB the child of rigidbodyA
    Transform tempTrans;

    //Make object 2 child of object 1.
    void ChangeParent()
    {
        tempTrans = rigidbodyB.transform.parent;
        print(tempTrans);
        rigidbodyB.transform.parent = rigidbodyA.transform;
        print(rigidbodyB.transform.parent);
    }

    //Revert the parent of object 2.
    void RevertParent()
    {
        rigidbodyB.transform.parent = tempTrans;
    }


    //
    void CreateJoint()
    {
        hj = parentSubA.AddComponent<HingeJoint>();
        hj.connectedBody = rigidbodyB;
        print("create joint");
        rigidbodyB.freezeRotation = true;
        rigidbodyB.velocity = new Vector3(0, 0, 0);
        print(hj);
        print(rigidbodyB);
        print(rigidbodyB.velocity);
    }
    /*
    function OnCollisionEnter(other : Collision)
    {
        if (other.gameObject.tag == "this")
        {
            var hj : HingeJoint;
            hj = gameObject.AddComponent("HingeJoint");
            hingeJoint.connectedBody = other.rigidbody;
            rigidbody.mass = 0.00001;
            collider.material.bounciness = 0;
            rigidbody.freezeRotation = true;
            rigidbody.velocity = Vector3(0, 0, 0);
        }
    }
    */
    void DestroyJoint()
    {
        Destroy(hj);
        //rigidbody.mass = 1;
    }

    private void Awake()
    {
        randomMovement = GetComponent<RandomMovement2>();

    }
    // Start is called before the first frame update
    void Start()
    {
        animatorA = GameObject.Find("SubstrateA").GetComponent<Animator>();
        print(animatorA);
        animatorB = GameObject.Find("SubstrateB").GetComponent<Animator>();
        print(animatorB);
        rigidbodyA = GameObject.Find("parentSubstrateA").GetComponent<Rigidbody>();
        print(rigidbodyA);
        rigidbodyB = GameObject.Find("parentSubstrateB").GetComponent<Rigidbody>();
        print(rigidbodyB);
        parentSubA = GameObject.Find("parentSubstrateA");
        print(parentSubA);
        parentSubB = GameObject.Find("parentSubstrateB");
        print(parentSubB);


        animatorA.SetBool("isPause", false);
        animatorA.SetBool("isTransition", false);
        animatorA.SetBool("isFinal", false);
        animatorB.SetBool("isPause", false);
        animatorB.SetBool("isTransition", false);
        animatorB.SetBool("isFinal", false);
        firstCollide = true;
        isAfter = false;
        stopMoving = false;

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
        /*
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true; // stop physics
        */

        //transform.parent = other.transform;

        // print(GetComponent<Collider>().gameObject.name);
        // The above prints the name of the gameObject this script is attached to.
        // other.GetComponent...  gets the name of the object associated with the
        // collider that just triggered the trigger event.
        
        if (other.GetComponent<Collider>().gameObject.name == "ColliderObjectB")
        {
            print("B Reaction");

            if (firstCollide == true)
            {
                //ChangeParent();
                StateCntllr();
            }

            firstCollide = false;
        }
        
    }
    

   void StateCntllr()
    {

        // Take animation state from one to the next

        // Go from Initial to Pause
        ToPauseCycle();

        // Go from Pause to Transition after x seconds
        Invoke("ToTransitionCycle", waitTimeTransition);

        // Go from Transition to Final state
        Invoke("ToFinalCycle", waitTimeFinal);

    }

    void ToPauseCycle()
    {
        // Stop Initial animation
        // The 2 stick together and drift together
        // Switch to Pause animation (SubstrateObjects A and B hold image for 'waitTimeTransition' seconds.)
        print("Pause");
        stopMoving = true;
        CreateJoint();
        animatorA.Play("Pause", 0, 0);
        animatorB.Play("Pause", 0, 0);

    }

    void ToTransitionCycle()
    {
        // Continue to stick together
        // Switch to Transition animation
        print("Transition Cycle");
        //animatorA.SetBool("isTransition", true);
        //animatorB.SetBool("isTransition", true);
        animatorA.Play("TransitionA", -1, 0);
        animatorB.Play("TransitionB", -1, 0);
    }

    void ToFinalCycle()
    {
        stopMoving = false;
        // ColliderObjectsA and B move position relative to substrates
        // Really I think I'm going to have 2 objects, deactivate one and 
        // activate the other.

        print("Final");
        //animatorA.SetBool("isFinal", true);
        //animatorB.SetBool("isFinal", true);
        animatorA.Play("PropertyA", -1, 0);
        animatorB.Play("PropertyB", -1, 0);

        // This variable is for communicating with the ColliderContllr.cs script
        // Perhaps I should turn this into a function call.
        isAfter = true;

    }

}

