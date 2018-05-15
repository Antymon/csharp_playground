using System;
using System.Text;

public class IndentedStringBuilder {

    public const string Tab_Spaces = "    ";
    public const string Tab = "\t";

    private int _tabsCount = 0;
    private string _tab;

    private StringBuilder stringBuilder;

    public IndentedStringBuilder(string tab = Tab) {
        _tab = tab;
        stringBuilder = new StringBuilder();
    }

    public IndentedStringBuilder AppendFormatLine(string format, params object[] args) {
        var formatedString = String.Format(format, args);

        return AppendLine(formatedString);
    }

    public IndentedStringBuilder AppendLine(string line) {
        var indentedString = AddTabs(line);
        stringBuilder.AppendLine(indentedString);

        return this;
    }

    public IndentedStringBuilder AppendLine() {
        stringBuilder.AppendLine();
        return this;
    }

    public void IncreaseTabs() {
        _tabsCount++;
    }

    public void DecreaseTabs() {
        _tabsCount--;
    }

    public override string ToString() {
        return stringBuilder.ToString();
    }

    private string AddTabs(string value)
    {
        return IndentedStringBuilder.AddTabs(value, _tab, _tabsCount);
    }

    public static string AddTabs(string value, string tab, int tabsCount) {

        var tabBuilder = new StringBuilder();

        for (int i = 0; i < tabsCount; i++)
        {
            tabBuilder.Append(tab);
        }

        tabBuilder.Append(value);

        return tabBuilder.ToString();
    }
}