using System;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Avalon.Core.Interfaces.ViewModels;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore.Platform;
using Avalon.Core.ViewModels;
using Cirrious.CrossCore;

namespace Avalon.iOS.Presenters
{
	public class Presenter : MvxTouchViewPresenter, IViewModelCloser
	{
		/// <summary>
		/// the application's window.  We hang onto this so we can use it later
		/// </summary>
		private UIWindow _window;
		private IMvxTouchViewCreator _viewCreator;


		protected IMvxTouchViewCreator ViewCreator
		{
			get { return _viewCreator ?? (_viewCreator = Mvx.Resolve<IMvxTouchViewCreator>()); }
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="Presenter"/> class.
		/// </summary>
		/// <param name="applicationDelegate">Application delegate.</param>
		/// <param name="window">Window.</param>
		public Presenter(UIApplicationDelegate applicationDelegate, UIWindow window) :
			base(applicationDelegate, window)
		{
			// specialized construction logic goes here
			_window = window;
		}

		public override void Show(MvxViewModelRequest request)
		{
			if (request.PresentationValues != null)
			{
				if (request.PresentationValues.ContainsKey(PresentationBundleFlagKeys.ClearStack))
				{
					clearStackAndNavigate(request);

					return;
				}
			}

			base.Show(request);
		}

		private void clearStackAndNavigate(MvxViewModelRequest request)
		{
			var nextViewController = (UIViewController)ViewCreator.CreateView(request);

			if (MasterNavigationController.TopViewController.GetType() != nextViewController.GetType())
			{
				MasterNavigationController.PopToRootViewController(false);
				MasterNavigationController.ViewControllers = new UIViewController[] { nextViewController };
			}
		}

		#region IViewModelCloser implementation

		/// <summary>
		/// close the current view and pop back to the previous one
		/// </summary>
		/// <param name="viewModel">View model.</param>
		public void RequestClose (IMvxViewModel viewModel)
		{
			// get the top view on the navigation controller
			var view = MasterNavigationController.TopViewController as IMvxTouchView;

			// if there is no top view (can this really happen?) then log an error
			if (view == null)
			{
				MvxTrace.Trace("request close ignored for {0} - no current view controller", 
					viewModel.GetType().Name);
				return;
			}

			// if the current view's view model is not the same as the one requesting close
			// then log an error
			if (view.ViewModel != viewModel)
			{
				MvxTrace.Trace("request close ignored for {0} - current view controller is " +
					"registered for a different viewmodel of type {1}", 
					viewModel.GetType().Name, view.ViewModel.GetType().Name);
				return;
			}

			// we should be okay to pop now
			MvxTrace.Trace("request close for {0} - will close current view controller {1}", 
				viewModel.GetType().Name, view.GetType().Name);

			// pop the navigation controller
			MasterNavigationController.PopViewControllerAnimated(true);
		}

		#endregion
	}
}

