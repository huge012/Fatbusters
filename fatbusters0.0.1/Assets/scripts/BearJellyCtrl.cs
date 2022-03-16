using UnityEngine;
using System.Collections;

public class BearJellyCtrl : MonoBehaviour {

	public float MoveSpeed;
    private Animator anim;
	int hitCount, randomD, jumping;
	Vector3 dir;

    public GameObject sparkEffect;


    // Use this for initialization
    void Start () {
		MoveSpeed = Random.Range (5, 30); // 속도 랜덤
		hitCount = 0;
		dir = new Vector3 (1.0f, 0.0f, 0.0f);

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Transform>().position.y > 100)
        {
            jumping *= -1;
        }
        else if (GetComponent<Transform>().position.y < 0)
        {
            jumping *= -1;
        }
		dir += -Vector3.up * jumping * 50;
		transform.Translate (dir * MoveSpeed * Time.smoothDeltaTime);
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
