namespace EBuy.API.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCaterogryId { get; set; }
    }
}
