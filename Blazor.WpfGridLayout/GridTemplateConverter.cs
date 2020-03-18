using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Blazor.WpfGridLayout
{
	public class GridTemplateConverter : IEnumerable<string>
	{
		private readonly List<string> _convertedData = new List<string>();
		private readonly Regex _proportionPattern = new Regex("^[0-9]*\\*$");
		private readonly Regex _fixedSizePattern = new Regex("^[0-9]*$");

		public void AddData(string data)
		{
			if (string.IsNullOrWhiteSpace(data))
				_convertedData.Add("1fr");
			else if (data == "*")
				_convertedData.Add("1fr");
			else if (data.ToLower() == "auto")
				_convertedData.Add("auto");
			else if (_fixedSizePattern.IsMatch(data))
				_convertedData.Add(data + "px");
			else if (_proportionPattern.IsMatch(data))
				_convertedData.Add(data.Replace("*", "fr"));
		}

		public IEnumerator<string> GetEnumerator() => _convertedData.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}