using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    // Update is called once per frame
    void Update(){
        GetComponent<Rigidbody>().velocity = transform.up * 50;
    }

    void OnCollisionEnter(Collision collision){
        TankControlScript tcs = collision.gameObject.GetComponent<TankControlScript>();
        if (tcs!=null) tcs.damage();

        Destroy(gameObject);
    }
}
