using System;
using Avalon.Core.Interfaces.ViewModels;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections.Generic;

namespace Avalon.Core.ViewModels
{
    /// <summary>
    /// Base view model from which view models should be derived
    /// </summary>
	public class BaseViewModel : MvxViewModel, INamedItem, IDisposable, IClosable
    {
        #region Data Members

        /// <summary>
        /// The backing store for the <see cref="DisplayName"/> property 
        /// </summary>
        private string _displayName;

		/// <summary>
		/// The disposed flag.  Per the disposable pattern.
		/// </summary>
		private bool _disposed;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the display name.  
        /// This is the displayable name of the view
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

        #endregion

		/// <summary>
		/// Clears the stack and show view model.
		/// </summary>
		/// <param name="parameterValuesObject">Parameter values object.</param>
		/// <param name="presentationBundle">Presentation bundle.</param>
		/// <param name="requestedBy">Requested by.</param>
		/// <typeparam name="TViewModel">The 1st type parameter.</typeparam>
		protected void ClearStackAndShowViewModel<TViewModel>(object parameterValuesObject,
		                                                      MvxBundle presentationBundle = null,
		                                                      MvxRequestedBy requestedBy = null) where TViewModel : BaseViewModel
		{
			if (presentationBundle == null)
			{
				presentationBundle = 
						new MvxBundle(new Dictionary<string, string>());
			}

			presentationBundle.Data[PresentationBundleFlagKeys.ClearStack] = "";

			ShowViewModel<TViewModel>(parameterValuesObject, presentationBundle, requestedBy);
		}


        /// <summary>
        /// Safely executes an operation on behalf of the view model allowing a progress
        /// completion flag to be updated
        /// </summary>
        /// <param name="theOperation"></param>
        /// <param name="operationFlag"></param>
        /// <returns></returns>
		protected async Task<bool> ExecuteOperationAsync(Task theOperation, Expression<Func<bool>> operationFlag = null)
		{
		    Action<bool> setOperationFlag =
		        isInProgress =>
		            {
                        if (operationFlag == null)
		                {
		                    return;
		                }

                        MemberExpression memberSelectorExpression = operationFlag.Body as MemberExpression;
		                if (memberSelectorExpression == null)
		                {
		                    return;
		                }

                        PropertyInfo property = memberSelectorExpression.Member as PropertyInfo;
		                if (property == null)
		                {
		                    return;
		                }

		                property.SetValue(this, isInProgress, null);
		            };

			try
			{
				setOperationFlag(true);
				await theOperation;
				return true;
			}
			catch (Exception ex)
			{
				Mvx.Trace("An error ocurred while performing async operation: {0}", ex.Message);
				return false;
			}
			finally
			{
				setOperationFlag(false);
			}
		}


        /// <summary>
        /// Utility method to allow view models to request that they
        /// be closed and removed by the presenter
        /// </summary>
        protected void RequestClose()
        {
            IViewModelCloser closer = Mvx.Resolve<IViewModelCloser>();
            closer.RequestClose(this);
        }

		#region IDisposable implementation

		/// <summary>
		/// Releases all resource used by the <see cref="BaseViewModel"/> object.
		/// </summary>
		/// <remarks>Call <see cref="Dispose()"/> when you are finished using the
		/// <see cref="BaseViewModel"/>. The <see cref="Dispose()"/> method leaves the
		/// <see cref="BaseViewModel"/> in an unusable state. After calling
		/// <see cref="Dispose()"/>, you must release all references to the
		/// <see cref="BaseViewModel"/> so the garbage collector can reclaim the memory that
		/// the <see cref="BaseViewModel"/> was occupying.</remarks>
		public void Dispose ()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Dispose the specified disposing.
		/// </summary>
		/// <param name="disposing">If set to <c>true</c> disposing.</param>
		public void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					OnBeingDisposed();
				}
			}
			_disposed = true;
		}

		/// <summary>
		/// Raises when being disposed.  Cleanup any resources we may be holding on to
		/// such as message registration!
		/// </summary>
		protected virtual void OnBeingDisposed()
		{
		}

		#endregion

		#region IClosable implementation

		/// <summary>
		/// Close this instance.
		/// </summary>
		public void Close ()
		{
			RequestClose();
		}

		/// <summary>
		/// Closed this instance.
		/// </summary>
		public void Closed ()
		{
			Dispose();
		}

		#endregion
    }
	
	public static class PresentationBundleFlagKeys
	{
		public const string ClearStack = "__CLEAR_STACK__";
	}
}

