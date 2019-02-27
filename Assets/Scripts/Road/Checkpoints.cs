using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [SerializeField] private int checkpointNr;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other + " hits checkpoint " + checkpointNr);
    }
}
