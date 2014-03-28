using System;
using Cirrious.MvvmCross.ViewModels;

namespace Avalon.Core.ViewModels
{
	public class MissionResultViewModel : BaseViewModel
	{
		private string _resultText;
		private bool _isSuccess;
		private CommandViewModel _voteAgainCommand;

		public class Nav
		{
			public bool IsSuccess
			{
				get;
				set;
			}

			public int NumSuccess 
			{
				get;
				set;
			}

			public int NumFails 
			{
				get;
				set;
			}

		}

		public string ResultText
		{
			get
			{
				return _resultText;
			}
			set
			{
				_resultText = value;
				RaisePropertyChanged(() => ResultText);
			}
		}

		public bool IsSuccess
		{
			get
			{
				return _isSuccess;
			}
			set
			{
				_isSuccess = value;
				RaisePropertyChanged(() => IsSuccess);
			}
		}

		public CommandViewModel VoteAgainCommand
		{
			get
			{
				return _voteAgainCommand;
			}
		}
			
		public MissionResultViewModel()
		{
			DisplayName = "Mission Result";
			_voteAgainCommand = new CommandViewModel ("Vote Again", new MvxCommand (() => ClearStackAndShowViewModel<MissionStatusViewModel> (null)));
		}

		public void Init(Nav navigation)
		{
			if (navigation.IsSuccess)
			{
				IsSuccess = true;
				ResultText = "Mission SUCCEEDS!";
			}
			else
			{
				IsSuccess = false;
				ResultText = string.Format("There were {0} FAILS!", navigation.NumFails);
			}

		}
	}
}

