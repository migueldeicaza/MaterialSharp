//
// Button: implements the Material's Button
//
// Authors: 
//    LeVan Nghia (original Swift code)
//    Miguel de Icaza (C# port)
//
// TODO:
//   Various properites should probably support updating the view live, currently, they dont, 
//   unless an external even triggers the change.
//
using System;
using UIKit;
using CoreGraphics;
using Foundation;
using CoreAnimation;
using System.ComponentModel;

namespace MaterialSharp
{
	[DesignTimeVisible]
	[Register ("MaterialTextField")]
	public partial class MaterialTextField : UITextField
	{
		public CGSize Padding = new CGSize (5, 5);
		public nfloat FloatingLabelBottomMargin = 2;
		public bool FloatingPlaceholder = false;
		public float  BottomBorderWidth = 1;
		public UIColor BottomBorderColor = UIColor.LightGray;
		public nfloat BottomBorderHighlightWidth = (nfloat) 1.75;

		UILabel floatingLabel;
		CALayer bottomBorderLayer;

		UIFont floatingLabelFont = UIFont.BoldSystemFontOfSize (10);

		public UIFont FloatingLabelFont {
			get { return floatingLabelFont; }
			set {
				if (value == floatingLabelFont)
					return;
				floatingLabelFont = value;
				floatingLabel.Font = value;
			}
		}

		UIColor floatingLabelTextColor;
		public UIColor FloatingLabelTextColor {
			get { return floatingLabelTextColor; }
			set {
				if (value == floatingLabelTextColor)
					return;
				floatingLabelTextColor = value;
				floatingLabel.TextColor = value;
			}
		}

		bool bottomBorder;
		public bool BottomBorder {
			get { return bottomBorder; }
			set {
				bottomBorder = value;
				if (bottomBorderLayer != null)
					bottomBorderLayer.RemoveFromSuperLayer ();
				bottomBorderLayer = null;
				if (value) {
					bottomBorderLayer = new CALayer () {
						Frame = new CGRect (0, Layer.Bounds.Height - 1, Bounds.Width, 1),
						BackgroundColor = MaterialColor.Grey.CGColor
					};
					Layer.AddSublayer (bottomBorderLayer);

				}
			}
		}

		public override string Placeholder {
			get {
				return base.Placeholder;
			}
			set {
				base.Placeholder = value;
				floatingLabel.Text = value;
				floatingLabel.SizeToFit ();
				SetFloatingLabelOverlapTextField ();
			}
		}

		public MaterialTextField (CGRect frame) : base (frame)
		{
			SetupLayer ();
		}

		void SetupLayer ()
		{
			materialLayer = new MaterialLayer (Layer);
			Layer.BorderWidth = 1;
			BorderStyle = UITextBorderStyle.None;
			materialLayer.CircleGrowRatioMax = 1;

			materialLayer.SetCircleLayerColor (CircleLayerColor);
			materialLayer.SetBackgroundLayerColor (BackgroundLayerColor);

			// floating label
			floatingLabel = new UILabel () {
				Font = floatingLabelFont,
				Alpha = 0
			};
			AddSubview (floatingLabel);
		}

		public override bool BeginTracking (UITouch uitouch, UIEvent uievent)
		{
			materialLayer.AnimateRipple (uitouch.LocationInView (this), CircleAnimationTimingFunction, BackgroundAnimationTimingFunction, MaterialAnimationDuration);
			return base.BeginTracking (uitouch, uievent);
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			if (!FloatingPlaceholder)
				return;
			if (Text == "")
				HideFloatingLabel ();
			else {
				floatingLabel.TextColor = IsFirstResponder ? TintColor : floatingLabelTextColor;
				if (floatingLabel.Alpha == 0.0)
					ShowFloatingLabel ();
			}
			if (bottomBorderLayer != null) {
				bottomBorderLayer.BackgroundColor = (IsFirstResponder ? TintColor : BottomBorderColor).CGColor;
				var borderWidth = IsFirstResponder ? BottomBorderHighlightWidth : BottomBorderWidth;
				bottomBorderLayer.Frame = new CGRect (0, Layer.Bounds.Height-borderWidth, Layer.Bounds.Width, borderWidth);
			}
		}

		public override CGRect TextRect (CGRect forBounds)
		{
			var rect = base.TextRect (forBounds);
			var newRect = new CGRect (rect.X + Padding.Width, rect.Y, rect.Width - 2 * Padding.Width, rect.Height);
			if (!FloatingPlaceholder)
				return newRect;
			if (Text != "") {
				var dtop = floatingLabel.Font.LineHeight + FloatingLabelBottomMargin;
				return new UIEdgeInsets (dtop, 0, 0, 0).InsetRect (newRect);
			}
			return newRect;
		}

		public override CGRect EditingRect (CGRect forBounds)
		{
			return base.TextRect (forBounds);
		}

		void SetFloatingLabelOverlapTextField ()
		{
			var textRect = TextRect (Bounds);
			var originX = textRect.X;
			switch (TextAlignment) {
			case UITextAlignment.Center:
				originX += textRect.Width / 2 - floatingLabel.Bounds.Width / 2;
				break;
			case UITextAlignment.Right:
				originX += textRect.Width - floatingLabel.Bounds.Width;
				break;
			default:
				break;
			}
			floatingLabel.Frame = new CGRect (originX, Padding.Height, floatingLabel.Frame.Width, floatingLabel.Frame.Height);
		}

		void HideFloatingLabel ()
		{
			floatingLabel.Alpha = 0;
		}

		void ShowFloatingLabel ()
		{
			var flf = floatingLabel.Frame;
			floatingLabel.Frame = new CGRect (flf.X, Bounds.Height / 2, flf.Width, flf.Height);
			UIView.Animate (0.45, delay: 0, options: UIViewAnimationOptions.CurveEaseOut, animation: () => {
				floatingLabel.Alpha = 1;
				floatingLabel.Frame = flf;
			}, completion: null);
		}
	}
}

