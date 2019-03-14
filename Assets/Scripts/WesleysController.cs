using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WesleysController : MonoBehaviour
{
    private TankController TankController;

    private int wall = 1 << 10;
    private int checkPoint = 1 << 9;

    private Vector3 front = new Vector3(0, 0, 20);
    private Vector3 frontRight = new Vector3(10, 0, 7.5f);
    private Vector3 frontLeft = new Vector3(-10, 0, 7.5f);
    private Vector3 backRight = new Vector3(10, 0, -5);
    private Vector3 backLeft = new Vector3(-10, 0, -5);

    /*
        Valid Functions:
        
        Move (float speed)

        Rotate (float rot)
        
        GetRotation (for some reason)
        
        PrimaryFire (we still don't know what to do when bullets hit other tanks)
        
        CastRayCast (vector3 direction, int layermask)
    */
    
    // Start is called before the first frame update
    void Start()
    {
        TankController = gameObject.GetComponent<TankController>();
        TankController.Move(1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        TankController.Move(TankController.CastRayCast(front, wall).distance / 27.5f);

        if(TankController.CastRayCast(frontLeft, wall).distance > TankController.CastRayCast(frontRight, wall).distance){
            TankController.Rotate(-0.5f);
            Debug.Log("Should I go Left?");
        }
        if(TankController.CastRayCast(frontLeft, wall).distance < TankController.CastRayCast(frontRight, wall).distance){
            TankController.Rotate(0.5f);
            Debug.Log("Should I go right?");
        }
        
    }
}
