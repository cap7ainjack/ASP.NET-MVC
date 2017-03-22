using AutoMapper;
using CarDealer.Models;
using CarDealer.Models.ViewModels;
using CarDealer.Models.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CarDealerApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMaps()
        {
            Mapper.Initialize(expression =>
                   {
                       expression.CreateMap<RegisterUserBm, User>();
                       expression.CreateMap<Car, AddSaleCarVm>();
                       expression.CreateMap<Customer, AddSaleCustomerVm>();
                       expression.CreateMap<Car, AddSaleCarVm>().ForMember(vm => vm.MakeAndModel, configurationExpression => configurationExpression.MapFrom(car => $"{car.Make} {car.Model}"));
                   }
            );
        }
    }
}
