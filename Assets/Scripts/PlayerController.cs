using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text cntText;
	public Text winText;

	private Rigidbody rb;
	private int cnt;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		cnt = 0;
		SetCntText();
		winText.text = " ";
	}
		
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		//Destroy (other.gameObject);
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			cnt++;
			SetCntText();
		}
	}

	void SetCntText()
	{
		cntText.text = "Count: " + cnt.ToString ();

		if (cnt >= 11) 
		{
			winText.text = "You Win!";
		}
	}

}//end