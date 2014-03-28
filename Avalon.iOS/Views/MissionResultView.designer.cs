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
	[Register ("MissionResultView")]
	partial class MissionResultView
	{
		[Outlet]
		MonoTouch.UIKit.UIView ResultColorView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel ResultText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton VoteAgain { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ResultColorView != null) {
				ResultColorView.Dispose ();
				ResultColorView = null;
			}

			if (ResultText != null) {
				ResultText.Dispose ();
				ResultText = null;
			}

			if (VoteAgain != null) {
				VoteAgain.Dispose ();
				VoteAgain = null;
			}
		}
	}
}
