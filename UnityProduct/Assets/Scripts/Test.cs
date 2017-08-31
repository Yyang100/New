using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using UnityEngine.UI;

public class Test : MonoBehaviour {

	public Text Tt;
	// Use this for initialization
	void Start () {
		NetManager.Instance.RegisterListener (MessageIDs.loginRsp,TestBoop);
		StartCoroutine (Beep());
	}
	IEnumerator Beep()
	{
		yield return new WaitForSeconds (1);
		Dictionary<string,string> str = new Dictionary<string, string> ();
		str ["acc"] = "11";
		str ["pw"] = "123";
		JSONObject js = JSONObject.Create (str);
		NetManager.Instance.SendMessage (MessageIDs.login,js);
	}
	public void TestBoop(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Boop received: " + e.name + " " + e.data);
		//Tt.text = e.name + ":" + e.data;
		if (e.data == null) { return; }

		Debug.Log(
			"#####################################################" +
			"THIS: " + e.data.GetField("this").str +
			"#####################################################"
		);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
