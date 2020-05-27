using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class objectN : MonoBehaviour
{

	private Vector3 pos;
	private Vector3 objPos = new Vector3(0, 0, 0);
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		MoveManager();

		RotateManager();

		isReload();

	}

	private void MoveManager()
	{
		if (gameObject.tag == "currentObject")
		{
			if (!gameManager.Instance.isMoving)
			{
				GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
			}
			
			if (Input.GetMouseButtonUp(0)&& gameManager.Instance.isAfterDrag)
			{
				if (!(Input.mousePosition.y < 100))
				{
					gameManager.Instance.isMoving = true;
					GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
					gameManager.Instance.status = gameManager.gameStatus.GameTime;
				}
			}
		}
	}

	private void RotateManager()
	{
		if (gameObject.tag == "currentObject")
		{
			if (Input.GetMouseButton(1))
			{
				Rotate();
			}
		}
			
	}


	public void Rotate()
	{
		GameObject go = GameObject.FindGameObjectWithTag("currentObject");
		go.transform.Rotate(Vector3.forward*3);
	}

	private void OnMouseDrag()
	{
		if (gameObject.tag == "currentObject")
		{
            pos = Camera.main.ScreenToWorldPoint(new Vector3(Mathf.Clamp(Input.mousePosition.x, 0,1000), Input.mousePosition.y, 1));
			transform.position = pos;
		}
			
	}
	private void OnMouseEnter()
	{
		gameManager.Instance.isAfterDrag = true;
	}

	private void OnMouseExit()
	{
		gameManager.Instance.isAfterDrag = false;

	}


	void OnCollisionStay2D(Collision2D col)
	{
		if (gameObject.tag == "currentObject")
		{
			if (gameObject.GetComponent<Rigidbody2D>().velocity.y < 0.001f && gameManager.Instance.status == gameManager.gameStatus.GameTime)
			{
				if (gameManager.Instance.isMoving)
					gameObject.tag = "object";
				gameManager.Instance.status = gameManager.gameStatus.GenTime;
			}
		}
	}

	//void OnCollisionEnter2D(Collision2D col)
	//{
	//	if (gameObject.tag == "object" && col.collider.tag == "UI")
	//	{
	//		SceneManager.LoadScene(0);
	//	}
	//}

	void isReload()
    {
		if (gameObject.transform.position.y < -3.7f )
		{
				SceneManager.LoadScene(0);
		}
    }
}
