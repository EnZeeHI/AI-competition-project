using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControllerUniversal : MonoBehaviour
{
    // Start is called before the first frame update
    public bool LeftBodyRotation;
    public bool RightBodyRotation;
    public bool ForwardBodyMovement;
    public bool BackwardsBodyMovement;
    public bool FirePrimary;
    public bool FireSecondary;
    public bool LeftTurretRotation;
    public bool RightTurretRotation;
    private Rigidbody AgentRigidBody;
    private Collider AgentCollider;
    public float RotationSpeed;
    public float MovementSpeed;
    public GameObject Turret;
    private Rigidbody TurretRigidbody;



    void Start()
    {
        AgentRigidBody = GetComponent<Rigidbody>();
        AgentCollider = GetComponent<BoxCollider>();

        
        TurretRigidbody = Turret.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (LeftBodyRotation)
        {
            AgentRigidBody.transform.Rotate(Vector3.down*Time.deltaTime*RotationSpeed);

        }
        if (RightBodyRotation)
        {
            AgentRigidBody.transform.Rotate(Vector3.up*Time.deltaTime*RotationSpeed);
        }
        if (ForwardBodyMovement)
        {
            AgentRigidBody.transform.Rotate(Vector3.left*Time.deltaTime*MovementSpeed);
        }
        if (BackwardsBodyMovement)
        {
            AgentRigidBody.transform.Rotate(Vector3.right*Time.deltaTime*MovementSpeed);
        }
        if (FirePrimary)
        {
            
        }
        if (FireSecondary)
        {

        }
        if (LeftTurretRotation)
        {
            TurretRigidbody.transform.Rotate(Vector3.down*Time.deltaTime*RotationSpeed);
        }
        if (RightTurretRotation)
        {
            TurretRigidbody.transform.Rotate(Vector3.up*Time.deltaTime*RotationSpeed);
        }

        
    }
}
