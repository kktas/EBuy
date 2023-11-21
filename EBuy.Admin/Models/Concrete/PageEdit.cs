namespace EBuy.Admin;

public class PageEdit<T> : IPage
{
    public T Data { get; set; }
    public View View { get; set; }
}
