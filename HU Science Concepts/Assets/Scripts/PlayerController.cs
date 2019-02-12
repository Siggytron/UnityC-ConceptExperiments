using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Update is called before rendering a frame.
        // This is where most of the game code will go.
    }

    void FixedUpdate()
    {
        // FixedUpdate is called before doing any physics calculations.
        // This is where the physics code will go.

        float moveHoriz = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHoriz, 0, moveVert);

        rb.AddForce(movement*speed);
    }
}
