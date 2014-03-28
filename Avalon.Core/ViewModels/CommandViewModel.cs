using System;
using Avalon.Core.Interfaces.ViewModels;
using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;

namespace Avalon.Core.ViewModels
{
    /// <summary>
    /// Not exactly a view model but an object which can be bound to 
    /// and exposed by view models.
    /// This object encapsulates an ICommand along with its display name,
    /// isEnabled and isVisible properties.  Most useful for buttons but
    /// can be used with any ICommand which needs a corresponding label 
    /// and viewable state.
    /// </summary>
    public class CommandViewModel : MvxNotifyPropertyChanged, INamedItem
    {
        #region Data Members

        /// <summary>
        /// backing store for the <see cref="Command"/> property
        /// </summary>
        protected ICommand _command;

        /// <summary>
        /// backing store for the <see cref="IsEnabled"/> property
        /// </summary>
        protected bool _isEnabled;

        /// <summary>
        /// backing store for the <see cref="IsVisible"/> property
        /// </summary>
        protected bool _isVisible;

        /// <summary>
        /// backing store for the <see cref="DisplayName"/> 
        /// </summary>
        private string _displayName;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the display name.  
        /// This is the displayable name of the command 
        /// Often used to indicate button title or menu text
        /// </summary>
        public string DisplayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                _displayName = value;
                RaisePropertyChanged(() => DisplayName);
            }
        }

        /// <summary>
        /// The ICommand property itself.
        /// </summary>
        public virtual ICommand Command
        {
            get
            {
                return _command;
            }
            set
            {
                _command = value;
                RaisePropertyChanged(() => Command);
            }
        }



        /// <summary>
        /// A suggestion to the User interface that this command should be enabled (or not).
        /// </summary>
        public virtual bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                RaisePropertyChanged(() => IsEnabled);
            }
        }


        /// <summary>
        /// A suggestion to the User interface that this command should be visible (or not).
        /// </summary>
        public virtual bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                RaisePropertyChanged(() => IsVisible);
            }
        }

        #endregion

        #region Construction / Destruction

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandViewModel"/> class.
        /// </summary>
        public CommandViewModel()
        {
        }

        /// <summary>
        /// The workhorse constructor
        /// All the other constructors end up referring here.
        /// </summary>
        /// <param name="displayName">The display name for this named command</param>
        /// <param name="command">The ICommand object to be wrapped</param>
        /// <param name="isEnabled">Initial state of enablement for the command</param>
        /// <param name="isVisible">Initial state of visibility for the command</param>
        public CommandViewModel(string displayName, ICommand command, bool isEnabled, bool isVisible)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            _command = command;
            _isEnabled = isEnabled;
            _isVisible = isVisible;
            DisplayName = displayName;
        }


        /// <summary>
        /// overridden constructor allowing <see cref="IsVisible"/> property to be left off 
        /// and defaulted to true.
        /// </summary>
        /// <param name="displayName">The display name for this named command</param>
        /// <param name="command">The ICommand object to be wrapped</param>
        /// <param name="isEnabled">Initial state of enablement for the command</param>
        public CommandViewModel(string displayName, ICommand command, bool isEnabled)
            : this(displayName, command, isEnabled, true)
        {
        }



        /// <summary>
        /// overridden constructor allowing <see cref="IsEnabled"/> and <see cref="IsVisible"/> 
        /// properties to be left off and defaulted to true.
        /// </summary>
        /// <param name="displayName">The display name for this named command</param>
        /// <param name="command">The ICommand object to be wrapped</param>
        public CommandViewModel(string displayName, ICommand command)
            : this(displayName, command, true, true)
        {

        }

        #endregion
    }
}

