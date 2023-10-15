using Microsoft.AspNetCore.Mvc;
using VehicleManagementToolMVC.DataAccess;
using VehicleManagementToolMVC.Models;
using VehicleManagementToolMVC.Models.Entities;

namespace VehicleManagementToolMVC.Controllers
{
    public class VehicleController : Controller
    {
        private readonly VehicleDbContext _context;

        public VehicleController(VehicleDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vehicles = _context.Vehicles.ToList();
            List<VehicleViewModel> vehicleList = new List<VehicleViewModel>();

            if (vehicles != null)
            {
                foreach (var vehicle in vehicles)
                {
                    var VehicleViewModel = new VehicleViewModel()
                    {
                        Id = vehicle.Id,
                        Brand = vehicle.Brand,
                        Model = vehicle.Model,
                        Condition = vehicle.Condition,
                        Mileage = vehicle.Mileage,
                        ConstructionOfYear = vehicle.ConstructionOfYear,
                        FuelKind = vehicle.FuelKind,
                        Seller = vehicle.Seller
                    };
                    vehicleList.Add(VehicleViewModel);
                }
                return View(vehicleList);
            }

            return View(vehicleList);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(VehicleViewModel vehicleInformation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var vehicle = new Vehicle()
                    {
                        Brand = vehicleInformation.Brand,
                        Model = vehicleInformation.Model,
                        Condition = vehicleInformation.Condition,
                        Mileage = vehicleInformation.Mileage,
                        ConstructionOfYear = vehicleInformation.ConstructionOfYear,
                        FuelKind = vehicleInformation.FuelKind,
                        Seller = vehicleInformation.Seller
                    };
                    _context.Vehicles.Add(vehicle);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "New vehicle registreted";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Current Model data is not valid";
                    return View();
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                var vehicle = _context.Vehicles.SingleOrDefault(x => x.Id == Id);
                if (vehicle != null)
                {
                    var vehicleView = new VehicleViewModel()
                    {
                        Id = vehicle.Id,
                        Brand = vehicle.Brand,
                        Model = vehicle.Model,
                        Condition = vehicle.Condition,
                        Mileage = vehicle.Mileage,
                        ConstructionOfYear = vehicle.ConstructionOfYear,
                        FuelKind = vehicle.FuelKind,
                        Seller = vehicle.Seller
                    };
                    return View(vehicleView);
                }
                else
                {
                    TempData["errorMessage"] = $"Vehicle with the following Id: {Id} does not exist";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }



        [HttpPost]
        public IActionResult Edit(VehicleViewModel currentModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var vehicle = new Vehicle()
                    {
                        Id = currentModel.Id,
                        Brand = currentModel.Brand,
                        Model = currentModel.Model,
                        Condition = currentModel.Condition,
                        Mileage = currentModel.Mileage,
                        ConstructionOfYear = currentModel.ConstructionOfYear,
                        FuelKind = currentModel.FuelKind,
                        Seller = currentModel.Seller
                    };
                    _context.Vehicles.Update(vehicle);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Vehicle information updated";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Current Model data is not valid";
                    return View();
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                var vehicle = _context.Vehicles.SingleOrDefault(x => x.Id == Id);

                if (vehicle != null)
                {
                    var vehicleView = new VehicleViewModel()
                    {
                        Id = vehicle.Id,
                        Brand = vehicle.Brand,
                        Model = vehicle.Model,
                        Condition = vehicle.Condition,
                        Mileage = vehicle.Mileage,
                        ConstructionOfYear = vehicle.ConstructionOfYear,
                        FuelKind = vehicle.FuelKind,
                        Seller = vehicle.Seller
                    };
                    return View(vehicleView);
                }
                else
                {
                    TempData["errorMessage"] = $"Vehicle with the following Id: {Id} does not exist";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete(VehicleViewModel currentModel)
        {
            try
            {
                var vehicle = _context.Vehicles.SingleOrDefault(x => x.Id == currentModel.Id);
                if (vehicle != null)
                {
                    _context.Vehicles.Remove(vehicle);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Vehicle deleted";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Vehicle with the following Id: {currentModel.Id} does not exist";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

    }
}
