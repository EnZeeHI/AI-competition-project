﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControlScript : MonoBehaviour {

    // defining possible tank actions
    public bool LeftBodyRotation;
    public bool RightBodyRotation;
    public bool ForwardBodyMovement;
    public bool BackwardsBodyMovement;
    public bool FirePrimary;
    // public bool FireSecondary;
    public bool LeftTurretRotation;
    public bool RightTurretRotation;
    
    // defining gameobjects and other things that take parameters
    public GameObject tankTreads;
    public GameObject tankTurret;
    public GameObject shooty;
    private GameObject bullet;
    public GameObject Projectile;
    private Rigidbody rB;
    float turretRotation = 0f;
    float treadRotation = 0f;
    float moveSpeed = 0f;
    private bool canShoot = true;

    // bool for testing/debug purposes
    public bool aiControl = false;

    // timer int
    int shootTimer = 0;

    public void damage(){
        Debug.Log("ouch");
    }

    // Start is called before the first frame update
    void Start(){
        rB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        if (aiControl == false){
            turretRotation += Input.GetAxis("Turret") * 3;
            tankTurret.transform.eulerAngles = new Vector3(0, turretRotation, 0);

            treadRotation += Input.GetAxis("Horizontal") * 5;
            tankTreads.transform.eulerAngles = new Vector3(0, treadRotation, 0);

            moveSpeed = Input.GetAxis("Vertical") * 600;
            rB.AddForce(tankTreads.transform.forward * moveSpeed);

            if (Input.GetKeyDown(KeyCode.Space)) {
                GameObject bullet = Instantiate(Projectile, shooty.transform.position, shooty.transform.rotation) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward);
            }
        }
        if (aiControl){
            Debug.Log(shootTimer);
            if (shootTimer > 60){
                canShoot = true;
                shootTimer = 0;
                Debug.Log(shootTimer);
            }
            if (LeftBodyRotation) {
                tankTreads.transform.eulerAngles += new Vector3(0, -2, 0);
            }
            if (RightBodyRotation) {
                tankTreads.transform.eulerAngles += new Vector3(0, 2, 0);
            }
            if (ForwardBodyMovement) {
                rB.velocity = tankTreads.transform.forward * -10;
            }
            if (BackwardsBodyMovement) {
                rB.velocity = tankTreads.transform.forward * 10;
            }
            if (FirePrimary) {
                if (canShoot){
                    GameObject bullet = Instantiate(Projectile, shooty.transform.position, shooty.transform.rotation) as GameObject;
                    bullet.GetComponent<Rigidbody>().AddForce(transform.forward);
                    canShoot = false;
                    Debug.Log(canShoot);
                }
            }
            if (canShoot = false){
                shootTimer += 1;
            }
            if (LeftTurretRotation) {
                tankTurret.transform.eulerAngles += new Vector3(0, -3, 0);
            }
            if (RightTurretRotation) {
                tankTurret.transform.eulerAngles += new Vector3(0, 3, 0);
            }
        }
    }
}