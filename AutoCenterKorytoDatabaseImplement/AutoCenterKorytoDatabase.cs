using AutoCenterKorytoDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;


namespace AutoCenterKorytoDatabaseImplement
{
    public class AutoCenterKorytoDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AutoCenterKoryto;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Car> Cars { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<ClientWishes> ClientWishes { set; get; }
        public virtual DbSet<Complectation> Complectations { set; get; }
        public virtual DbSet<Complectation_Car> Complectation_Cars { set; get; }
        public virtual DbSet<Features> Features { set; get; }
        public virtual DbSet<PrePurchaseWorks> PrePurchaseWorks { set; get; }
        public virtual DbSet<PrePurchaseWorks_Complectation> PrePurchaseWorks_Complectations { set; get; }
        public virtual DbSet<Purchase> Purchases { set; get; }
        public virtual DbSet<Purchase_Car> Purchase_Cars { set; get; }
        public virtual DbSet<Purchase_PrePurchaseWorks> Purchase_PrePurchaseWorks { set; get; }
        public virtual DbSet<Worker> Workers { set; get; }
    }
}