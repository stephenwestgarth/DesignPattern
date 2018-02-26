using BusinessLogic.Models;
using BusinessLogic.Repository;
using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public partial class UnitOfWork : IDisposable
    {
        private Generic<Customer, CustomerModel> customerRepository;

        public Generic<Customer, CustomerModel> CustomerRepository
        {
            get
            {
                return this.customerRepository ?? new Generic<Customer, CustomerModel>(context);
            }
        }

    }
}
