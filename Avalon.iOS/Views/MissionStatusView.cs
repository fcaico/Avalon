using Cirrious.MvvmCross.Binding.BindingContext;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using Avalon.Core.ViewModels;

namespace Avalon.iOS.Views
{
	public partial class MissionStatusView : BaseViewController
	{
		public MissionStatusView () : base ("MissionStatusView", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad();

			// ios7 layout
			if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
				EdgesForExtendedLayout = UIRectEdge.None;

			var set = this.CreateBindingSet<MissionStatusView, MissionStatusViewModel>();
			set.Bind(Title).To(vm => vm.DisplayName);
			set.Bind(TotalVotesText).To(vm => vm.NumberOfVotesString);
			set.Bind(FailIndicator).For(label => label.Hidden).To(vm => vm.VotedFail).WithConversion("InvertBool");
			set.Bind(SuccessIndicator).For(label => label.Hidden).To(vm => vm.VotedSuccess).WithConversion("InvertBool");
			set.Bind(FailButton).To(vm => vm.VoteFailCommand.Command);
			set.Bind(SuccessButton).To(vm => vm.VoteSuccessCommand.Command);
			set.Bind(EveryoneHasVotedButton).To(vm => vm.DoneCommand.Command);
			set.Bind(SubmitButton).To(vm => vm.CastVoteCommand.Command);
			set.Apply();
		}
	}
}

