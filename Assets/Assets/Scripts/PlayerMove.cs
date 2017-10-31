using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour 
{
	private Vector3 movement = Vector3.zero;
	private bool sprinting = false;

	public float speed = 0.0f;
	public float sprintSpd = 0.0f;

	private bool canPause = true;
	private bool paused = false;

	public static PlayerMove instance;
	public GameObject arm;

	public bool isLeaning = false;

	/*public float leanSpd = 100f;
	public float maxAngle = 45f;
	public Transform _Pivot;
	private float curAngle = 0f;

	void Awake ()
	{
		if (_Pivot == null && transform.parent != null) _Pivot = transform.parent;
	}*/


	void Update () 
	{
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveLateral = Input.GetAxisRaw ("Vertical");

		movement = new Vector3 (moveHorizontal, 0.0f, moveLateral);
		movement = transform.TransformDirection (movement);

		Pause ();
		Sprint ();
		if (paused == false) 
		{
			if (isLeaning == false) 
			{
				Move ();
			}
			if (isLeaning == true) 
			{
				GetComponent<Rigidbody> ().velocity = Vector3.zero;
			}
		}

	}

	void Move()
	{
		if (sprinting == true) 
		{
			GetComponent<Rigidbody> ().velocity = movement * sprintSpd;
		} else
		{
			GetComponent<Rigidbody>().velocity = movement * speed;
		}
	}

	void Sprint()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift) == true)
		{
			sprinting = true;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift) == true) 
		{
			sprinting = false;
		}
	}


	/*void LeanLeft()
	{
		if(Input.GetKeyDown(KeyCode.Q)) 
		{
			isLeaning = true;
			curAngle = Mathf.MoveTowardsAngle(curAngle, maxAngle, leanSpd * Time.deltaTime);

		}
		if(Input.GetKeyUp(KeyCode.Q)) 
		{
			isLeaning = false;
			curAngle = Mathf.MoveTowardsAngle(curAngle, 0f,leanSpd * Time.deltaTime);
		}
	}

	void LeanRight()
	{
		if(Input.GetKeyDown(KeyCode.E)) 
		{
			isLeaning = true;
			curAngle = Mathf.MoveTowardsAngle(curAngle, -maxAngle, speed * Time.deltaTime);

		}
		if(Input.GetKeyUp(KeyCode.E)) 
		{
			isLeaning = false;
			curAngle = Mathf.MoveTowardsAngle(curAngle, 0f, leanSpd * Time.deltaTime);
		}

	}


	void Lean()
	{
		if (Input.GetKeyDown (KeyCode.E)) 
		{
			isLeaning = true;
			curAngle = Mathf.MoveTowardsAngle (curAngle, -maxAngle, speed * Time.deltaTime);
		} else if (Input.GetKeyDown (KeyCode.Q)) 
		{
			isLeaning = true;
			curAngle = Mathf.MoveTowardsAngle (curAngle, maxAngle, leanSpd * Time.deltaTime);
		} else 
		{
			isLeaning = false;
			curAngle = Mathf.MoveTowardsAngle(curAngle, 0f, leanSpd * Time.deltaTime);
		}
		_Pivot.transform.localRotation = Quaternion.AngleAxis(curAngle, Vector3.forward);
	}*/

	void Pause()
	{
		if (Input.GetKeyDown(KeyCode.Return) == true && canPause == true)
		{
			if (paused == false) 
			{
				paused = true;
				canPause = false;
				GetComponent<Rigidbody> ().velocity = Vector3.zero;
				return;
			}
			if (paused == true) 
			{
				paused = false;
				canPause = false;
				return;
			}
		}
		if (Input.GetKeyUp (KeyCode.Return) == true) 
		{
			canPause = true;
		}
	}
}
