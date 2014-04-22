using System;
using UnityEngine;
using strange.extensions.context.impl;

namespace mvc.battlefield
{
	public class BattleFieldRoot : ContextView
	{
		
		void Awake()
		{
			context = new BattleFieldContext(this);
		}

	}
}

