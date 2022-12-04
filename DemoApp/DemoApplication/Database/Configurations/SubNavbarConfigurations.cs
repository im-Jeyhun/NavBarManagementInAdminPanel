using DemoApplication.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DemoApplication.Database.Configurations
{
    public class SubNavbarConfigurations : IEntityTypeConfiguration<SubNavbar>
    {
        public void Configure(EntityTypeBuilder<SubNavbar> builder)
        {
            builder
               .HasOne(sn => sn.Navbar)
               .WithMany(n => n.SubNavbars)
               .HasForeignKey(sn => sn.NavbarId);
        }
    }
}
