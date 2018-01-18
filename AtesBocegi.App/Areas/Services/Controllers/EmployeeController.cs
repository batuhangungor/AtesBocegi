using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AtesBocegi.Models;
using Microsoft.AspNetCore.Http;
using AtesBocegi.Functions;
using AtesBocegi.Models.DataTables;
using AtesBocegi.Models.FormModels;

namespace AtesBocegi.App.Areas.Services.Controllers
{
    public class EmployeeController : BaseServiceController
    {
        [HttpGet]
        public string Index()
        {
            return "selam";
        }

        [HttpPost]
        public IActionResult Index(DataTablePostModel dataTablePostModel)
        {
            var model = db.Employee.Select(q => new DataTableEmployeeList
            {
                Id = q.Id,
                Name = q.Name,
                Role = q.Role
            });

            var Employees = DataTableProcessor<DataTableEmployeeList>.ProcessCollection(model, dataTablePostModel).ToList();

            dynamic response = new
            {
                Data = Employees,
                Draw = dataTablePostModel.draw,
                RecordsFiltered = model.ToList().Count,
                RecordsTotal = model.ToList().Count
            };
            return StatusCode(200, response);
        }

        [HttpPost]
        public IActionResult Operate(EmployeeFormModel model, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0 || model.Id == null)
                {
                    try
                    {
                        if (image != null)
                        {
                            string imageBase64Data = ImageOperations.GetBase64FromFile(image);
                            model.Image = imageBase64Data;
                            Employee employee = new Employee
                            {
                                ColorId = model.ColorId,
                                Detail = model.Detail,
                                Image = model.Image,
                                Info = model.Info,
                                Name = model.Name,
                                Role = model.Role,
                                ScreenOrder = model.ScreenOrder
                            };
                            db.Add(employee);
                            db.SaveChanges();
                            return StatusCode(200, "Eklendi");
                        }
                        else
                        {
                            ModelState.AddModelError("Error", "Lütfen Resim Ekleyiniz");
                        }


                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("error", "Error! An error occurred while Employee creating");
                    }
                }
                else
                {
                    var employee = db.Employee.Where(q => q.Id == model.Id).FirstOrDefault();
                    if (employee == null)
                    {
                        ModelState.AddModelError("error", "Unknown Request!");
                    }
                    else
                    {
                        if (image != null)
                        {
                            string imageBase64Data = ImageOperations.GetBase64FromFile(image);
                            employee.Image = imageBase64Data;
                        }
                        employee.Name = model.Name;
                        employee.Info = model.Info;
                        employee.Detail = model.Detail;
                        employee.ColorId = model.ColorId;
                        employee.Role = model.Role;
                        db.Update(employee);
                        db.SaveChanges();
                        return StatusCode(200, "Güncellendi!");
                    }
                }
            }
            return BadRequest(new
            {
                Message = "Some error(s) occurred!",
                StatusCode = 400,
                ModelState = ModelState.ToList()
            });
        }

        [HttpPost]
        public IActionResult DeleteEmployee(int employeeId)
        {
            var employee = db.Employee.Where(q => q.Id == employeeId).FirstOrDefault();
            if (employee != null)
            {
                db.Remove(employee);
                db.SaveChanges();
                return StatusCode(200, "Silindi");
            }
            return StatusCode(404, "Page Not Found");
        }

    }
}
