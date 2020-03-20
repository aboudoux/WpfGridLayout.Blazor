using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WpfGridLayout.Blazor
{
	public class GridTemplateConverter : IEnumerable<string>
	{
		private readonly List<string> _convertedData = new List<string>();
		private readonly Regex _proportionPattern = new Regex("^[0-9]*\\*$");
		private readonly Regex _fixedSizePattern = new Regex("^[0-9]*$");

		public void AddData(string data, string min = null, string max = null)
		{
			if (min.IsDefined() || max.IsDefined())
				_convertedData.Add($"minmax({ConvertToCss(min.IsDefined() ? min : "1")},{ConvertToCss(max.IsDefined() ? max : "*")})");
			else
				_convertedData.Add(ConvertToCss(data));
		}

		private string ConvertToCss(string data)
		{
			if (data.IsEmpty())
				return "1fr";
			if (data == "*")
				return "1fr";
			if (data.ToLower() == "auto")
				return "auto";
			if (_fixedSizePattern.IsMatch(data))
				return data + "px";
			if (_proportionPattern.IsMatch(data))
				return data.Replace("*", "fr");
			throw new GridLayoutException(data);
		}

		public IEnumerator<string> GetEnumerator() => _convertedData.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}