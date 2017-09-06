using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.command.impl;

public class LoginReqCommand : EventCommand {

	public override void Execute ()
	{
		LoginInfo info = (LoginInfo)evt.data;
		Dictionary<string,string> str = new Dictionary<string, string> ();
		str ["acc"] = info.acc;
		str ["pw"] = info.pw;
		JSONObject data = JSONObject.Create (str);
		NetManager.Instance.SendMessage (ClientReq.login,data);
	}
}
