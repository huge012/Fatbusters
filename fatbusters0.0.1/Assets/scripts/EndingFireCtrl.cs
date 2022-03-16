using UnityEngine;
using System.Collections;

public class EndingFireCtrl : MonoBehaviour {

	public GameObject Bullet;
	public Transform firePos;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0))
		{
			Fire();
		}
			
	}

	void Fire()
	{
			CreateBullet();
	}

	void CreateBullet()
	{
		Instantiate (Bullet, firePos.position, firePos.rotation);
	}

}
