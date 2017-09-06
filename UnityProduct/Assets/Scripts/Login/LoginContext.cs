using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.context.api;

public class LoginContext : MVCSContext {

	public LoginContext(MonoBehaviour view):base(view)
	{
	}
	public LoginContext(MonoBehaviour view,ContextStartupFlags flags): base(view ,flags)
	{
	}

	protected override void mapBindings ()
	{
		mediationBinder.Bind<LoginView> ().To<LoginMediator> ();

		commandBinder.Bind (LoginCommandEvent.LoginReqCommand).To<LoginReqCommand>();
		commandBinder.Bind (AppCommandEvent.LoginRspCommand).To<LoginRspCommand>();
	}
}
