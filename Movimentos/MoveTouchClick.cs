using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTouchClick : MonoBehaviour {

	private Collider2D drag;
	public LayerMask layer;
	[SerializeField]
	bool clicked;
	Touch touch;

	Vector2 mousePos;
	public float moveSpeed = 0.2f;


	void Start()
	{
		drag = GetComponent<Collider2D>();
	}

	void Update()
	{
		//Click
		if (Input.GetMouseButton(0))
		{
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, layer.value);

			if (hit.collider != null)
			{
				clicked = true;
			}

			if (clicked)
			{
				transform.position = mousePos;
			}


		}
		else if (Input.GetMouseButtonUp(0))
		{
			clicked = false;
		}


		//Touch
		if (Input.touchCount > 0)
		{
			touch = Input.GetTouch(0);
			Vector2 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			RaycastHit2D hit = Physics2D.Raycast(wp, Vector2.zero, Mathf.Infinity, layer.value);

			if (hit.collider != null)
			{
				clicked = true;
			}

			if (clicked)
			{
				if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
				{
					Vector3 tPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
					transform.position = tPos;
				}
				if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
				{
					clicked = false;
				}
			}
		}
	}
}
