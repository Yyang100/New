using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;
using UnityEngine.UI;
using strange.extensions.dispatcher.eventdispatcher.api;

public class LoginView : EventView {

	public InputField UserInput;
	public InputField PwInput;
	// Use this for initialization
    void Start()
	{
			
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void LoginClick()
	{
		string acc = UserInput.text;
		string pw = PwInput.text;
		if (string.IsNullOrEmpty (acc)) {
		} else if (string.IsNullOrEmpty (pw)) {
		} else {
			dispatcher.Dispatch (LoginViewEvent.LoginEvent, new LoginInfo (acc, pw));
		}
	}
	public void LoginRsp(IEvent e)
	{
		string data = e.data.ToString ();
		Debug.Log (data);
	}
}
