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
using CoreAnimation;
using Foundation;
using System.ComponentModel;

namespace MaterialSharp
{
	[DesignTimeVisible]
	[Register ("MaterialButton")]
	public partial class MaterialButton : UIButton {

		public bool ShadowAnimationEnabled = true;

		float backgroundLayerCornerRadius = 0;
		public float BackgroundLayerCornerRadius { 
			get { return backgroundLayerCornerRadius; }
			set {
				backgroundLayerCornerRadius = value;
				materialLayer.SetBackgroundLayerCornerRadius (value);
			}
		}
			
		public CAMediaTimingFunction ShadowAnimationTimingFunction = MaterialLayer.EaseOutTiming;

		public MaterialButton (CGRect frame) : base (UIButtonType.Custom)
		{
			Frame = frame;
			SetupLayer ();
		}

		void SetupLayer ()
		{
			materialLayer = new MaterialLayer (Layer);
			AdjustsImageWhenHighlighted = false;
			CornerRadius = 2.5f;
			materialLayer.SetBackgroundLayerColor (BackgroundLayerColor);
			materialLayer.SetCircleLayerColor (CircleLayerColor);
		}

		public override bool BeginTracking (UITouch uitouch, UIEvent uievent)
		{
			if (rippleLocation == RippleLocation.TapLocation) {
				materialLayer.DidChangeTapLocation (uitouch.LocationInView (this));
			}

			// circle animation
			materialLayer.AnimateScaleForCircleLayer (0.45f, 1.0f, CircleAnimationTimingFunction, MaterialAnimationDuration);

			// background animation
			if (backgroundAnimationEnabled) {
				materialLayer.AnimateAlphaForBackgroundLayer (BackgroundAnimationTimingFunction, MaterialAnimationDuration);
			}

			// Shadow Animation for Self
			if (ShadowAnimationEnabled) {
				materialLayer.AnimateSuperLayerShadow (10, Layer.ShadowRadius, 0, Layer.ShadowOpacity, ShadowAnimationTimingFunction, MaterialAnimationDuration);
			}
			return base.BeginTracking (uitouch, uievent);
		}
	}
}

