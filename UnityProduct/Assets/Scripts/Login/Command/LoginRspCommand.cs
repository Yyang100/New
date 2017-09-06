using System;
using strange.extensions.command.impl;


public class LoginRspCommand :EventCommand
{
	public override void Execute ()
	{
		dispatcher.Dispatch (LoginCommandEvent.LoginRspCommand,evt);
	}		
}

