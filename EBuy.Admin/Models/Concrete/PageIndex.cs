
namespace EBuy.Admin;

public class PageIndex<T> : IPage, ISearchablePage
{
    public T Data { get; set; }
    public View View { get; set; }
    public Dictionary<string, dynamic> Search { get; set; }
}