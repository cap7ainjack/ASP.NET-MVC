using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using CarDealer.Models.BindingModels.Sales;
using CarDealer.Models.ViewModels;
using CarDealer.Models.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerApp.Services
{
    public class SalesService
    {
        private CarDealerContext context = new CarDealerContext();

        public AddSaleVm GetSalesVm()
        {
            AddSaleVm vm = new AddSaleVm();
            IEnumerable<Car> carModels = this.context.Cars;
            IEnumerable<Customer> customerModels = this.context.Customers;

            IEnumerable<AddSaleCarVm> carVms = Mapper.Map<IEnumerable<Car>, IEnumerable<AddSaleCarVm>>(carModels);
            IEnumerable<AddSaleCustomerVm> customerVms =
                Mapper.Map<IEnumerable<Customer>, IEnumerable<AddSaleCustomerVm>>(customerModels);

            List<int> discounts = new List<int>();
            for (int i = 0; i <= 50; i += 5)
            {
                discounts.Add(i);
            }

            vm.Cars = carVms;
            vm.Customers = customerVms;
            vm.Discounts = discounts;

            return vm;
        }

        public AddSaleConfirmationVm GetSaleCofirmationVm(AddSaleBm bind)
        {
            Car carModel = this.context.Cars.Find(bind.CarId);
            Customer customerModel = this.context.Customers.Find(bind.CustomerId);
            AddSaleConfirmationVm vm = new AddSaleConfirmationVm()
            {
                Discount = bind.Discount,
                CarPrice = (decimal)carModel.Parts.Sum(part => part.Price).Value,
                CarId = carModel.Id,
                CarRepresentation = $"{carModel.Make} {carModel.Model}",
                CustomerId = customerModel.Id,
                CustomerName = customerModel.Name
            };

            vm.Discount += customerModel.IsYoungDriver ? 5 : 0;
            vm.FinalCarPrice = vm.CarPrice - vm.CarPrice * vm.Discount / 100;
            return vm;
        }
    }
}