namespace EBuy.API.DTO.Category
{
    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
