using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    private bool hasWinner = false;
    private Transform winner = null;

    [SerializeField] private Transform roundTrackers;

    [SerializeField] private GameObject winnerScreen;
    [SerializeField] private Text nameWinner;

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Tank") && other.GetType() == typeof(SphereCollider))
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

            if(winner != null)
            {
                Debug.Log(winner + " has won");
                winnerScreen.SetActive(true);
                nameWinner.text = winner.name;
            }
        }
    }
}
