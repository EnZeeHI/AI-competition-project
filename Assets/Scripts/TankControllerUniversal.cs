using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private GameObject AgentGameObject;
    
    
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
    
    // health system
    public int StartingHealth;
    public int CurrentHealth;
    public bool IsDead;
    public bool Damaged;
    public GameObject EnemyTank;
    public TankControllerUniversal EnemyScript;

    // scoring system
    public int TankRoundsWon;

    public Scene CurrentScene;

    void Start()
    {
        // getting required components and assigning them
        AgentRigidBody = GetComponent<Rigidbody>();
        AgentCollider = GetComponent<BoxCollider>();
        TurretRigidbody = Turret.GetComponent<Rigidbody>();
        AgentGameObject = this.transform.parent.gameObject;
         
        CurrentHealth = StartingHealth;

        // scene management
        Scene CurrentScene = SceneManager.GetActiveScene();

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
    // script that makes the gameobject this script is attached to take damage
    public void TakeDamage (int amount)
    {
        Damaged = true;
        CurrentHealth = CurrentHealth - amount;
        if (CurrentHealth <=0 && !IsDead)
        {
           // 
            Death();
        }
    }
    // destoys the dead tank, resets the scene
    void Death()
    {
        IsDead = true;
        
        Destroy(transform.parent.gameObject);
        
        
      
        //Invoke("ResetLevel", 0.1f); // the delay breaks the function for some reason
        ResetLevel();
        

    }
    // gives damage to any tank that the projectile hits
    public void GiveDamage(Collision Reciever, int amount)
    {
        EnemyTank =Reciever.transform.parent.gameObject;
        EnemyScript= EnemyTank.GetComponentInChildren<TankControllerUniversal>();
        EnemyScript.TakeDamage(amount);
        
       
    }
    // reloads the scene
    void ResetLevel()
    {
        GetScore(1,AgentGameObject);
        SceneManager.LoadScene("SampleScene");

    }
    // gives score to the remaining tank(runs on the destroyed tank script)
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
   

}
