using UnityEngine;
using System.Collections;

public class EndingMoving : MonoBehaviour {

	private float h, v;
	private float rotSpeed = 100.0f, moveSpeed = 100.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");


		Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
		gameObject.transform.Translate(moveDir * moveSpeed * Time.deltaTime);
		gameObject.transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));
		gameObject.transform.Rotate(Vector3.right * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse Y"));
	}
}
