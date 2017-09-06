using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;

public class LoginMediator : EventMediator {

	[Inject]
	public LoginView view { get ; set ;}

	public override void OnRegister ()
	{
		UpdateListeners (true);
	}
	public override void OnRemove ()
	{
		UpdateListeners (false);
	}
	private void UpdateListeners(bool value)
	{
		view.dispatcher.UpdateListener (value,LoginViewEvent.LoginEvent,LoginReqAction);

		dispatcher.UpdateListener (value,LoginCommandEvent.LoginRspCommand,LoginRspAction);
	}

	void LoginReqAction(IEvent e)
	{
		dispatcher.Dispatch (LoginCommandEvent.LoginReqCommand,e);
	}

	void LoginRspAction(IEvent e)
	{
		view.LoginRsp (e);
	}
}
