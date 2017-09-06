using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.impl;

public class AppRoot : ContextView {

	void Awake()
	{
		context = new AppContext (this);
	}
}
