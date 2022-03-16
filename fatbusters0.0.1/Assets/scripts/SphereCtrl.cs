using UnityEngine;
using System.Collections;

public class SphereCtrl : MonoBehaviour {


	void OnCollisionEnter(Collision coll)
	{
		if (coll.collider.tag == "Bullet") {


            Destroy (coll.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
