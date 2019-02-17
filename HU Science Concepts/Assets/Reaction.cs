using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour
{
    Animator animator;
    float time = 0;
    bool trans;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("SubstrateA").GetComponent<Animator>();
        print(animator);
        trans = animator.GetBool("isTransitionTriggered");
        animator.SetBool("isTransitionTriggered", false);
        animator.SetBool("isTransitionDone", false);
        print("Start");

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

            Transition();
            //Start Transition Script
        }
        
    }

    void Transition()
    {
        time = 0;

        // SubstrateObjects A and B hold image for x seconds.

        // Change the animator cycle for ColliderObjectA to transition 
        animator.SetBool("isTransitionTriggered", true);

        // ColliderObjectB holds on a blank image

        // ColliderObjectsA and B move position relative to substrates



    }

    void Update()
    {
        time += Time.deltaTime;
        print(time);
        // After a certain amount of time, transition ends and animation
        // state moves to Property cycles.
        if ((time > 3) && (trans = true))
        {
            animator.SetBool("isTransitionDone", true);
            print("Transition Done");
        }
    }

}

