using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControlScript : MonoBehaviour {

    public GameObject tankTreads;
    public GameObject tankTurret;
    public GameObject shooty;
    private GameObject bullet;
    public GameObject Projectile;
    private Rigidbody rB;
    float turretRotation = 0f;
    float treadRotation = 0f;
    float moveSpeed = 0f;
    public bool control = false;

    public void damage(){
        Debug.Log("ouch");
    }

    // Start is called before the first frame update
    void Start(){
        rB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        if (control == true){
<<<<<<< HEAD
            turretRotation += Input.GetAxis("Turret") * 3;
            tankTurret.transform.eulerAngles = new Vector3(0, turretRotation, 0);
            treadRotation += Input.GetAxis("Horizontal") * 2;
            tankTreads.transform.eulerAngles = new Vector3(0, treadRotation, 0);
            moveSpeed = Input.GetAxis("Vertical") * -10;
            rB.velocity = tankTreads.transform.forward * moveSpeed;
=======
            treadRotation += Input.GetAxis("Horizontal") * 3;

            moveSpeed = Input.GetAxis("Vertical") * 450;
            rB.AddForce(transform.forward * moveSpeed);

>>>>>>> master
            if (Input.GetKeyDown(KeyCode.Space)) {
                GameObject bullet = Instantiate(Projectile, shooty.transform.position, shooty.transform.rotation) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward);
            }
        }
    }
<<<<<<< HEAD
=======
    public void MoveBackwards(Rigidbody Body){
        rB.AddForce(-transform.forward * moveSpeed);
        // rB.velocity = transform.forward * 10;
    }
    public void RotateLeft(Rigidbody Body){
        // treadRotation += 3;
        rB.AddTorque(transform.up * -10 * Input.GetAxis("Horizontal"));
    }
    public void RotateRight(Rigidbody Body){
        // treadRotation += -3;
        rB.AddTorque(transform.up * 10 * Input.GetAxis("Horizontal"));
    }

    // public void primraryFire(){   
    //     if (canShoot == true){
    //         GameObject bullet = Instantiate(Projectile, shooty.transform.position, shooty.transform.rotation) as GameObject;
    //         bullet.GetComponent<Rigidbody>().AddForce(transform.forward);
    //         canShoot = false;
    //     }
    // }


    // // script that makes the gameobject this script is attached to take damage
    // public void TakeDamage (int amount){
    //     Damaged = true;
    //     Debug.Log('o');
    //     CurrentHealth = CurrentHealth - amount;
    //     if (CurrentHealth <=0 && !IsDead)
    //     {
    //         Death();
    //     }
    // }
   
    // // destoys the dead tank
    // void Death(){
    //     IsDead = true;
    //     Destroy(gameObject);
    // }
   
    // // gives damage to any tank that the projectile hits
    // public void GiveDamage(Collision Reciever, int amount){
    //     EnemyTank = Reciever.gameObject;
    //     EnemyScript = EnemyTank.GetComponent<TankControllerUniversal>();
    //     EnemyScript.TakeDamage(amount);
       
    // }

>>>>>>> master
}