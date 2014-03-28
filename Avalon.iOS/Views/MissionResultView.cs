using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Avalon.Core.ViewModels;

namespace Avalon.iOS.Views
{
	public partial class MissionResultView : BaseViewController
	{
		public MissionResultView () : base ("MissionResultView", null)
		{
		}

		private new MissionResultViewModel ViewModel
		{
			get
			{
				return (MissionResultViewModel) base.ViewModel;
			}
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// ios7 layout
			if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
				EdgesForExtendedLayout = UIRectEdge.None;


			//NavigationItem.SetHidesBackButton (true, false);

			var set = this.CreateBindingSet<MissionResultView, MissionResultViewModel>();
			set.Bind(Title).To(vm => vm.DisplayName);
			set.Bind(ResultText).To(vm => vm.ResultText);
			set.Bind (ResultColorView).For (view => view.BackgroundColor).To (vm => vm.IsSuccess).WithConversion("BoolToColor");
			set.Bind (VoteAgain).To(vm => vm.VoteAgainCommand.Command);
			set.Apply();
		}
	}
}

