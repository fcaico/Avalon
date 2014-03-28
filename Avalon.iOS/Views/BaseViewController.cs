using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;
using Avalon.Core.Extensions;
using Avalon.Core.Interfaces.ViewModels;
using System;
using System.Linq;

namespace Avalon.iOS.Views
{
	/// <summary>
	/// Base view controller.  Handles common functionality across base view.
	/// </summary>
	public abstract class BaseViewController : MvxViewController, IClosable
	{
		#region Construction/Initialization

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseViewController"/> class.
		/// </summary>
		protected BaseViewController() 
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseViewController"/> class.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="bundle">Bundle.</param>
		protected BaseViewController(string name, NSBundle bundle = null) : base (name, bundle)
		{
		}

		#endregion

		#region Methods

		/// <summary>
		/// Called when the view is being closed.  Release your resources.
		/// </summary>
		protected virtual void OnBeingClosed()
		{
		    if (ChildViewControllers != null)
		    {
		        ChildViewControllers.Where(cvc => cvc is IClosable).ForEach(cvc => ((IClosable) cvc).Close());
		    }

		    IClosable model = ViewModel as IClosable;
		    if (model != null)
			{
				model.Closed();
			}

			Closed();
		}

		#region IClosable implementation

		/// <summary>
		/// Close this instance.
		/// </summary>
		public virtual void Close ()
		{
			OnBeingClosed();
		}

		/// <summary>
		/// View is now closed for business.
		/// </summary>
		public virtual void Closed ()
		{
			// no-op.
		}

		#endregion

		#endregion
	}
}

