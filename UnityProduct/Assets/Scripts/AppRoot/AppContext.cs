using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.context.api;

public class AppContext : MVCSContext {

	public AppContext(MonoBehaviour view):base(view)
	{
	}
	public AppContext(MonoBehaviour view,ContextStartupFlags flags): base(view ,flags)
	{
	}

	protected override void mapBindings ()
	{
		commandBinder.Bind (ContextEvent.START).To<StartAppCommand> ().Once ();
		crossContextBridge.Bind (AppCommandEvent.LoginRspCommand);
	}
}
