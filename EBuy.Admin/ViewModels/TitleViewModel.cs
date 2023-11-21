using Microsoft.AspNetCore.Mvc.Rendering;

namespace EBuy.Admin;

public class TitleSearchViewModel
{
    public TitleSearchViewModel(string title, List<ISearchItem> searchItems)
    {
        this.Title = title;
        this.SearchItems = searchItems;
    }
    public string Title { get; set; }
    public List<ISearchItem> SearchItems { get; set; }
}

public interface ISearchItem
{
    public string Id { get; set; }
    public string Label { get; set; }
    public dynamic? Value { get; set; }
}

public class SelectListViewModel : ISearchItem
{
    public string Id { get; set; }
    public dynamic? Value { get; set; }
    public SelectList SelectList { get; set; }
    public string Label { get; set; }
}

public class TextBoxViewModel : ISearchItem
{
    public string Id { get; set; }
    public string Type { get; set; }
    public dynamic? Value { get; set; }
    public string Label { get; set; }
}