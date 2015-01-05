//
// Label: implements the Material's Label
//
// Authors: 
//    LeVan Nghia (original Swift code)
//    Miguel de Icaza (C# port)
//using System;
using UIKit;
using CoreGraphics;
using Foundation;
using System.ComponentModel;

namespace MaterialSharp
{
	[DesignTimeVisible (true)]
	[Category ("MaterialSharp")]
	[Register ("MaterialLabel")]
	public partial class MaterialLabel : UILabel
	{
		public MaterialLabel (CGRect frame) : base (frame)
		{
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

