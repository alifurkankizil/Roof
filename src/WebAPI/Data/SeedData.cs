using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationContext>>()))
            {
                if (!context.Employees.Any())
                {
                    List<Employee> employees = new List<Employee>()
                    {
                        new Employee()
                        {
                            Id=1,
                            Name = "Ali Furkan",
                            Surname ="KIZIL",
                            Email="alifurkankizil@gmail.com"
                        },
                        new Employee()
                        {
                            Id=2,
                            Name="Batuhan",
                            Surname="KARAMAN",
                            Email="batuhankaraman@gmail.com"
                        }
                    };
                    context.Employees.AddRange(employees);
                    context.SaveChanges();
                }

                if (!context.Activities.Any())
                {
                    List<Activity> activities = new List<Activity>()
                    {
                        new Activity()
                        {
                            Id=1,
                            Name="Bar Nights"
                        },
                        new Activity()
                        {
                            Id = 2,
                            Name ="Sports Events"
                        },
                        new Activity()
                        {
                            Id=3,
                            Name="Workplace Parties"
                        }
                    };
                    context.Activities.AddRange(activities);
                }

                if (!context.EmployeeActivities.Any())
                {
                    List<EmployeeActivity> employeeActivities = new List<EmployeeActivity>()
                    {
                        new EmployeeActivity()
                        {
                            EmployeeId=1,
                            ActivityId=2
                        },
                        new EmployeeActivity()
                        {
                            EmployeeId=1,
                            ActivityId=3
                        },
                        new EmployeeActivity()
                        {
                            EmployeeId=2,
                            ActivityId=1
                        },
                        new EmployeeActivity()
                        {
                            EmployeeId=2,
                            ActivityId=2
                        }
                    };
                    context.EmployeeActivities.AddRange(employeeActivities);
                    context.SaveChanges();
                }
            }

        }
    }
}
