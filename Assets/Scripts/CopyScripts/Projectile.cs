using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // accesing definitions and variables from TankControllerUniversal Script
    private GameObject shootingTank;
    public int attackDamage;

    private bool shooting;
    private Vector3 start, end;
    private float cannonSpeed;
    [SerializeField] private float distance;
    private float startTime;
    private float journeyLength;

    public void Update()
    {
        if (shooting)
        {
            // Distance moved = time * speed.
            float distCovered = (Time.time - startTime) * cannonSpeed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(start, end, fracJourney);

            if (transform.position == end) Destroy(gameObject);
        }
    }

    public void ShootCannon(GameObject tank, float speed, Vector3 direction)
    {
        shootingTank = tank;
        //Rigidbody cannonBody = gameObject.GetComponent<Rigidbody>();
        //cannonBody.AddForce(transform.forward * speed);

        shooting = true;
        start = transform.position;
        end = tank.transform.position + direction;

        cannonSpeed = speed;
        startTime = Time.time;
        journeyLength = Vector3.Distance(start, end);
    }

    void OnCollisionEnter(Collision agentCollider) 
    {
        if (agentCollider.gameObject != shootingTank)
        {
            if (agentCollider.gameObject.tag == "Tank")
            {
                ControllerUniversal tankScript = agentCollider.gameObject.GetComponent<ControllerUniversal>();
                tankScript.GiveDamage(agentCollider, attackDamage);
            }

            Destroy(gameObject);
        }
    }
}
