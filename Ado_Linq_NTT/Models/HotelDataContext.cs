using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Ado_Linq_NTT.Models
{
    public partial class HotelDataContext : DbContext
    {
        public HotelDataContext()
            : base("name=HotelDataContext")
        {
        }

        public virtual DbSet<Guest> Guests { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
