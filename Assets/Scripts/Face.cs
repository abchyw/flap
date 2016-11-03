using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Face : MonoBehaviour {

	private Text slapCountingTxt;
	private Text timerText;

	private int target = 30;
	private float winningBuffer = 1;

	private int count = 0;

	private bool slappingStarted = false;
	private float timeStarted;
	private float timeFinished;
	private bool overSlapped = false;
	private bool won = false;

	// Use this for initialization
	void Start () {
		slapCountingTxt = GameObject.Find ("SlapCountingText").GetComponent<Text> ();
		timerText = GameObject.Find ("TimerText").GetComponent<Text> ();
		slapCountingTxt.text = count.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (overSlapped || won) {
			return;
		}
		if (timeFinished > 0) {
			float period = Time.time - timeFinished;
			if (period > winningBuffer) {
				timerText.text = "~Finished~ Time used: " +  (timeFinished - timeStarted);
				won = true;
				return;
			}
		}
		if (slappingStarted) {
			float timePassed = Time.time - timeStarted;
			timerText.text = "Time used: " + timePassed;
		}
	}

	public void Slap(){
		if (overSlapped || won) {
			return;
		}

		count = count + 1;
		if (count == 1) {
			slappingStarted = true;
			timeStarted = Time.time;
			Debug.Log ("timeStarted" + timeStarted);
		}
		if (count < 10) {
			slapCountingTxt.text = count.ToString();
		}
		else if (count < target) {
			slapCountingTxt.text = "頑張れ!!!";
		}
		else if (count == target) {
			timeFinished = Time.time;
		}
		else if (count > target) {
			overSlapped = true;
			timerText.text = "You Lose!";
		}
	}
}
