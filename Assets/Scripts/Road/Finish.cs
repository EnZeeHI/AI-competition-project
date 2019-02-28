using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    private bool hasWinner = false;
    private Transform winner = null;

    [SerializeField] private Transform roundTrackers;
    [SerializeField] private GameObject screen;
    [SerializeField] private Text textField;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Tank") && other.GetType() == typeof(BoxCollider))
        {
            foreach(Transform tracker in roundTrackers)
            {
                PlayerRounds playerRounds = tracker.GetComponent<PlayerRounds>();
                if (playerRounds != null)
                {
                    if (playerRounds.HitFinish(other.gameObject) && !hasWinner)
                    {
                        winner = tracker;
                        hasWinner = true;
                    }
                        
                }
            }

            if(winner!= null)
            {
                screen.SetActive(true);
                textField.text = winner.name;
                Debug.Log(winner.name + " has won");
            }
        }
    }
}
