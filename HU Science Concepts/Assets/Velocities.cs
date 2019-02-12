using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocities : MonoBehaviour
{
    public float speed;

    public float xMove = 1;
    public float yMove = 1;
    public float zMove = 1;
    
    private Rigidbody rb;
 

    // Start is called before the first frame update
    void Start()
    {

    rb = GetComponent<Rigidbody>();
        
    xMove = Random.value;
    yMove = Random.value;
    zMove = Random.value;  


    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        xMove = Random.value;
        yMove = Random.value;
        zMove = Random.value;

        Vector3 movement = new Vector3(xMove, yMove, zMove);
        rb.AddForce(movement * speed, ForceMode.Force);
    }

}
