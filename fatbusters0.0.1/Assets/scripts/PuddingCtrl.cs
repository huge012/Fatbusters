using UnityEngine;
using System.Collections;

public class PuddingCtrl : MonoBehaviour {

	int hitCount;
	public float time;
    public static bool check = false;

    public GameObject sparkEffect;

    private Animator anim;



	// Use this for initialization
	void Start () {
		hitCount = 0;
		time = 0.0f;

        anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= 30.0f) 
		{
			//Destroy (this.gameObject);
		}

	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            hitCount++;
            Destroy(coll.gameObject);
            if (hitCount == 3)
            {
                Destroy(this.gameObject);
                check = true;

                GameObject spark = (GameObject)Instantiate(sparkEffect, transform.position, Quaternion.identity);
                Destroy(spark, spark.GetComponent<ParticleSystem>().duration + 0.2f);

				int restEnermy = PlayerPrefs.GetInt ("enermyCount", 24);
				restEnermy--;
				PlayerPrefs.SetInt ("enermyCount", restEnermy);
				PlayerPrefs.Save ();
            }
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            anim.enabled = enabled;

        }
    }
}
