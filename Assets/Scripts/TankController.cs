using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    private Rigidbody rB;
    float moveSpeed = 0f;
    float rotSpeed = 0f;    
    public float treadRotation = 0f;
    private bool canFire = false;
    private int fireTimer = 0;
    private int hitTimer = 0;
    // private bool stop = true;

    public GameObject shooty;
    public GameObject Projectile;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    
    // Update is called once per frame
    void Update()
    {
        rB.AddForce(transform.forward * moveSpeed * 450);
        treadRotation += rotSpeed * 3;
        transform.eulerAngles = new Vector3(0, treadRotation, 0);
        if(hitTimer > 0){
            hitTimer -= 1;
            Rotate(0);
            Move(0);
        }
        if (fireTimer > 60)
        {
            canFire = true;
            fireTimer = 0;
        }
        if (canFire == false){
            fireTimer += 1;
        }
        // if (stop == true){
        //     rotSpeed = 0f;
        // }
        // stop = true;
        Primaryfire(25);
    }

    public void Move(float speed)
    {
        if(hitTimer == 0){
            moveSpeed = Mathf.Clamp(speed, -1.5f, 1.5f);
        }
    }

    public void Rotate(float rot)
    {
        if(hitTimer == 0){
            rotSpeed = Mathf.Clamp(rot, -1.5f, 1.5f);
        }
        // stop = false;
    }

    public float GetRotation()
    {
        return transform.eulerAngles.y;
    }

    public void Primaryfire(int speed)
    {
        if (canFire == true)
        {
            GameObject bullet = Instantiate(Projectile, shooty.transform.position, shooty.transform.rotation) as GameObject;
            if (bullet != null){
                bullet.GetComponent<Rigidbody>().velocity = transform.forward * speed;
            }
            canFire = false;
        }
    }

    public void GetHit(){
        hitTimer = 10;
    }

    public RaycastHit CastRayCast(Vector3 direction, int layerMask)
    { // Call function to check surroundings of tank, give direction and layer 

        // Bit shift the index of the layer (8) to get a bit mask
        // int layerMask = 1 << 9; // Because we suddenly need to detect more than just the checkpoints

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(direction) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        return hit;

        // Notice: returns null if nothing hit
    }
}