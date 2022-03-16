using UnityEngine;
using System.Collections;

public class CandyCtrl : MonoBehaviour {

	private float MoveSpeed;
	int hitCount, randomD;
	Vector3 dir;

    public GameObject sparkEffect;

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Bullet") {
			hitCount++;
			Destroy (coll.gameObject);
			if (hitCount == 3)
            {
                Destroy (this.gameObject);

                GameObject spark = (GameObject)Instantiate(sparkEffect, transform.position, Quaternion.identity);
                Destroy(spark, spark.GetComponent<ParticleSystem>().duration + 0.2f);

				int restEnermy = PlayerPrefs.GetInt ("enermyCount", 24);
				restEnermy--;
				PlayerPrefs.SetInt ("enermyCount", restEnermy);
				PlayerPrefs.Save ();
            }
				
		}
	}

	// Use this for initialization
	void Start () {
		MoveSpeed = Random.Range (30, 100);
		hitCount = 0;
		dir = new Vector3 (0.0f, 0.0f, -0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (dir * 10 * MoveSpeed * Time.smoothDeltaTime);
	}
}
