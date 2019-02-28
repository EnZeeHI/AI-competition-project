using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [SerializeField] private int checkpointNr;

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetType() == typeof(SphereCollider))
            Debug.Log(other.name + " hits checkpoint " + checkpointNr);
    }
}
