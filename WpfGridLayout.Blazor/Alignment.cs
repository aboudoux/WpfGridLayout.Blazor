namespace WpfGridLayout.Blazor
{
	public static class Alignment
	{
		public static CssAlignment Start => new CssAlignment("start");
		public static CssAlignment Center => new CssAlignment("center");
		public static CssAlignment End => new CssAlignment("end");
		public static CssAlignment Stretch => new CssAlignment("stretch");
	}
}