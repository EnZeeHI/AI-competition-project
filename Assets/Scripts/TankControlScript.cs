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
            turretRotation += Input.GetAxis("Turret") * 3;
            tankTurret.transform.eulerAngles = new Vector3(0, turretRotation, 0);
            treadRotation += Input.GetAxis("Horizontal") * 2;
            tankTreads.transform.eulerAngles = new Vector3(0, treadRotation, 0);
            moveSpeed = Input.GetAxis("Vertical") * -10;
            rB.velocity = tankTreads.transform.forward * moveSpeed;
            if (Input.GetKeyDown(KeyCode.Space)) {
                GameObject bullet = Instantiate(Projectile, shooty.transform.position, shooty.transform.rotation) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward);
            }
        }
    }
}