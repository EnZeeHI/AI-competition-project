using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankControllerUniversal : MonoBehaviour, ITank
{
    // Defining possible tank actions
    public bool LeftBodyRotation;
    public bool RightBodyRotation;
    public bool ForwardBodyMovement;
    public bool BackwardsBodyMovement;
    public bool FirePrimary;

    public bool checkPoint;

    // Defining the Rigidbody, Collider and GameObject of the tank
    private Rigidbody AgentRigidBody;
    private Collider AgentCollider;
    private GameObject AgentGameObject;
    
    // Creating speed variables
    public float RotationSpeed;
    public float MovementSpeed;
    public float CannonSpeed;
        
    // Defining projectiles and their spawn point
    public Rigidbody Cannon;
    public Transform ProjectileSpawnPoint; 
    
    // Health System
    public int StartingHealth;
    public int CurrentHealth;
    public bool IsDead;
    public bool Damaged;
    public GameObject EnemyTank;
    public TankControllerUniversal EnemyScript;
    
    // Scene Management
    public Scene CurrentScene;
    
    // Start is called before the first frame update
    void Start()
    {
        // Getting required components and assigning them
        AgentRigidBody = this.GetComponentInChildren<Rigidbody>();
        AgentCollider = GetComponent<BoxCollider>();
        AgentGameObject = this.gameObject;
         
        CurrentHealth = StartingHealth;

        // Scene Management
        Scene CurrentScene = SceneManager.GetActiveScene();

    }

    // Update is called once per frame
    void Update()
    {   
        // Making the tank perform any of its possible actions based on the bool value
        
        if (ForwardBodyMovement)
        {
            MoveForward();
        }
        if (BackwardsBodyMovement)
        {
            MoveBackwards();
        }
        if (LeftBodyRotation)
        {
            RotateLeft();
        }
        if (RightBodyRotation)
        {
            RotateRight();
        }
        if (FirePrimary)
        {
            PrimraryFire();
        }
        if (checkPoint)
        {
            NextCheckPoint();
        }
    }
    public void MoveForward()
    {
        AgentRigidBody.velocity = AgentRigidBody.transform.forward* MovementSpeed;
    }
    public void MoveBackwards()
    {
        AgentRigidBody.velocity= AgentRigidBody.transform.forward * -MovementSpeed;
    }
    public void RotateLeft()
    {
        AgentRigidBody.transform.Rotate(Vector3.down*Time.deltaTime*RotationSpeed);
    }
    public void RotateRight()
    {
        AgentRigidBody.transform.Rotate(Vector3.up*Time.deltaTime*RotationSpeed);
    }
    
    public void PrimraryFire()
    {   
        // Instantiating prefab, giving it movement speed and disbling the action ( prevent looping based on framerate )
        Rigidbody CannonInstance;
        CannonInstance = Instantiate(Cannon, ProjectileSpawnPoint.position, ProjectileSpawnPoint.rotation)
         as Rigidbody;
        CannonInstance.AddForce(ProjectileSpawnPoint.forward * CannonSpeed);
        FirePrimary = false;
    }
   
    // Script that makes the gameobject this script is attached to take damage
    public void TakeDamage (int amount)
    {
        Damaged = true;
        CurrentHealth = CurrentHealth - amount;
        if (CurrentHealth <=0 && !IsDead)
        {
            Death();
        }
    }
    public Vector3 GetRotation()
    {
        return AgentRigidBody.transform.rotation.eulerAngles;
    }

    public Vector2 GetPosition()
    {
        return AgentRigidBody.transform.position;
    }
    public int GetHealth()
    {
        return CurrentHealth;
    }
    // Destoys the dead tank, Resets the scene
    void Death()
    {
        IsDead = true;
        Destroy(gameObject);      
    }
    // Gives damage to any tank that the projectile hits
    public void GiveDamage(Collision Reciever, int amount)
    {
        EnemyTank =Reciever.transform.parent.gameObject;
        EnemyScript= EnemyTank.GetComponentInChildren<TankControllerUniversal>();
        EnemyScript.TakeDamage(amount);       
    }
    // Reloads the scene
    void ResetLevel()
    {
        GetScore(1,AgentGameObject);
        SceneManager.LoadScene("SampleScene");
    }
    // Gives score to the remaining tank(runs on the destroyed tank script)
    void GetScore(int amount, GameObject ObjectGettingScore)
    {
        if (ObjectGettingScore.name=="Tank2")
        {
            GameStats.Tank1Wins = GameStats.Tank1Wins + amount;
        }
        if (ObjectGettingScore.name=="Tank1")
        {
            GameStats.Tank2Wins = GameStats.Tank2Wins + amount;
        }
        Debug.Log("tank 1 " + GameStats.Tank1Wins);
        Debug.Log("tank 2 " + GameStats.Tank2Wins);
    }

    public bool NextCheckPoint()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 9;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
            return false;
        }
    }
}
