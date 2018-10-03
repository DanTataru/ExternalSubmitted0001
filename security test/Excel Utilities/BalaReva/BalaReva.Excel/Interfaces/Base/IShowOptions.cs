namespace BalaReva.Excel.Interfaces
{
    using BalaReva.Excel.Charts;

    public interface IShowOptions
    {
        bool AutoText { get; set; }
        bool ShowLegend { get; set; }
        bool ShowCategoryName { get; set; }
        bool ShowPercentage { get; set; }
        DataLabelsEnum DataLabelsType { get; set; }
        DataLabelsEnum LegendKey { get; set; }
        bool HasLeaderLines { get; set; }
        bool ShowSeriesName { get; set; }
        bool ShowValue { get; set; }
        bool ShowBubbleSize { get; set; }
        string Separator { get; set; }
    }
}
