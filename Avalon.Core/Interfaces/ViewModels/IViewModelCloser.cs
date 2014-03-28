using System;
using Cirrious.MvvmCross.ViewModels;

namespace Avalon.Core.Interfaces.ViewModels
{
    public interface IViewModelCloser
    {
        void RequestClose(IMvxViewModel viewModel);
    }
}
