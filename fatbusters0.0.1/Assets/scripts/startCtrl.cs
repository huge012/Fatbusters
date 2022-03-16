using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startCtrl : MonoBehaviour {

    public Text fb;
    public Text click;
    public GameObject pudding;
    public GameObject sparkEffect;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetMouseButtonDown(0))
        {
            fb.color = new Color(255, 0, 0);
            click.enabled = !enabled;

            GameObject spark = (GameObject)Instantiate(sparkEffect, transform.position, Quaternion.identity);
            Destroy(spark, spark.GetComponent<ParticleSystem>().duration + 0.2f);
            Destroy(pudding);

            StartCoroutine(Example());
            
        }
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
