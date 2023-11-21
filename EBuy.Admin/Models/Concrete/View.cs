using Microsoft.AspNetCore.Mvc.Rendering;

namespace EBuy.Admin;

public class View
{
    public string Title { get; set; }
    public List<BreadcrumbItem> Breadcrumbs { get; set; }
    public List<SelectList> SelectLists { get; set; }
}

