using UnityEngine;
using System.Collections;

public class ChocolateCtrl : MonoBehaviour {

	int hitCount;

    public GameObject sparkEffect;

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Bullet") {

            hitCount++;
			Destroy (coll.gameObject);

			if (hitCount == 3)
            {
                Destroy(this.gameObject);

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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
