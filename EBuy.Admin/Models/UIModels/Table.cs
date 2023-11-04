namespace EBuy.Admin.Models.UIModels;

public class Table
{
    public List<string> Headers { get; set; }
    public List<Row> Rows { get; set; }
    public Paging? Paging { get; set; }
}

public class Row
{
    public List<string> Cells { get; set; }
    // public List<Command> Commands { get; set; }
}

// public class Command
// {
//     public string Text { get; set; }
//     public string? Url { get; set; }
//     public string? Action { get; set; }
// }

public class Paging
{
    public bool HasPrev { get; set; }
    public bool HasNext { get; set; }
    public int StartIndex { get; set; }
    public int EndIndex { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int? TotalCount { get; set; }
}