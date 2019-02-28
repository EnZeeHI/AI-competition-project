using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [SerializeField] private int strCorner; // 0=>Straight 1=>left 2=>right
    [SerializeField] private int checkpointNr;

    public int CheckPointNr()
    {
        return checkpointNr;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetType() == typeof(BoxCollider))
        {
            Debug.Log(other + " hits checkpoint " + checkpointNr);
        }
    }
}
