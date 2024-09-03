using System.ComponentModel.DataAnnotations;

namespace EComm.API.ViewModels.BaseVMs
{
    public abstract class ProductBaseVM
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        [Range(0.01, 99999999.99)]
        public required double Amount { get; set; }
        public required string Type { get; set; }
        public required int Quantity { get; set; }
        public required string Status { get; set; }
    }
}
