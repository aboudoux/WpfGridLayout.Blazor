using System.Linq;

namespace WpfGridLayout.Blazor
{
	public class GridWrapper
	{
		private readonly GridTemplateConverter _columns = new GridTemplateConverter();
		private readonly GridTemplateConverter _rows = new GridTemplateConverter();

		public string Css => $"display: grid; {GenerateTemplateColumnsIfAny()}{GenerateTemplateRowsIfAny()}".TrimEnd();

		private string GenerateTemplateColumnsIfAny() => _columns.Any()
			? $"grid-template-columns: {string.Join(" ", _columns)}; "
			: string.Empty;

		private string GenerateTemplateRowsIfAny() => _rows.Any()
			? $"grid-template-rows: {string.Join(" ", _rows)};"
			: string.Empty;

		public void AddColumn(string width, string min = null, string max = null) => _columns.AddData(width, min, max);

		public void AddRow(string height, string min = null, string max = null) => _rows.AddData(height, min, max);

		public string RowGap(int gap) => gap > 0 ? $"grid-row-gap: {gap}px;" : string.Empty;
		public string ColumnGap(int gap) => gap > 0 ? $"grid-column-gap: {gap}px;" : string.Empty;
	}
}