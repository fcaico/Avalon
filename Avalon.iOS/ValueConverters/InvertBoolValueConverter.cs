using System;
using Cirrious.CrossCore.Converters;

namespace Avalon.iOS.ValueConverters
{
	public class InvertBoolValueConverter : MvxValueConverter<bool, bool>
	{
		protected override bool Convert(bool value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return !value;
		}
	}
}