using System;
using EmpDepTask.Areas.Identity.Data;
using EmpDepTask.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EmpDepTask.Areas.Identity.IdentityHostingStartup))]
namespace EmpDepTask.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EmpDepTaskContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("EmpDepTaskContextConnection")));
                
                services.AddDefaultIdentity<EmpDepTaskUser>(options => {
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.SignIn.RequireConfirmedAccount = false;
                })
                    .AddEntityFrameworkStores<EmpDepTaskContext>();
            });
        }
    }
}