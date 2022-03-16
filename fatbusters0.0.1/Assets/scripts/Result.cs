using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Result : MonoBehaviour {

	public Text cleared;
	public Text nowScr;
	public Text bestScr;

	private int isclear;
	private float nowTime, bestTime;

	// Use this for initialization
	void Start () {
		nowTime = PlayerPrefs.GetFloat ("tmpScore", 0);
		bestTime = PlayerPrefs.GetFloat ("bestScore", 0);
		isclear = PlayerPrefs.GetInt ("clear", 1);

		if (isclear == 0 && (nowTime < bestTime || bestTime == 0.0f)) 
		{
			bestTime = nowTime;
			PlayerPrefs.SetFloat ("bestScore", bestTime);
			PlayerPrefs.Save ();
		}

		var bestMinutes = bestTime / 60; //Divide the guiTime by sixty to get the minutes.
		var bestSeconds = bestTime % 60; //Use the euclidean division for the seconds.

		if (isclear != 0) {
			cleared.text = string.Format ("GAME OVER");
			nowScr.text = string.Format (" ");
		} else {
			var nowMinutes = nowTime / 60; //Divide the guiTime by sixty to get the minutes.
			var nowSeconds = nowTime % 60; //Use the euclidean division for the seconds.
			cleared.text = string.Format ("GAME CLEAR");
			nowScr.text = string.Format ("Now Score  {0:00} : {1:00}", nowMinutes, nowSeconds);
		}
		bestScr.text = string.Format("Best Score  {0:00} : {1:00}", bestMinutes, bestSeconds);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
