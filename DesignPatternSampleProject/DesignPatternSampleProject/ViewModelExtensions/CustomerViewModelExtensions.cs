using BusinessLogic.Models;
using DesignPatternSampleProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatternSampleProject.ViewModelExtensions
{
    public static class CustomerViewModelExtensions
    {
        public static CustomerViewModel ToViewModel(this CustomerModel model)
        {
            return new CustomerViewModel
            {
                CustomerId = model.CustomerId,
                Firstname = model.Firstname,
                Surname = model.Surname,
                Address1 = model.Address1,
                Address2 = model.Address2,
                Address3 = model.Address3,
                Address4 = model.Address4,
                PostCode = model.PostCode,
              
            };
        }


        public static CustomerModel ToModel(this CustomerViewModel model)
        {
            return new CustomerModel
            {
                CustomerId = model.CustomerId,
                Firstname = model.Firstname,
                Surname = model.Surname,
                Address1 = model.Address1,
                Address2 = model.Address2,
                Address3 = model.Address3,
                Address4 = model.Address4,
                PostCode = model.PostCode,
            };
        }
    }
}