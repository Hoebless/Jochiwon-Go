using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour {
			GameObject player;

		void Awake (){
			player = GameObject.FindGameObjectWithTag ("Player");
		}

		void OnTriggerStay2D(Collider2D other)
		{
		if (other.gameObject == player)
		{
			if(Input.GetKeyDown(KeyCode.T))
			 {
				Vector3 originPoint = new Vector3 ();
				originPoint.x = 0f;
				originPoint.y = -2f;
				originPoint.z = 0f;

				player.transform.position = originPoint;
			}

			}
		}

		void OnTriggerExit2D(Collider2D other)
		{

		}
	}

