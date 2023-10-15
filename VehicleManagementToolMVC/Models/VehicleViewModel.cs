using System.ComponentModel;
using VehicleManagementToolMVC.Enums;

namespace VehicleManagementToolMVC.Models
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        [DisplayName("Brand")]
        public string? Brand { get; set; }
        [DisplayName("Model")]
        public string? Model { get; set; }
        [DisplayName("Condition")]
        public Condition Condition { get; set; }
        [DisplayName("Mileage")]
        public int Mileage { get; set; }
        [DisplayName("Construction of year")]
        public int ConstructionOfYear { get; set; }
        [DisplayName("Fuel kind")]
        public FuelKind FuelKind { get; set; }
        [DisplayName("Seller")]
        public string? Seller { get; set; }

    }
}
