using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAras : MonoBehaviour
{

    public TankController controller;

    public int wallLayer = 1 << 10;
    public int checkpointLayer = 1 <<9;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<TankController>();
        controller.Move(0);
    }

    // Update is called once per frame
    void Update()
    {   
        RaycastHit forward = controller.CastRayCast(new Vector3 (0,0,1), wallLayer);
        RaycastHit farLeft = controller.CastRayCast(new Vector3 (-1,0,0),wallLayer);
        RaycastHit farRight = controller.CastRayCast(new Vector3 (1,0,0),wallLayer);
        RaycastHit closeRight = controller.CastRayCast(new Vector3 (0.5f,0,1),wallLayer);
        RaycastHit closeLeft = controller.CastRayCast(new Vector3 (-0.5f,0,1), wallLayer);
        RaycastHit checkpointForward = controller.CastRayCast(new Vector3(0,0,1), checkpointLayer);
        RaycastHit checkpointRight = controller.CastRayCast(new Vector3(0.25f,0,1), checkpointLayer);
        RaycastHit checkpointLeft = controller.CastRayCast(new Vector3(-0.25f,0,1), checkpointLayer);

       
        if (forward.distance <25)
        {  
            Debug.Log("obstacle");
            if(farRight.distance > farLeft.distance )
            {   
                controller.Rotate(1.5f);
                controller.Move(0.5f);
                speed = 0.5f;
                Debug.Log("turn right");
            }
            else
            {
                controller.Rotate(-1.5f);
                controller.Move(0.5f);
                speed = 0.5f;
                Debug.Log("turn left");
            }
            if (farRight.distance == farLeft.distance && closeLeft.distance < closeRight.distance)
            {
                controller.Rotate(-0.25f);
            }
            if(farRight.distance == farLeft.distance && closeLeft.distance > closeRight.distance)
            {
                controller.Rotate(0.25f);
            }
        
           
        }
        else
        {
            controller.Move(1.25f);
            speed = 1.25f;
            controller.Rotate(0);
        }
        if (closeLeft.distance < 2f || farLeft.distance < 1.5f )
        {
            controller.Rotate(0.2f);
            Debug.Log("avoid");
        }
        if (closeRight.distance < 2f || farRight.distance < 1.5f)
        {
            controller.Rotate(-0.2f);
            Debug.Log("avoid");
        }
        
        




    }
}
