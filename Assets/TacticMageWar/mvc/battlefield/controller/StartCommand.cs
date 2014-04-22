using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;

namespace mvc.battlefield
{
	public class StartCommand : Command 
	{

        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject contextView { get; set; }

        [Inject]
        public IGameFieldService gameFieldService { get; set; }

		public override void Execute ()
		{
            gameFieldService.InitField(contextView);
		}

	}
}

