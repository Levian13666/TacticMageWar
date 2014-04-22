using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;

namespace mvc.battlefield
{
	public class BattleFieldContext : MVCSContext 
	{

		public BattleFieldContext(MonoBehaviour view) : base(view) 
		{
		}

		public BattleFieldContext (MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
		{
		}

		protected override void addCoreComponents()
		{
			base.addCoreComponents();
			injectionBinder.Unbind<ICommandBinder>();
			injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
		}

		public override IContext Start()
		{
			base.Start();
            StartSignal startSignal = (StartSignal)injectionBinder.GetInstance<StartSignal>();
			startSignal.Dispatch();
			return this;
		}

		protected override void mapBindings()
		{
			Debug.Log("Binding...");

            injectionBinder.Bind<IGameFieldService>().To<GameFieldService>();
            commandBinder.Bind<StartSignal>().To<StartCommand>().Once();
		}

	}
}

