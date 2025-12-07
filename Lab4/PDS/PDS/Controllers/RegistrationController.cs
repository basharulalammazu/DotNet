using AutoMapper;
using Microsoft.Ajax.Utilities;
using PDS.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PDS.Controllers
{
    public class RegistrationController : Controller
    {
        PMSEntities db = new PMSEntities();


        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>().ReverseMap();
            });

            return new Mapper(config);
        }


        // Hash Password
        public static string CreateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2")); // "x2" ensures lowercase hex format
                }
                return sb.ToString();
            }
        }


        // Convert DTO to Entity
        public static Customer Convert(CustomerDTO customerDTO)
        {
            return new Customer
            {
                Name = customerDTO.Name,
                Email = customerDTO.Email,
                Username = customerDTO.Username,
                Password = customerDTO.Password
            };
        }


        // Convert Entity to DTO
        public static CustomerDTO Convert(Customer customer)
        {
            return new CustomerDTO
            {
                Name = customer.Name,
                Email = customer.Email,
                Username = customer.Username,
                Password = customer.Password
            };
        }

        // Convert List<Entity> to List<DTO>
        public static List<CustomerDTO> Convert(List<Customer> customers)
        {
            var data = new List<CustomerDTO>();
            foreach (var customer in customers)
            {
                data.Add(Convert(customer));
            }
            return data;
        }


        // GET: Registration
        [HttpGet]
        public ActionResult Index()
        {
            return View(new CustomerDTO());
        }

        [HttpPost]
        public ActionResult Index(CustomerDTO customerDTO)
        {
            if (ModelState.IsValid)
            {
                var customer = GetMapper().Map<Customer>(customerDTO);
                customer.Password = CreateMD5(customer.Password);
                db.Customers.Add(customer);
                db.SaveChanges();
                ViewBag.Message = "Registration Successful";
                ModelState.Clear();
                return RedirectToAction("Dashboard");
            }
            return View(customerDTO);
        }

        public ActionResult Dashboard()
        {
            var customer = db.Customers.ToList();
            return View(customer);
        }

        public ActionResult Delete(int id)
        {
            var dbobj = db.Customers.Find(id);
            db.Customers.Remove(dbobj);
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}