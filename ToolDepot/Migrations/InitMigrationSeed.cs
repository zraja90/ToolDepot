using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Customers;
using ToolDepot.Core.Domain.Email;
using ToolDepot.Core.Domain.Products;
using ToolDepot.Core.Domain.Security;
using ToolDepot.Core.Domain.Tasks;
using ToolDepot.Data;
using ToolDepot.Models;

namespace ToolDepot.Migrations
{
    public class InitMigrationSeed
    {
        public static void Seed(AppContext context)
        {
          /*  InitPermissions(context);
            InitRoles(context);
            InitCustomers(context);
           */
            InitEmailAccount(context);
            InitScheduleTask(context);
        }

        private static void InitScheduleTask(AppContext context)
        {
            var settings = new List<ScheduleTask>
                               {
                                   new ScheduleTask
                                       {
                                           Name = "Send Emails",
                                           Seconds = 60,
                                           Type = "ToolDepot.Services.Email.QueuedMessagesSendTask, ToolDepot",
                                           Enabled = true,
                                           StopOnError = false,
                                           LastStartUtc = null,
                                           LastEndUtc = null,
                                           LastSuccessUtc = null
                                       },
                                   new ScheduleTask
                                       {
                                           Name = "Keep alive",
                                           Seconds = 300,
                                           Type = "ToolDepot.Services.Common.KeepAliveTask, ToolDepot",
                                           Enabled = true,
                                           StopOnError = false,
                                           LastStartUtc = null,
                                           LastEndUtc = null,
                                           LastSuccessUtc = null
                                       }
                               };
            if (!context.Set<ScheduleTask>().Any())
            {
                settings.ForEach(x => context.Set<ScheduleTask>().Add(x));
            }
            context.SaveChanges();
        }

        private static void InitEmailAccount(AppContext context)
        {
            var settings = new List<EmailAccount>
                               {
                                   new EmailAccount
                                       {
                                           DisplayName = "Tool Depot",
                                           Email = "zeeshan@unigo.com",
                                           Host = "127.0.0.1",
                                           Port = 25,
                                           EnableSsl = false,
                                           IsDefault = true,
                                           Username = "zeeshan@unigo.com",
                                           Password = "aa",
                                           UseDefaultCredentials = true
                                       }
                               };
            if (!context.Set<EmailAccount>().Any())
            {
                settings.ForEach(x => context.Set<EmailAccount>().Add(x));
            }
            context.SaveChanges();
        }


        private static void InitCustomers(AppContext context)
        {
            var customer = new Customer()
            {
                UserName = "super@unigo.com",
                Email = "super@unigo.com",
                Password = "AJr8zm5tyOB2NDsch4xx5u17SmJTS1DPOjjBQ4m6FJJSxxcBSSkQXAHGhCgyUKIL5A==",

                FirstName = "unigo",
                LastName = "unigo",
                Active = true,
                Deleted = false,
                CreatedOnUtc = DateTime.UtcNow,
                LastActivityDateUtc = DateTime.UtcNow
            };


            if (context.Set<Customer>().Any())
                return;

            var customrole = context.Set<CustomerRole>().FirstOrDefault(x => x.SystemName == "Admin");

            customer.CustomerRoles.Add(customrole);

            context.Set<Customer>().AddOrUpdate(customer);

            context.SaveChanges();
        }

        private static void InitPermissions(AppContext context)
        {

            var settings = new List<PermissionRecord>
                               {
                                   new PermissionRecord
                                       {
                                           Name = "Access admin area",
                                           SystemName = "AccessAdminPanel",
                                           Category = "Standard"
                                       }
                               };
            if (!context.Set<PermissionRecord>().Any())
            {
                settings.ForEach(x => context.Set<PermissionRecord>().Add(x));
            }


            context.SaveChanges();

        }

        private static void InitRoles(AppContext context)
        {

            var settings = new List<CustomerRole>
                               {
                                   new CustomerRole
                                       {
                                           Id = 1,
                                           Name = "Tool Depot Admin",
                                           Active = true,
                                           IsSystemRole = true,
                                           SystemName = "Admin",
                                           IsGlobal = true
                                       }
                               };
            if (!context.Set<CustomerRole>().Any(x => x.SystemName == SystemCustomerRoleNames.Admin))
            {
                settings.ForEach(x => context.Set<CustomerRole>().AddOrUpdate(x));

            }
            context.SaveChanges();
        }


    }
}