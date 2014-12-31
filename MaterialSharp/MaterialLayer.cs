//
// MaterialLayer: Provides a layer with the support to render the material effects
//
// Authors: 
//    LeVan Nghia (original Swift code)
//    Miguel de Icaza (C# port)
//
using System;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using Foundation;

namespace MaterialSharp
{
	public enum RippleLocation {
		Center, Left, Right, TapLocation
	}

	class MaterialLayer {
		CALayer superLayer;
		CALayer circleLayer;
		CALayer backgroundLayer;
		CAShapeLayer maskLayer = new CAShapeLayer ();

		public static CAMediaTimingFunction LinearTiming = CAMediaTimingFunction.FromName (CAMediaTimingFunction.Linear);
		public static CAMediaTimingFunction EaseOutTiming = CAMediaTimingFunction.FromName (CAMediaTimingFunction.EaseOut);

		RippleLocation rippleLocation = RippleLocation.TapLocation;
		public RippleLocation RippleLocation {
			get  { return rippleLocation; }
			set {
				if (rippleLocation == value)
					return;
				rippleLocation = value;
				CGPoint origin;
				var sb = superLayer.Bounds;
				switch (value) {
				case RippleLocation.Center:
					origin = new CGPoint (sb.Width / 2, sb.Height / 2);
					break;
				case RippleLocation.Left:
					origin = new CGPoint ((nfloat)(sb.Width * 0.25), (nfloat)(sb.Height / 2));
					break;
				case RippleLocation.Right:
					origin = new CGPoint ((nfloat)(sb.Width * 0.75), (nfloat)(sb.Height / 2));
					break;
				default:
					return;
				}
				SetCircleLayerLocation (origin);
			}
		}

		float circleGrowRatioMax = 0.9f;
		public float CircleGrowRatioMax {
			get { return circleGrowRatioMax; }
			set {
				// Analysis disable once CompareOfFloatsByEqualityOperator
				if (value == circleGrowRatioMax)
					return;
				circleGrowRatioMax = value;
				circleLayer.CornerRadius = CircleRadius;
				SetCircleLayerLocationAtCenter ();
			}
		}

		nfloat CircleRadius {
			get {
				var sb = superLayer.Bounds;
				return (nfloat) (Math.Max (sb.Width, sb.Height) * circleGrowRatioMax) / 2;
			}
		}

		public MaterialLayer (CALayer superLayer)
		{
			this.superLayer = superLayer;
			var sb = superLayer.Bounds;

			backgroundLayer = new CALayer () {
				Frame = sb,
				Opacity = 0
			};
			superLayer.AddSublayer (backgroundLayer);
			circleLayer = new CALayer () {
				Opacity = 0,
				CornerRadius = CircleRadius
			};
			SetCircleLayerLocationAtCenter ();
			backgroundLayer.AddSublayer (circleLayer);
			SetMaskLayerCornerRadius (superLayer.CornerRadius);
			backgroundLayer.Mask = maskLayer;
		}

		public void SuperLayerDidResize ()
		{
			CATransaction.Begin ();
			var sb = superLayer.Bounds;
			CATransaction.DisableActions = true;
			backgroundLayer.Frame = sb;
			SetMaskLayerCornerRadius (superLayer.CornerRadius);
			CATransaction.Commit ();
			SetCircleLayerLocationAtCenter ();
		}

		public void EnableOnlyCircleLayer ()
		{
			backgroundLayer.RemoveFromSuperLayer ();
			superLayer.AddSublayer (circleLayer);
		}

		public void SetBackgroundLayerColor (UIColor color)
		{
			backgroundLayer.BackgroundColor = color.CGColor;
		}

		public void SetCircleLayerColor (UIColor color)
		{
			circleLayer.BackgroundColor = color.CGColor;
		}

		public void DidChangeTapLocation (CGPoint location)
		{
			if (rippleLocation == RippleLocation.TapLocation)
				SetCircleLayerLocation (location);
		}

		public void SetMaskLayerCornerRadius (nfloat cornerRadius)
		{
			maskLayer.Path = UIBezierPath.FromRoundedRect (backgroundLayer.Bounds, cornerRadius).CGPath;
		}

		public void EnableMask (bool enable = true)
		{
			backgroundLayer.Mask = enable ? maskLayer : null;
		}

		public void SetBackgroundLayerCornerRadius (nfloat cornerRadius)
		{
			backgroundLayer.CornerRadius = cornerRadius;
		}

		void SetCircleLayerLocationAtCenter ()
		{
			var bounds = superLayer.Bounds;
			SetCircleLayerLocation (new CGPoint (bounds.Width / 2, bounds.Height / 2));
		}

		void SetCircleLayerLocation (CGPoint center)
		{
			var sb = superLayer.Bounds;
			var subsize = CircleRadius * 2;
			CATransaction.Begin ();
			CATransaction.DisableActions = true;
			circleLayer.Frame = new CGRect (center.X - subsize / 2, center.Y - subsize / 2, subsize, subsize);
			CATransaction.Commit ();
		}

		public void AnimateScaleForCircleLayer (float fromScale, float toScale, CAMediaTimingFunction timingFunction, double duration)
		{
			var circleLayerAnim = CABasicAnimation.FromKeyPath ("transform.scale");
			circleLayerAnim.From = NSObject.FromObject (fromScale);
			circleLayerAnim.To = NSObject.FromObject (toScale);

			var opacityAnim = CABasicAnimation.FromKeyPath ("opacity");
			opacityAnim.From = NSObject.FromObject (1.0);
			opacityAnim.To = NSObject.FromObject (0.0);

			var groupAnim = new CAAnimationGroup () {
				Duration = duration,
				TimingFunction = timingFunction,
				RemovedOnCompletion = false,
				FillMode = CAFillMode.Forwards,
				Animations = new [] { circleLayerAnim, opacityAnim }
			};
			circleLayer.AddAnimation (groupAnim, null);
		}

		public void AnimateAlphaForBackgroundLayer (CAMediaTimingFunction timingFunction, double duration)
		{
			var anim = CABasicAnimation.FromKeyPath ("opacity");
			anim.From = NSObject.FromObject (1.0);
			anim.To = NSObject.FromObject (0.0);
			anim.Duration = duration;
			anim.TimingFunction = timingFunction;
			backgroundLayer.AddAnimation (anim, null);
		}

		public void AnimateSuperLayerShadow (nfloat fromRadius, nfloat toRadius, float fromOpacity, float toOpacity, CAMediaTimingFunction timingFunction, double duration)
		{
			AnimateShadowForLayer (superLayer, fromRadius, toRadius, fromOpacity, toOpacity, timingFunction, duration);
		}

		void AnimateShadowForLayer (CALayer layer, nfloat fromRadius, nfloat toRadius, float fromOpacity, float toOpacity, CAMediaTimingFunction timingFunction, double duration)
		{
			var radiusAnim = CABasicAnimation.FromKeyPath ("shadowRadius");
			radiusAnim.From = NSObject.FromObject (fromRadius);
			radiusAnim.To = NSObject.FromObject (toRadius);

			var opacityAnim = CABasicAnimation.FromKeyPath ("shadowOpacity");
			opacityAnim.From = NSObject.FromObject (fromOpacity);
			opacityAnim.To = NSObject.FromObject (toOpacity);

			var groupAnim = new CAAnimationGroup () {
				Duration = duration,
				TimingFunction = timingFunction,
				RemovedOnCompletion = false,
				FillMode = CAFillMode.Forwards,
				Animations = new [] { radiusAnim, opacityAnim }
			};
			layer.AddAnimation (groupAnim, null);
		}

		public void AnimateRipple (CGPoint location, CAMediaTimingFunction circleTiming, CAMediaTimingFunction backgroundTiming, double duration)
		{
			DidChangeTapLocation (location);
			AnimateScaleForCircleLayer (0.65f, 1.0f, circleTiming, duration);
			AnimateAlphaForBackgroundLayer (backgroundTiming, duration);
		}
	}
}

