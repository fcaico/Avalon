using System;
using Cirrious.CrossCore.Converters;
using MonoTouch.UIKit;

namespace Avalon.iOS.ValueConverters
{
	public class BoolToColorValueConverter : MvxValueConverter<bool, UIColor>
	{
		protected override UIColor Convert(bool value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value)
			{
				return UIColor.Green;
			}
			else
			{
				return UIColor.Red;
			}
		}
	}
}