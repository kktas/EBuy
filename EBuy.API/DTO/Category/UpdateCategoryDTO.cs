namespace EBuy.API.DTO.Category
{
    public class UpdateCategoryDTO
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
