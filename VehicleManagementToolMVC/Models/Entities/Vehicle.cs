using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VehicleManagementToolMVC.Enums;

namespace VehicleManagementToolMVC.Models.Entities
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public Condition Condition { get; set; }
        public int Mileage { get; set; }
        public int ConstructionOfYear { get; set; }
        public FuelKind FuelKind { get; set; } 
        public string? Seller {  get; set; }
    }
}
