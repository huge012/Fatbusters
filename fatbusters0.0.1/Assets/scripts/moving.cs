using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class moving : MonoBehaviour 
{

    private float h, v, time;
	private float rotSpeed = 100.0f, moveSpeed = 100.0f;
	public int chol; // 콜레스테롤 수치
	private bool isHyperGravity;//과중력
	private int isClear;

	public Camera Camera1;
	public Camera Camera2;
	public Text cholText;


	void OnCollisionEnter(Collision coll)
	{
		if (coll.collider.tag == "Enermy") {
			chol += 50;
		}
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "choco") {
            chol += 50;
            moveSpeed = 10.0f;
			isHyperGravity = true;
            Debug.Log("hyper");
		}
	}

	void Start () {
		//PlayerPrefs.DeleteAll (); // 저장된 데이터 초기화
		chol = 50;
		time = 0.0f;
		isHyperGravity = false;
		Camera2.enabled = false;
		isClear = 1;
		int enermy = 24;
		PlayerPrefs.SetInt ("enermyCount", enermy);
		PlayerPrefs.Save ();

	}
	
	// Update is called once per frame
	void Update () {

        cholText.text = "CHOLESTEROL : " + chol.ToString();

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");


		Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
		gameObject.transform.Translate(moveDir * moveSpeed * Time.deltaTime);
        gameObject.transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));
        gameObject.transform.Rotate(Vector3.right * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse Y"));

        if (isHyperGravity == true) 
		{
			time += Time.deltaTime;
			if (time > 5.0f) 
			{
				time = 0.0f;
				moveSpeed = 100.0f;
				isHyperGravity = false;
			}
		}

        if(chol>=240)
        {
			PlayerPrefs.SetInt ("clear", isClear);
			PlayerPrefs.Save ();
			SceneChange ();
        }

		if (PlayerPrefs.GetInt ("enermyCount", 24) <= 0) 
		{
			isClear = 0;
			PlayerPrefs.SetInt ("clear", isClear);
			PlayerPrefs.Save ();
			SceneChange ();
		}

		if (Input.GetKey (KeyCode.M)) {
			Camera1.enabled = false;
			Camera2.enabled = true;
		} else {
			Camera1.enabled = true;
			Camera2.enabled = false;
		}

	}

	public void SceneChange()
	{
		SceneManager.LoadScene("end");
	}
}
