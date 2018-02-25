using BusinessLogic.Models;
using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.EntityExtensions
{
    public class GenericEntityExtensions<TEntity, TModel> 
    {
        public TModel ToModel(TEntity entity)
        {

            if (typeof(TEntity) == typeof(Customer))
            {
                var entityconversion = (Customer)(object)entity;
                var val = (TModel)(object)new CustomerModel
                {
                    CustomerId = entityconversion.CustomerId,
                    Firstname = entityconversion.Firstname,
                    Surname = entityconversion.Surname,
                    Address1 = entityconversion.Address1,
                    Address2 = entityconversion.Address2,
                    Address3 = entityconversion.Address3,
                    Address4 = entityconversion.Address4,
                    PostCode = entityconversion.PostCode,
                  
                    
                };
                return val;

            }

            if (typeof(TEntity) == typeof(Country))
            {
                var val = (TModel)(object)new CountryModel
                {
                   
                };
                return val;

            }
            return default(TModel);

        }

        
        public TEntity ToEntity(TModel objectModel, TEntity objectEntity)
        {
            
            if (typeof(TModel) == typeof(CustomerModel))
            {
                var ModelConverted = (CustomerModel)(object)objectModel;
                if (objectEntity == null)
                {
                   
                    var val = (TEntity)(object)new Customer
                    {
                        CustomerId = ModelConverted.CustomerId,
                        Firstname = ModelConverted.Firstname,
                        Surname = ModelConverted.Surname,
                        Address1 = ModelConverted.Address1,
                        Address2 = ModelConverted.Address2,
                        Address3 = ModelConverted.Address3,
                        Address4 = ModelConverted.Address4,
                        PostCode = ModelConverted.PostCode,
                       
                    };
                    return val;
                }
                else
                {
                    var EntityConverted = (Customer)(object)objectEntity;
                    EntityConverted.CustomerId = ModelConverted.CustomerId;
                    EntityConverted.Firstname = ModelConverted.Firstname;
                    EntityConverted.Surname = ModelConverted.Surname;
                    EntityConverted.Address1 = ModelConverted.Address1;
                    EntityConverted.Address2 = ModelConverted.Address2;
                    EntityConverted.Address3 = ModelConverted.Address3;
                    EntityConverted.Address4 = ModelConverted.Address4;
                    EntityConverted.PostCode = ModelConverted.PostCode;
                  
                    return (TEntity)(object)EntityConverted;
                }

            }
            return default(TEntity);


        }
    }
}
