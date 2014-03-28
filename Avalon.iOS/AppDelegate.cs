﻿using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.ViewModels;
using Avalon.iOS.Presenters;

namespace Avalon.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : MvxApplicationDelegate
	{
		UIWindow _window;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			_window = new UIWindow(UIScreen.MainScreen.Bounds);

			var presenter = new Presenter(this, _window);
			var setup = new Setup(this, presenter);
			setup.Initialize();


			var startup = Mvx.Resolve<IMvxAppStart>();
			startup.Start();

			_window.MakeKeyAndVisible();

			return true;
		}
	}
}