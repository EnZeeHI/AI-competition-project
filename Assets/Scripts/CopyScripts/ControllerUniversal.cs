using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerUniversal : MonoBehaviour, ITank
{
    // Defining the Rigidbody, Collider and GameObject of the tank
    private Rigidbody body;
    
    // Creating speed variables
    public float rotationSpeed;
    public float movementSpeed;
    public float cannonSpeed;
        
    // Defining projectiles and their spawn point
    public GameObject cannon;
    public Transform projectileSpawnPoint; 
    
    // Health System
    public int startingHealth;
    public int currentHealth;
    public bool isDead;
    public bool damaged;
    
    // Start is called before the first frame update
    void Start()
    {
        // Getting required components and assigning them
        body = gameObject.GetComponent<Rigidbody>();
         
        currentHealth = startingHealth;
    }

    public void MoveForward()
    {
        body.velocity = transform.forward * movementSpeed;
    }
    public void MoveBackwards()
    {
        body.velocity = transform.forward * - movementSpeed;
    }
    public void RotateLeft()
    {
        transform.Rotate(Vector3.down * Time.deltaTime * rotationSpeed);
    }
    public void RotateRight()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
    
    public void PrimraryFire()
    {   
        // Instantiating prefab, giving it movement speed and disbling the action ( prevent looping based on framerate )
        Projectile cannonInstance = Instantiate(cannon, projectileSpawnPoint.position, projectileSpawnPoint.rotation).GetComponent<Projectile>();
        if (cannonInstance != null) cannonInstance.ShootCannon(this.gameObject, cannonSpeed);
    }
   
    // Script that makes the gameobject this script is attached to take damage
    public void TakeDamage (int amount)
    {
        damaged = true;
        currentHealth = currentHealth - amount;
        if (currentHealth <=0 && !isDead)
        {
            Death();
        }
    }

    public Vector3 GetRotation()
    {
        return transform.rotation.eulerAngles;
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    // Destoys the dead tank, Resets the scene
    void Death()
    {
        isDead = true;
        Destroy(gameObject);      
    }

    // Gives damage to any tank that the projectile hits
    public void GiveDamage(Collision reciever, int amount)
    {
        GameObject enemyTank = reciever.transform.parent.gameObject;
        ControllerUniversal enemyScript = enemyTank.GetComponent<ControllerUniversal>();
        if(enemyScript != null) enemyScript.TakeDamage(amount);       
    }

    public float NextCheckPoint(Vector3 direction)
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 9;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(direction) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            return hit.distance;
        }
        return Mathf.Infinity;
    }
}
