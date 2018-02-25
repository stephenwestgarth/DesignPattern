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
    public class UnitOfWork : IDisposable
    {
        private DesignPatternSampleEntities context;
        private Generic<Customer, CustomerModel> customerRepository;
        private Generic<Country, CountryModel> countryRepository;

        public UnitOfWork()
        {
            context = new DesignPatternSampleEntities();
        }

        public Generic<Customer, CustomerModel> CustomerRepository
        {
            get
            {
                return this.customerRepository ?? new Generic<Customer, CustomerModel>(context);
            }
        }

       







        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
