using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControl : MonoBehaviour
{
    [SerializeField] private ControllerUniversal tcu;

    private void Start()
    {
        tcu = gameObject.GetComponent<ControllerUniversal>();
    }

    // Update is called once per frame
    void Update()
    {
        // Test movement
        if (Input.GetKey("up")) tcu.MoveForward();
        if (Input.GetKey("down")) tcu.MoveBackwards();
        if (Input.GetKey("left")) tcu.RotateLeft();
        if (Input.GetKey("right")) tcu.RotateRight();

        // Test firing
        if (Input.GetKeyDown(KeyCode.F)) tcu.PrimraryFire();

        // Test keypoint
        int layer = 1 << 9;
        if (Input.GetKeyDown(KeyCode.R)) tcu.NextCheckPoint(Vector3.forward * 5, layer);

        // Test rotation & Position
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Debug.Log("Current rotation: " + tcu.GetRotation());
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Debug.Log("Current position: " + tcu.GetPosition());

        // Test health
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Debug.Log("Current health: " + tcu.GetHealth());

        if (Input.GetKeyDown(KeyCode.Alpha4))
            tcu.NextCheckPoint(Vector3.forward * 5, layer);
    }
}
