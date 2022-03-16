using UnityEngine;
using System.Collections;

public class PuddingLocationCtrl : PuddingCtrl
{

	public GameObject pudding;

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Player") {

            if (check)
            {
				Destroy(this);
            }

            Vector3 pos = this.gameObject.GetComponent<Transform> ().position;
			pos += Vector3.up * 5;
			Instantiate (pudding, pos, Quaternion.identity);

        }
    }

}
