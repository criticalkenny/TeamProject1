using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour 
{
	public bool attacking = false;
	private bool canAtk = true;
	private float attackDur = 1.0f;
	private float hitboxDur = 0.5f;
	private float hitboxTo = 0.0f;
	private float toAtk = 0.0f;

	public static PlayerAttack instance;

	void Update ()
	{
		if (Input.GetButton ("Fire1") == true) 
		{
			if (canAtk == true && attacking == false) 
			{
				attacking = true;
				canAtk = false;
				toAtk = attackDur + Time.time;
				hitboxTo = hitboxDur + Time.time;
			}
		}

		if (Input.GetButtonUp ("Fire1") == true && Time.time > toAtk) 
		{
			canAtk = true;
		}

		if (Time.time > hitboxTo) 
		{
			attacking = false;
		}
	}

	void OnTriggerEnter (Collider other)
	{

	}
}
