using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class gameManager : MonoBehaviour {
	public bool isMoving;
	public bool isAfterDrag;
	public bool isStop;
	public enum gameStatus
	{
		PlayerTime,
		GenTime,
		GameTime
	}

	public gameStatus status = gameStatus.PlayerTime;

	public static gameManager Instance { get; set; }

    private void Awake()
    {
		Screen.SetResolution(1000, 1200, false);
	}

    void Start () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
