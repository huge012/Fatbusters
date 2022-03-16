using UnityEngine;
using System.Collections;

public class CameraLotate : MonoBehaviour {
	private float rotSpeed = 100.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));
	}
}
