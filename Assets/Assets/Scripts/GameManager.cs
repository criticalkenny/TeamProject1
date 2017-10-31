using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	public int score = 0;
	public int timeScore = 0;
	public int coolers = 0;
	public bool gotCig = false;
	public bool gotLight = false;
	public bool caught = false;
	private float restartTimer = 2.0f;
	private float toReset = 0.0f;

	public static GameManager instance;

	public PlayerMove player;
	public GameObject playerObj;

	void Start ()
	{
		Cursor.visible = false;
		score = 0;
		timeScore = 0;
		coolers = 0;
	}

	void Update () 
	{
		if (caught == true)
		{
			GameOver();
		}

		if (Input.GetKeyDown(KeyCode.R) == true) 
		{
			SceneManager.LoadScene (0);
		}
	}

	void GameOver()
	{
		Destroy(playerObj);
		toReset = restartTimer + Time.time;
		Restart();
	}

	void Restart()
	{
		if (Time.time > toReset)
		{
			SceneManager.LoadScene (0);
		}
	}
}
