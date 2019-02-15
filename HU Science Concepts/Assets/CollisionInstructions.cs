using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInstructions : MonoBehaviour
{
    public Material Pink;
    public Material Red;
    public Material lightBlue;
    public Material Yellow;
    Renderer rend;


    // Start is called before the first frame update
    void Start()
    {

        print("Start");
        //Fetch the Renderer from the GameObject
        rend = GetComponent<Renderer>();

        print(rend.material);

    }

    void OnCollisionEnter(Collision collision)
    {




        if(collision.gameObject.name == "BlueAtom")
        {
            rend.material = lightBlue;
        }
        else if(collision.gameObject.name == "YellowAtom")
        {
            rend.material = Yellow;
        }
        else
        {
            //rend.material = Pink;
        }

        //Set the main Color of the Material
        /*
        if (rend.material = Red)
        {
            rend.material = Pink;
        }
        else
        {
            rend.material = Red;
        }
        */
        //rend.material.SetColor("_Color", Color.green);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }
}
