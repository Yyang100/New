using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.impl;

public class LoginRoot : ContextView {

	void Awake()
	{
		context = new LoginContext (this);
	}
}
