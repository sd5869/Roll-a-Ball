﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	private int count;
	public GUIText countText;
	public GUIText winText;
	void Start()
	{
		count = 0;
		setCountText();
		winText.text = "";
	}
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement =new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().AddForce(movement*speed*Time.deltaTime);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Pickup") {
			other.gameObject.SetActive(false);
			count+=1;
			setCountText();
		}

	}
	void setCountText()
	{
		countText.text = "Score:" + count.ToString ();
		if (count == 16) {
			winText.text="You Win";
		}
	}
}
