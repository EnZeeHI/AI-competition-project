using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    private Rigidbody rB;
    float moveSpeed = 0f;
    float rotSpeed = 0f;    
    float treadRotation = 0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    
    // Update is called once per frame
    void Update()
    {
        Move(Input.GetAxis("Vertical"));
        Rotate(Input.GetAxis("Horizontal") * 2);
        rB.AddForce(transform.forward * moveSpeed * 450);
        treadRotation += rotSpeed * 3;
        transform.eulerAngles = new Vector3(0, treadRotation, 0);
    }
    
    public void Move(float speed){
        moveSpeed = Mathf.Clamp(speed, -1.5f, 1.5f);
    }

    public void Rotate(float rot){
        rotSpeed = Mathf.Clamp(rot, -1.5f, 1.5f);
    }

    public decimal GetRotation(){
        return Math.Round(Convert.ToDecimal(transform.eulerAngles.y), 1);
    }
}