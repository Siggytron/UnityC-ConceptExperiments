using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewVelocity : MonoBehaviour
{
    private float rand;
    private float currentTime = 0;

    public float switchDirection = 3;
    public float speed = 1;
    public float xMove = 1;
    public float yMove = 1;
    public float zMove = 1;

    private Rigidbody rb;
    private Bounds bnds;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bnds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 10, 0));
        SetVel();

    }

    void SetVel()
    {
        rand = Random.value;

        if (rand > .5)
        {
            xMove = 10 * rand;
            zMove = -10 * rand;
            yMove = 10 * rand;
        }
        else
        {
            xMove = -10 * rand;
            zMove = 10 * rand;
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
        Vector3 movement = new Vector3(xMove, yMove, zMove);
        rb.AddForce(movement*speed, ForceMode.Force);
    }
}
