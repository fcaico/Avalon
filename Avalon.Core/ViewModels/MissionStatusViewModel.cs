using System;
using Cirrious.MvvmCross.ViewModels;

namespace Avalon.Core.ViewModels
{
	public class MissionStatusViewModel : BaseViewModel
	{
		private  CommandViewModel _voteSuccessCommand;
		private  CommandViewModel _voteFailCommand;
		private CommandViewModel _doneCommand;
		private CommandViewModel _castVoteCommand;
		private int _numVotes = 0;
		private int _numSuccessVotes = 0;
		private int _numFailVotes = 0;

		private bool _votedSuccess;
		private bool _votedFail;
		private string _numberOfVotesString;


		public bool VotedSuccess
		{
			get
			{
				return _votedSuccess;
			}
			set
			{
				_votedSuccess = value;
				RaisePropertyChanged(() => VotedSuccess);
			}
		}

		public bool VotedFail
		{
			get
			{
				return _votedFail;
			}
			set
			{
				_votedFail = value;
				RaisePropertyChanged(() => VotedFail);
			}
		}

		public int NumberOfVotes
		{
			get
			{
				return _numVotes;
			}
			set
			{
				_numVotes = value;
				RaisePropertyChanged(() => NumberOfVotes);
				RaisePropertyChanged(() => NumberOfVotesString);
			}
		}

		public string NumberOfVotesString
		{
			get
			{
				return string.Format("Number of Votes: {0}", _numVotes);
			}
			set
			{
				_numberOfVotesString = value;
				RaisePropertyChanged(() => NumberOfVotesString);
			}
		}

		public CommandViewModel VoteSuccessCommand
		{
			get
			{
				return _voteSuccessCommand;
			}
		}

		public CommandViewModel VoteFailCommand
		{
			get
			{
				return _voteFailCommand;
			}
		}

		public CommandViewModel CastVoteCommand
		{
			get
			{
				return _castVoteCommand;
			}
		}

		public CommandViewModel DoneCommand
		{
			get
			{
				return _doneCommand;
			}
		}

		public MissionStatusViewModel()
		{
			DisplayName = "Mission Status";

			_voteSuccessCommand = new CommandViewModel("Success", new MvxCommand(VoteSuccess));
			_voteFailCommand = new CommandViewModel("Fail", new MvxCommand(VoteFail));
			_castVoteCommand = new CommandViewModel("Cast Vote", new MvxCommand(CastVote));
			_doneCommand = new CommandViewModel("Tally Votes", new MvxCommand(TallyVotes));

		}

		private void TallyVotes()
		{
			ClearStackAndShowViewModel<MissionResultViewModel>(
				new MissionResultViewModel.Nav
				{
					IsSuccess = (_numFailVotes == 0),
					NumFails = _numFailVotes,
					NumSuccess = _numSuccessVotes
				});
		}

		private void AdvanceVote()
		{
			NumberOfVotes++;
			VotedSuccess = false;
			VotedFail = false;
		}

		private void CastVote()
		{
			if (VotedSuccess)
			{
				_numSuccessVotes++;
				AdvanceVote();
			}
			else if (VotedFail)
			{
				_numFailVotes++;
				AdvanceVote();
			}
			else
			{
				// TODO: nothing?!?
			}
		}

		private void VoteFail()
		{
			VotedFail = true;
			VotedSuccess = false;
		}

		private void VoteSuccess()
		{
			VotedFail = false;
			VotedSuccess = true;
		}
	}
}
