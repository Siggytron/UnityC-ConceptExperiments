using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepelObjects : MonoBehaviour
{
    // First you have to declare and name a vector. This
    // one I plan to use to determine the position of whatever
    // object I have attached this script to.
    Vector3 boxPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Here is where I get the position of the gameObject
        // this script is attached to. 
        boxPosition = transform.position;

        // Print the position to console just to check everything
        // is kosher.
        print(boxPosition);

        
    }

    // This is code is to attempt to keep objects moving randomly from 
    // sticking in the corners. There may be a way to handle this
    // more elegantly but it seems a fairly common Unity forum
    // complaint. This will give a little push away from the corners
    // to any object that arrives in a corner. This script will be
    // attached to invisible boxes set in the corners of the 
    // NavMeshPlane.
    
    void OnCollisionEnter(Collision collision)
    {
        Vector3 pointOfContact = collision.contacts[0].point;
        print(pointOfContact);

        //Vector3 pos = collision.rigidbody.transform;
        //collision.rigidbody.AddForce(Vector3.Reflect(pos, inNormal));

    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
