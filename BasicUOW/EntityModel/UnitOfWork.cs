using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
        public class UnitOfWork : IDisposable
        {
            private DesignPatternSampleEntities context = new DesignPatternSampleEntities();
            private GenericRepository<Customer> customerRepository;
           
            public GenericRepository<Customer> CustomerRepository
            {
                get
                {
                    return this.customerRepository ?? new GenericRepository<Customer>(context);
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
