using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInstructions : MonoBehaviour
{
    // Apparently it is not enough to refer to materials that have been
    // created in Unity. They must be created here too, either publicly
    // or privately before they can be used in the code.
    public Material Pink;
    public Material Red;
    public Material darkBlue;
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
            rend.material = darkBlue;
        }
        else if(collision.gameObject.name == "YellowAtom")
        {
            rend.material = Yellow;
        }
        else
        {
            //rend.material = Pink;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }
}
