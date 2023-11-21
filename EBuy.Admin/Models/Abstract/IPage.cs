using Microsoft.AspNetCore.Mvc.Rendering;

namespace EBuy.Admin;
public interface IPage
{
    public View View { get; set; }
}


