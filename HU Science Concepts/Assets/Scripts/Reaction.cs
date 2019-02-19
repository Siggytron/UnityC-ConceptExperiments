using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour
{
    Animator animatorA;
    Animator animatorB;
    bool firstCollide;
    public float waitTimeTransition = 5;
    public float waitTimeFinal = 6;

    public static bool isAfter;
    // From what I understand, making this boolean 'static' allows it to 
    // persist for the run of the program and thus allows me to 
    // refer to it in other scripts. I'm not sure if every variable
    // that one ever wants to refer to across scripts needs to be
    // declared static. A question for another day.


    // Start is called before the first frame update
    void Start()
    {
        animatorA = GameObject.Find("SubstrateA").GetComponent<Animator>();
        print(animatorA);
        animatorB = GameObject.Find("SubstrateB").GetComponent<Animator>();
        print(animatorB);

        animatorA.SetBool("isPause", false);
        animatorA.SetBool("isTransition", false);
        animatorA.SetBool("isFinal", false);
        animatorB.SetBool("isPause", false);
        animatorB.SetBool("isTransition", false);
        animatorB.SetBool("isFinal", false);
        firstCollide = true;
        isAfter = false;

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

        //print(GetComponent<Collider>().gameObject.name);
        // The above prints the name of the gameObject this script is attached to.
        // other.GetComponent...  gets the name of the object associated with the
        // collider that just triggered the trigger event.
        
        if (other.GetComponent<Collider>().gameObject.name == "ColliderObjectB")
        {
            print("B Reaction");

            if (firstCollide == true)
            {
                StateCntllr();
            }

            firstCollide = false;

            
            //Start Transition Script
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
        // Stop Initial animation, switch to Pause animation (SubstrateObjects A and B hold image for x seconds.)
        print("Pause");
        //animatorA.SetBool("isPause", true);
        //animatorB.SetBool("isPause", true);
        animatorA.Play("Pause", -1, 0);
        animatorB.Play("Pause", -1, 0);

    }

    void ToTransitionCycle()
    {
        print("Transition Cycle");
        //animatorA.SetBool("isTransition", true);
        //animatorB.SetBool("isTransition", true);
        animatorA.Play("TransitionA", -1, 0);
        animatorB.Play("TransitionB", -1, 0);

    }

    void ToFinalCycle()
    {
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

