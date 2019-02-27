using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRounds : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private int finishHits;
    [SerializeField] private Text rounds;

    void Start()
    {
        finishHits = 0;
        rounds.text = "" + finishHits;
    }

    public bool HitFinish(GameObject currentPlayer)
    {
        if (player == currentPlayer)
        {
            finishHits++;

            if (finishHits > 3)
                return true;
            else
                rounds.text = "" + finishHits;
        }

        return false;
    }
}
