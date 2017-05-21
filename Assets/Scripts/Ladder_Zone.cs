using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder_Zone : MonoBehaviour {

    private Player thePlayer;

	void Start ()
    {
        thePlayer = FindObjectOfType<Player>();
	}
	
	void OnTriggerEnter2D (Collider2D other)
    {
		if(other.name == "Player")
        {
            thePlayer.onLadder = true;
        }
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            thePlayer.onLadder = false;
        }
    }
}
