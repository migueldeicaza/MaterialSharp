using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using CoreGraphics;
using MaterialSharp;

namespace MaterialSharpTest
{
	partial class ButtonsViewController : UIViewController
	{
		public ButtonsViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Show some customizations on the layer after the view loads.
			raisedButton.Layer.ShadowOpacity = 0.55f;
			raisedButton.Layer.ShadowRadius = 5;
			raisedButton.Layer.ShadowColor = UIColor.Gray.CGColor;
			raisedButton.Layer.ShadowOffset = new CGSize (0, 2.5f);

			flatbkg.BackgroundLayerColor = MaterialColor.Lime;
			flatbkg.Layer.ShadowOpacity = 0.5f;
			flatbkg.Layer.ShadowRadius = 5;
			flatbkg.Layer.ShadowColor = UIColor.Black.CGColor;
			flatbkg.Layer.ShadowOffset = new CGSize (0, 2.5f);

			flatbutton.MaskEnabled = true;
			flatbutton.CircleGrowRatioMask = 0.5f;
			flatbutton.BackgroundAnimationEnabled = true;
			flatbutton.RippleLocation = RippleLocation.Center;

			imagebutton1.CircleLayerColor = MaterialColor.DeepOrange;

			imagebutton2.MaskEnabled = false;
			imagebutton2.CircleGrowRatioMask = 1.2f;
			imagebutton2.BackgroundAnimationEnabled = false;
			imagebutton2.RippleLocation = RippleLocation.Center;

			floatbutton1.CornerRadius = 40;
			floatbutton1.BackgroundLayerCornerRadius = 40;
			floatbutton1.MaskEnabled = false;
			floatbutton1.CircleGrowRatioMask = 1.75f;
			floatbutton1.RippleLocation = RippleLocation.Center;
			floatbutton1.MaterialAnimationDuration = 0.85f;

			floatbutton1.Layer.ShadowOpacity = 0.75f;
			floatbutton1.Layer.ShadowRadius = 3.5f;
			floatbutton1.Layer.ShadowColor = UIColor.Black.CGColor;
			floatbutton1.Layer.ShadowOffset = new CGSize (1, 5.5f);

			floatbutton2.CornerRadius = 40;
			floatbutton2.Layer.ShadowOpacity = 0.75f;
			floatbutton2.Layer.ShadowRadius = 3.5f;
			floatbutton2.Layer.ShadowColor = UIColor.Black.CGColor;
			floatbutton2.Layer.ShadowOffset = new CGSize (1, 5.5f);

		}
	}
}
