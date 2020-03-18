using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Blazor.WpfGridLayout.Tests {
	public class GridWrapperShould 
	{
		private class GenerateColumnsTemplatesData : TheoryData<List<string>, string>
		{
			public GenerateColumnsTemplatesData()
			{
				Add(new List<string> {"*"}, "display: grid; grid-template-columns: 1fr;");
				Add(new List<string> {"1*", "2*"}, "display: grid; grid-template-columns: 1fr 2fr;");
				Add(new List<string> {"1*", "12*"}, "display: grid; grid-template-columns: 1fr 12fr;");
				Add(new List<string> {"1*", "25"}, "display: grid; grid-template-columns: 1fr 25px;");
				Add(new List<string> {"auto"}, "display: grid; grid-template-columns: auto;");
				Add(new List<string> {""}, "display: grid; grid-template-columns: 1fr;");
				Add(new List<string> {"", "*", "2*", "35", "Auto"}, "display: grid; grid-template-columns: 1fr 1fr 2fr 35px auto;");
			}
		}

		[Theory]
		[ClassData(typeof(GenerateColumnsTemplatesData))]
		public void GenerateColumnsTemplates(List<string> columns, string expected) 
		{
			var wrapper = new GridWrapper();
			columns.ForEach(a=> wrapper.AddColumn(a));
			wrapper.Css.Should().Be(expected);
		}


		private class GenerateRowsTemplatesData: TheoryData<List<string>, string> {
			public GenerateRowsTemplatesData()
			{
				Add(new List<string> { "*" }, "display: grid; grid-template-rows: 1fr;");
				Add(new List<string> { "1*", "2*" }, "display: grid; grid-template-rows: 1fr 2fr;");
				Add(new List<string> { "1*", "12*" }, "display: grid; grid-template-rows: 1fr 12fr;");
				Add(new List<string> { "1*", "25" }, "display: grid; grid-template-rows: 1fr 25px;");
				Add(new List<string> { "auto" }, "display: grid; grid-template-rows: auto;");
				Add(new List<string> { "" }, "display: grid; grid-template-rows: 1fr;");
				Add(new List<string> { "", "*", "2*", "35", "Auto" }, "display: grid; grid-template-rows: 1fr 1fr 2fr 35px auto;");
			}
		}

		[Theory]
		[ClassData(typeof(GenerateRowsTemplatesData))]
		public void GenerateRowsTemplates(List<string> rows, string expected)
		{
			var wrapper = new GridWrapper();
			rows.ForEach(a => wrapper.AddRow(a));
			wrapper.Css.Should().Be(expected);
		}

		public class CombineRowsAndColumnsTemplateData : TheoryData<List<string>, List<string>, string> {
			public CombineRowsAndColumnsTemplateData()
			{
				Add(new List<string>(){"*"}, new List<string>(){"*"}, "display: grid; grid-template-columns: 1fr; grid-template-rows: 1fr;");
				Add(new List<string>(){"*", "20", "auto", "2*"}, new List<string>(){ "*", "20", "auto", "2*" }, "display: grid; grid-template-columns: 1fr 20px auto 2fr; grid-template-rows: 1fr 20px auto 2fr;");
			}
		}

		[Theory]
		[ClassData(typeof(CombineRowsAndColumnsTemplateData))]
		public void CombineRowsAndColumnsTemplate(List<string> columns, List<string> rows, string expected)
		{
			var wrapper = new GridWrapper();
			columns.ForEach(a=> wrapper.AddColumn(a));
			rows.ForEach(a => wrapper.AddRow(a));
			wrapper.Css.Should().Be(expected);
		}
	}
}
