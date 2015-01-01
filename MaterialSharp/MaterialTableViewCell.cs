//
// MaterialTableViewCell: implements the Material's UITableViewCells
//
// Authors: 
//    LeVan Nghia (original Swift code)
//    Miguel de Icaza (C# port)
//
// TODO:
//    This class does not seem complete, there is a reference to 'didResizeContentView' that is never set
//    which should be used to detect changes in the cell size.
//
using System;
using UIKit;
using CoreGraphics;
using Foundation;
using System.ComponentModel;

namespace MaterialSharp
{
	[DesignTimeVisible]
	public partial class MaterialTableViewCell : UITableViewCell
	{
		public MaterialTableViewCell (UITableViewCellStyle style, NSString reuseIdentifier) : base (style, reuseIdentifier)
		{
			// No SetupLayer?
		}

		public MaterialTableViewCell (CGRect frame) : base (frame)
		{
			SetupLayer ();
		}

		void SetupLayer ()
		{
			materialLayer = new MaterialLayer (Layer);
			SelectionStyle = UITableViewCellSelectionStyle.None;

			materialLayer.SetCircleLayerColor (CircleLayerColor);
			materialLayer.SetBackgroundLayerColor (BackgroundLayerColor);
			materialLayer.CircleGrowRatioMax = 1.2f;
		}

		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);
			var first = touches.AnyObject as UITouch;
			//if (!didResizeContentView) {
			//	materialLayer.SuperLayerDidResize ();
			//}
			var location = first.LocationInView (this);
			materialLayer.AnimateRipple (location, CircleAnimationTimingFunction, BackgroundAnimationTimingFunction, MaterialAnimationDuration);
		}
	}
}

