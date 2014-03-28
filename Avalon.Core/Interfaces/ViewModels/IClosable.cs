using System;

namespace Avalon.Core.Interfaces.ViewModels
{
	/// <summary>
	/// Add support to close an object.
	/// </summary>
	public interface IClosable
	{
		/// <summary>
		/// Close this instance.
		/// </summary>
		void Close();

		/// <summary>
		/// This instance has been closed.  Cleanup!
		/// </summary>
		void Closed();
	}
}
