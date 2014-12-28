using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

	public float speed;
	private int count;
	public Text countText;
	public Text winText;

	void Start (){
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void SetCountText(){
		countText.text = "Count: " + count.ToString();
		if (count >= 7) {
			winText.text = "You win";
		}
	}

	void FixedUpdate() {
		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal") ;
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		// change the speed of ball
		rigidbody.AddForce (movement*speed*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "pickup"){
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText ();
		}
	}
}
