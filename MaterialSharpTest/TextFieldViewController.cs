using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using MaterialSharp;

namespace MaterialSharpTest
{
	partial class TextFieldViewController : UIViewController
	{
		public TextFieldViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			#if false
			// No border, no shadow, floatPlaceHolderDisabled
			textField1.Layer.BorderColor = UIColor.Clear.CGColor;
			textField1.Placeholder = "Placeholder";
			textField1.TintColor = UIColor.Gray;

			// No border, shadow, floatPlaceHolderDisabled
			textField2.Layer.BorderColor = UIColor.Clear.CGColor;
			textField2.Placeholder = "Repo name";
			textField2.BackgroundColor = new UIColor (0.878f, 0.878f, 0.878f, 1);
			textField2.TintColor = UIColor.Gray;

			var x = new MaterialTextField (null);

			// Border, no shadow, floatPlaceHolderDisabled
			textField3.Layer.BorderColor = MaterialColor.Grey.CGColor;
			textField3.CircleLayerColor = MaterialColor.Amber;
			textField3.TintColor = MaterialColor.DeepOrange;
			textField3.RippleLocation = RippleLocation.Left;

			// No border, no shadow, floatingPlaceholderEnabled
			textField4.Layer.BorderColor = UIColor.Clear.CGColor;
			textField4.FloatingPlaceholderEnabled = true;
			textField4.Placeholder = "Github";
			textField4.TintColor = MaterialColor.Blue;
			textField4.RippleLocation = RippleLocation.Right;
			textField4.CornerRadius = 0;
			textField4.BottomBorderEnabled = true;

			// No border, shadow, floatingPlaceholderEnabled
			textField5.Layer.BorderColor = UIColor.Clear.CGColor;
			textField5.FloatingPlaceholderEnabled = true;
			textField5.Placeholder = "Email account";
			textField5.CircleLayerColor = MaterialColor.LightBlue;
			textField5.TintColor = MaterialColor.Blue;
			textField5.BackgroundColor = UIColor(hex: 0xE0E0E0);

			// Border, floatingPlaceholderEnabled
			textField6.FloatingPlaceholderEnabled = true;
			textField6.CornerRadius = 1.0;
			textField6.Placeholder = "Description";
			textField6.Layer.BorderColor = MaterialColor.Green.CGColor;
			textField6.CircleLayerColor = MaterialColor.LightGreen;
			textField6.TintColor = MaterialColor.LightGreen;
			#endif
		}
	}
}
