using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControllerUniversal : MonoBehaviour
{
    // Start is called before the first frame update
    
    // defining possible tank actions
    public bool LeftBodyRotation;
    public bool RightBodyRotation;
    public bool ForwardBodyMovement;
    public bool BackwardsBodyMovement;
    public bool FirePrimary;
    public bool FireSecondary;
    public bool LeftTurretRotation;
    public bool RightTurretRotation;



    // defining the Rigidbody and collider of the tank
    private Rigidbody AgentRigidBody;
    private Collider AgentCollider;
    
    
    // creating speed variables
    public float RotationSpeed;
    public float MovementSpeed;
    public float CannonSpeed;
    public float BulletSpeed;
    
    
    // defining the turret object and rigidbody
    public GameObject Turret;
    private Rigidbody TurretRigidbody;
    
    
    
    // defining projectiles and their spawn point
    public Rigidbody Cannon;
    public Transform ProjectileSpawnPoint; 
    public Rigidbody Bullet;
    

    void Start()
    {
        // getting required components and assigning them
        AgentRigidBody = GetComponent<Rigidbody>();
        AgentCollider = GetComponent<BoxCollider>();
        TurretRigidbody = Turret.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {   
        // making the tank perform any of its possible actions based on the bool value
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
            AgentRigidBody.AddForce(transform.forward* MovementSpeed);
        }
        if (BackwardsBodyMovement)
        {
            AgentRigidBody.AddForce(-transform.forward * MovementSpeed);
        }
        if (FirePrimary)
        {
            primraryFire();
        }
        if (FireSecondary)
        {
            secondaryFire();
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
    void primraryFire()
    {   
        // instantiating prefab, giving it movement speed and disbling the action ( prevent looping based on framerate )
        Rigidbody CannonInstance;
        CannonInstance = Instantiate(Cannon, ProjectileSpawnPoint.position, ProjectileSpawnPoint.rotation)
         as Rigidbody;
        CannonInstance.AddForce(ProjectileSpawnPoint.forward * CannonSpeed);
        FirePrimary = false;
    }
    void secondaryFire()
    {   
        // instantiating prefab, giving it movement speed and disbling the action ( prevent looping based on framerate )
        Rigidbody BulletInstance;
        BulletInstance = Instantiate(Bullet,ProjectileSpawnPoint.position, ProjectileSpawnPoint.rotation )
        as Rigidbody;
        BulletInstance.AddForce(ProjectileSpawnPoint.forward * BulletSpeed );
        FireSecondary = false;
    }




}
