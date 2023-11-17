namespace EBuy.Admin;

public class Page<T> : IPage
{
    public T Data { get; set; }
    public View View { get; set; }

}