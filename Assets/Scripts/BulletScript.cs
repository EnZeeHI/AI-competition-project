using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    // Update is called once per frame
    void Update(){
        GetComponent<Rigidbody>().velocity = transform.up * 20;
    }

    void OnCollisionEnter(Collision collision){
        collision.gameObject.GetComponent<TankControlScript>().damage();
        Destroy(gameObject);
    }
}
