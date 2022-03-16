using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class FireCtrl : MonoBehaviour {

	public GameObject Bullet;
	public Transform firePos;
    public Text tx;

    private int bulletCount;

	// Use this for initialization
	void Start () {
        bulletCount = 10;
	}

	// Update is called once per frame
	void Update () {

        tx.text = "BULLETS : "+bulletCount.ToString();

        if (Input.GetMouseButtonDown (0))
        {
            Fire();
        }
			

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Reload();
        }

	}

	void Fire()
	{
        if(bulletCount==0)
        {
            Debug.Log("총알끝. 재장전하셈");
        }
        else
        {
            CreateBullet();
            --bulletCount;
        }
        
	}

	void CreateBullet()
	{
		Instantiate (Bullet, firePos.position, firePos.rotation);
	}

    void Reload()
    {
        bulletCount += 10;
    }
}