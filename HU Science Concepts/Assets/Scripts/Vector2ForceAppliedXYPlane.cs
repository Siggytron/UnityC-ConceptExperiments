/*This script is applies a Vector2 force to a 3D object in a 3D space. Although it
 * only applies the force in 2 dimensions, it does not restrict movement in 
 * all 3 dimensions. Additionally the object to which this is attached currently
 * has some looping rotational animations. The effect is actually a more
 * effective random movement in the 3D space than the script which adds
 * a Vector3 force. Curious.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMoveXYPlane : MonoBehaviour
{
    private float rand;
    private float currentTime = 0;

    public float switchDirection = 3;
    public float speed = 1;
    public float xMove = 1;
    public float yMove = 1;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetVel();

    }

    void SetVel()
    {
        rand = Random.value;

        if (rand > .5)
        {
            xMove = 10 * rand;
            yMove = 10 * rand;
        }
        else
        {
            xMove = -10 * rand;
            yMove = -10 * rand;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (currentTime < switchDirection)
        {
            currentTime += 1 * Time.deltaTime;
        }
        else
        {
            SetVel();

            if (rand > .5)
            {
                switchDirection += rand;
            }
            else
            {
                switchDirection -= rand;
            }
            if (switchDirection < 1)
            {
                switchDirection = 1 + rand;
            }

            currentTime = 0;
        }
    }
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(xMove, yMove);
        rb.AddForce(movement * speed, ForceMode.Force);
    }
}
