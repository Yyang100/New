using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		NetManager.Instance.RegisterListener (111,TestBoop);
		StartCoroutine (Beep());
	}
	IEnumerator Beep()
	{
		yield return new WaitForSeconds (1);
		Dictionary<string,string> str = new Dictionary<string, string> ();
		str ["id"] = "1";
		JSONObject js = JSONObject.Create (str);
		NetManager.Instance.SendMessage (222,js);
	}
	public void TestBoop(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Boop received: " + e.name + " " + e.data);

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
