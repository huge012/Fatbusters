using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour {

	private int hitCount = 0;
	public GameObject sparkEffect;
	public GameObject pudding;

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Bullet")
		{
			hitCount++;
			Destroy(coll.gameObject);
			if (hitCount == 3)
			{
				GameObject spark = (GameObject)Instantiate(sparkEffect, transform.position, Quaternion.identity);
				Destroy(spark, spark.GetComponent<ParticleSystem>().duration + 0.2f);
				Destroy(pudding);

				StartCoroutine(Example());

			}

		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SceneChange()
	{
		SceneManager.LoadScene("gravityTest");
	}

	IEnumerator Example()
	{
		yield return new WaitForSeconds(3);
		SceneChange();
	}

}
