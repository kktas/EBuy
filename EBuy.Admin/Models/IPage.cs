using Microsoft.AspNetCore.Mvc.Rendering;

namespace EBuy.Admin;
public interface IPage
{
    public View View { get; set; }

}

public class View
{
    public string Title { get; set; }
    public List<BreadcrumbItem> Breadcrumbs { get; set; }
    public List<SelectList> SelectLists { get; set; }
    public Dictionary<string, dynamic> Search { get; set; }
}

public class BreadcrumbItem
{
    public string Text { get; set; }
    public string? Url { get; set; }
}