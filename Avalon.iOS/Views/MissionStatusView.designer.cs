// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Avalon.iOS.Views
{
	[Register ("MissionStatusView")]
	partial class MissionStatusView
	{
		[Outlet]
		MonoTouch.UIKit.UIButton EveryoneHasVotedButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton FailButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel FailIndicator { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton SubmitButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton SuccessButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel SuccessIndicator { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel TotalVotesText { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (EveryoneHasVotedButton != null) {
				EveryoneHasVotedButton.Dispose ();
				EveryoneHasVotedButton = null;
			}

			if (FailButton != null) {
				FailButton.Dispose ();
				FailButton = null;
			}

			if (SubmitButton != null) {
				SubmitButton.Dispose ();
				SubmitButton = null;
			}

			if (SuccessButton != null) {
				SuccessButton.Dispose ();
				SuccessButton = null;
			}

			if (TotalVotesText != null) {
				TotalVotesText.Dispose ();
				TotalVotesText = null;
			}

			if (SuccessIndicator != null) {
				SuccessIndicator.Dispose ();
				SuccessIndicator = null;
			}

			if (FailIndicator != null) {
				FailIndicator.Dispose ();
				FailIndicator = null;
			}
		}
	}
}
