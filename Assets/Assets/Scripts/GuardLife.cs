using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardLife : MonoBehaviour 
{
	private bool active = true;

	private float blinkTime = 0.5f;
	private float toBlink = 0.0f;
	public bool inBlink = false;
	public int blinkCount = 0;

	public GameObject player;
	public PlayerAttack playerAtk;
	public MeshRenderer render;
	public GameObject light;

	void Update () 
	{
		if (inBlink == true) 
		{
			render.enabled = false;
		} else if (inBlink == false) 
		{
			render.enabled = true;
		}

		if (active == false)
		{
			Death();
			light.SetActive(false);
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.tag == ("Arm") && playerAtk.attacking == true)
			{
				active = false;
				Death ();
			}
	}

	void Death()
	{
		if (blinkCount < 4) 
		{
			if (inBlink == false) 
			{
				toBlink = blinkTime + Time.time;
				inBlink = true;
				blinkCount++;
			}
		}
		if (Time.time > toBlink && inBlink == true) 
		{
			inBlink = false;
		}
		if (blinkCount >= 4)
		{
			Destroy (gameObject);
		}

	}
}
