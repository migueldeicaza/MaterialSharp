//
// MaterialColor: Class with convenience properites to use Google's Material colors
//
// Authors: 
//    LeVan Nghia (original Swift code)
//    Miguel de Icaza (C# port)
//
using System;
using UIKit;

namespace MaterialSharp
{
	public class MaterialColor
	{
		public readonly UIColor Red = MakeUIColor (0xF44336);
		public static readonly UIColor Pink = MakeUIColor (0xE91E63);
		public static readonly UIColor Purple = MakeUIColor (0x9C27B0);
		public static readonly UIColor DeepPurple = MakeUIColor (0x67AB7);
		public static readonly UIColor Indigo = MakeUIColor (0x3F51B5);
		public static readonly UIColor Blue = MakeUIColor (0x2196F3);
		public static readonly UIColor LightBlue = MakeUIColor (0x03A9F4);
		public static readonly UIColor Cyan = MakeUIColor (0x00BCD4);
		public static readonly UIColor Teal = MakeUIColor (0x009688);
		public static readonly UIColor Green = MakeUIColor (0x4CAF50);
		public static readonly UIColor LightGreen = MakeUIColor (0x8BC34A);
		public static readonly UIColor Lime = MakeUIColor (0xCDDC39);
		public static readonly UIColor Yellow = MakeUIColor (0xFFEB3B);
		public static readonly UIColor Amber = MakeUIColor (0xFFC107);
		public static readonly UIColor Orange = MakeUIColor (0xFF9800);
		public static readonly UIColor DeepOrange = MakeUIColor (0xFF5722);
		public static readonly UIColor Brown = MakeUIColor (0x795548);
		public static readonly UIColor Grey = MakeUIColor (0x9E9E9E);
		public static readonly UIColor BlueGrey = MakeUIColor (0x607D8B);

		static UIColor MakeUIColor (uint code)
		{
			return new UIColor (
				red: (code >> 16) / 255.0f,
				green: ((code & 0xff00) >> 16) / 255.0f,
				blue: (code & 0xff) / 255.0f,
				alpha: 1.0f);
		}
	}
}

