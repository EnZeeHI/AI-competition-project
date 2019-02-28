using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    private bool hasWinner = false;
    private Transform winner = null;

    [SerializeField] private Transform roundTrackers;

<<<<<<< HEAD
    void Update()
    {
        
    }

=======
    [SerializeField] private GameObject winnerScreen;
    [SerializeField] private Text nameWinner;
    
>>>>>>> parent of 836b4ae... Revert "Redo Road"
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Tank"))
        {
            foreach(Transform tracker in roundTrackers)
            {
                PlayerRounds playerRounds = tracker.GetComponent<PlayerRounds>();
                if (playerRounds != null)
                {
                    if (playerRounds.HitFinish(other.gameObject))
                    {
                        winner = tracker;
                        return;
                    }
                        
                }
            }

            if(winner!= null)
            {
                Debug.Log(winner + " has won");
            }
        }
    }
}
