using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMachteld : MonoBehaviour
{
    private TankController tank;
    private float moveSpeed = 1;
    private float rotationSpeed = 1.5f;

    private int checkpointLayer = 1 << 9;
    private int wallLayer = 1 << 10;
    private int finishLayer = 1 << 11;

    private bool turning = false;
    private bool turningToFront = false;
    private float maxRotation = 0;
    private float rotation = 0;
    private float startRotation = 0;

    private List<Collider> passed = new List<Collider>();
    private bool check = false;
    private RaycastHit currentCheckPoint;

    void Start()
    {
        tank = gameObject.GetComponent<TankController>();
    }

    void Update()
    {
        // If not turning the tank will move ahead
        if (!turning) Move();
        // If turning to front
        //else if(turningToFront) TurnToRightDirection();
        // If turning
        else Turn();

        FindFinish();
    }

    private void Move()
    {
        RaycastHit frontWall = tank.CastRayCast(Vector3.forward, wallLayer);
        RaycastHit frontCheckPoint = tank.CastRayCast(new Vector3(0, 0, 1), checkpointLayer);
        RaycastHit backCheckPoint = tank.CastRayCast(new Vector3(0, 0, -1), checkpointLayer);

        if (passed.Contains(frontCheckPoint.collider))
        {
            maxRotation = 90;
            FindRotateDirection(true);
            startRotation = tank.GetRotation();
            turning = true;
            turningToFront = true;
        }
        else if (!passed.Contains(backCheckPoint.collider) && backCheckPoint.distance < 5)
        {
            if (currentCheckPoint.transform == backCheckPoint.transform)
            {
                passed.Add(backCheckPoint.collider);
            }

            currentCheckPoint = frontCheckPoint;
        }

        if (frontWall.distance < 18)
        {
            if (frontWall.distance < 1f) FindRotateDirection(false);
            else FindRotateDirection(true);

            maxRotation = 45;
            startRotation = tank.GetRotation();
            turning = true;
        }
        else
        {
            tank.Move(moveSpeed);
        }
    }

    private void Turn()
    {
        rotation = tank.GetRotation() - startRotation;
        if(rotation > maxRotation || rotation < -maxRotation)
        {
            tank.Rotate(0);
            turning = false;
            Debug.Log("Stop turning");
        }
    }

    private void TurnToRightDirection()
    {
        rotation = tank.GetRotation() - startRotation;
        RaycastHit frontCheckPoint = tank.CastRayCast(new Vector3(0, 0, 1), checkpointLayer);
        RaycastHit backCheckPoint = tank.CastRayCast(new Vector3(0, 0, -1), checkpointLayer);

        if ((!passed.Contains(frontCheckPoint.collider) && (rotation > maxRotation || rotation < -maxRotation)))
        {
            tank.Rotate(-rotation);
            turningToFront = false;
            Debug.Log("Stop turning from front");
        }
    }

    private void FindFinish()
    {
        RaycastHit finish = tank.CastRayCast(new Vector3(0, 0, -1), finishLayer);
        if (finish.distance < 5 && finish.distance > 0)
        {
            Debug.Log(finish.distance);
            passed = new List<Collider>();
            Debug.Log("Round");
        }
    }

    private void FindRotateDirection(bool front)
    {
        float z = 1;
        if (!front) z = -1;
        Debug.Log("z" + z);

        RaycastHit left = tank.CastRayCast(new Vector3(-0.5f, 0, z), checkpointLayer);
        RaycastHit right = tank.CastRayCast(new Vector3(0.5f, 0, z), checkpointLayer);

        if (left.distance < right.distance)
            tank.Rotate(rotationSpeed * -1);
        else
            tank.Rotate(rotationSpeed * 1);

        if (!front) tank.Move(-moveSpeed);
    }


}
