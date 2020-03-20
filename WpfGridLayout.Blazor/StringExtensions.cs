namespace WpfGridLayout.Blazor
{
	public static class StringExtensions
	{
		public static bool IsEmpty(this string source) => string.IsNullOrWhiteSpace(source);
		public static bool IsDefined(this string source) => !source.IsEmpty();
	}
}