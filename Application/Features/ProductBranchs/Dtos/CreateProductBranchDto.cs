using Domain.Enums;
namespace Application.Features.ProductBranchs.Dtos
{
    public class CreateProductBranchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CitiesPlate Cities { get; set; }

    }
}
