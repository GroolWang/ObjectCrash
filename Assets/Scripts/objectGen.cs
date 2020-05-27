using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class objectGen : MonoBehaviour {
	public GameObject[] objList;
	private int num;
	private Vector3 pos;
	// Use this for initialization
	void Start () {
		 ObjGen();
	}
	
	// Update is called once per frame
	void Update () {
		IsGen();
	}

	public void ObjGen()
	{
		num = Random.Range(0, 7);
		pos = transform.position;
		pos.z++;
		GameObject go = Instantiate(objList[num], pos, Quaternion.identity);
		go.tag = "currentObject";
	}

	private void IsGen()
	{
		if (!GameObject.FindGameObjectWithTag("currentObject") && gameManager.Instance.status == gameManager.gameStatus.GenTime)
		{
			MoveCamera();
			ObjGen();
			gameManager.Instance.isMoving = false;
			gameManager.Instance.isAfterDrag = false;
			gameManager.Instance.isStop = false;
			gameManager.Instance.status = gameManager.gameStatus.PlayerTime;
		}
		
	}

	private void MoveCamera()
	{
		GameObject[] go = GameObject.FindGameObjectsWithTag("object");
		foreach (GameObject item in go)
		{
			if (Mathf.Abs(item.transform.position.y - transform.position.y) < 1.5f)
			{
				Vector3 goNext = transform.position;
				goNext.y += 1.5f;
				transform.position = goNext;
			}
		}
	}
}
