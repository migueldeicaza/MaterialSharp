using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace MaterialSharpTest
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		public override UIWindow Window { get; set; }

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			//Window = new UIWindow (UIScreen.MainScreen.Bounds);
			//Window.MakeKeyAndVisible ();
			var x = new MaterialSharp.MaterialButton (UIScreen.MainScreen.Bounds);
			var y = new MaterialSharp.MaterialTextField (UIScreen.MainScreen.Bounds);
			return true;
		}

		static void Main (string[] args)
		{

			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}

