//
// Button: implements the Material's Button
//
// Authors: 
//    LeVan Nghia (original Swift code)
//    Miguel de Icaza (C# port)
//
using System;
using UIKit;
using CoreGraphics;
using Foundation;
using System.ComponentModel;

namespace MaterialSharp
{
	[DesignTimeVisible]
	[Register ("MaterialImageView")]
	public partial class MaterialImageView : UIImageView
	{
		public MaterialImageView (CGRect frame) : base (frame)
		{
			SetupLayer ();
		}

		public MaterialImageView (UIImage image) : base (image)
		{
			SetupLayer ();
		}

		public MaterialImageView (UIImage image, UIImage highlightedImage) : base (image, highlightedImage)
		{
			SetupLayer ();
		}

		void SetupLayer ()
		{
			materialLayer = new MaterialLayer (Layer);
			materialLayer.SetCircleLayerColor (CircleLayerColor);
			materialLayer.SetBackgroundLayerColor (BackgroundLayerColor);
			materialLayer.SetMaskLayerCornerRadius (CornerRadius);
		}
		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);
			var first = touches.AnyObject as UITouch;
			var location = first.LocationInView (this);
			materialLayer.AnimateRipple (location, CircleAnimationTimingFunction, BackgroundAnimationTimingFunction, MaterialAnimationDuration);
		}
	}
}

