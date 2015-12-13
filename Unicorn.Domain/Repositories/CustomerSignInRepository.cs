﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unicorn.Domain.Concrete;
using Unicorn.Domain.Interfaces;
using Unicorn.Domain.Entities;
using Unicorn.Domain.Repositories;

namespace Unicorn.Domain.Repositories
{
    public class CustomerSignInRepository : BaseRepository, ICustomerSignInRepository
    {

        #region Core
        public CustomerSignInRepository(int userID) : base(userID)
        {

        }

        public CustomerSignIn CreateCustomerSignIn(CustomerSignIn customerSignIn)
        {
            ctx.CustomerSignIn.Add(customerSignIn);
            ctx.SaveChanges();

            
            return customerSignIn;
        }

        public bool DeleteCustomerSignIn(int id)
        {
            var customer = ctx.CustomerSignIn.Where(x => x.ID == id).First();
            ctx.CustomerSignIn.Remove(customer);
            if (ctx.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public CustomerSignIn GetCustomerSignIn(int id)
        {
            return ctx.CustomerSignIn.Where(x => x.ID == id).First();
        }

        public IEnumerable<CustomerSignIn> GetCustomerSignIns()
        {
            return ctx.CustomerSignIn.AsEnumerable();
        }

        public CustomerSignIn UpdateCustomerSignIn(CustomerSignIn customerSignIn)
        {
            CustomerSignIn c = ctx.CustomerSignIn.Where(x => x.ID == customerSignIn.ID).First();

            if (c != null)
            {
                c.SignInTypeID = customerSignIn.SignInTypeID;
                c.SignInName_hash = customerSignIn.SignInName_hash;
                c.SignInPassword_hash = customerSignIn.SignInPassword_hash;
                c.StartDate = customerSignIn.StartDate;
                c.ConfirmDate = customerSignIn.ConfirmDate;
                c.Status = customerSignIn.Status;
                c.Sequence = customerSignIn.Sequence;
            }
            return c;
        }
        #endregion


        public CustomerSignIn GetCustomerSignIn(ConfigSignInType signInType, string signInName_hash, string signInPassword_hash)
        {
            return ctx.CustomerSignIn.Where(x => x.SignInName_hash == signInName_hash && x.SignInPassword_hash == signInPassword_hash).FirstOrDefault();
        }


    }
}

