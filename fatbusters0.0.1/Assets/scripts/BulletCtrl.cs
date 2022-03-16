using UnityEngine;
using System.Collections;

public class BulletCtrl : MonoBehaviour {

	public int damage = 20;
	public float speed = 1000.0f;
    private Renderer rd;

    private Color[] colors = new Color[5];
    public GameObject[] sparkEffect = new GameObject[5];

    private int val;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddForce (transform.up * speed);

        colors[0] = Color.red;
        colors[1] = Color.green;
        colors[2] = Color.blue;
        colors[3] = Color.white;
        colors[4] = Color.black;

        rd = GetComponent<Renderer>();
        val = Random.Range(0, colors.Length);
        rd.material.color = colors[val];


    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            GameObject spark = (GameObject)Instantiate(sparkEffect[val], transform.position, Quaternion.identity);
            Destroy(spark, spark.GetComponent<ParticleSystem>().duration + 0.2f);

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () { 


	}
}