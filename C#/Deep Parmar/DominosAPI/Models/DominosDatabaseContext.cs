using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DominosAPI.Models
{
    public partial class DominosDatabaseContext : DbContext
    {
        public DominosDatabaseContext()
        {
        }

        public DominosDatabaseContext(DbContextOptions<DominosDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<ContactU> ContactUs { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Crust> Crusts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Pincode> Pincodes { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<PizzaOrderTopping> PizzaOrderToppings { get; set; }
        public virtual DbSet<PizzaSize> PizzaSizes { get; set; }
        public virtual DbSet<PizzaStore> PizzaStores { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Topping> Toppings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vcart> Vcarts { get; set; }
        public virtual DbSet<Vorder> Vorders { get; set; }
        public virtual DbSet<Vpincode> Vpincodes { get; set; }
        public virtual DbSet<VpizzaOrderTopping> VpizzaOrderToppings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PC0450\\MSSQL2017; Database=DominosDatabase; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Address");

                entity.Property(e => e.IsActive).HasDefaultValueSql("('TRUE')");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.InverseEmployee)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeAddressId");

                entity.HasOne(d => d.Pincode)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.PincodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PincodeId");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.InverseStore)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_StoreAddressId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserAddressId");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserId_ForCart");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("('TRUE')");

                entity.Property(e => e.ModificationTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StateId");
            });

            modelBuilder.Entity<ContactU>(entity =>
            {
                entity.HasIndex(e => e.ContactNumber, "UQ__ContactU__570665C6A8E0CFC5")
                    .IsUnique();

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Organization)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Crust>(entity =>
            {
                entity.ToTable("Crust");

                entity.Property(e => e.CreationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("('TRUE')");

                entity.Property(e => e.ModificationTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.PhoneNumber, "UQ__Employee__85FB4E38D6F44E42")
                    .IsUnique();

                entity.Property(e => e.CreationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("('TRUE')");

                entity.Property(e => e.ModificationTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.Property(e => e.CreationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.IsActive).HasDefaultValueSql("('TRUE')");

                entity.Property(e => e.MaxDiscount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MinAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ModificationTime).HasColumnType("datetime");

                entity.Property(e => e.OfferTitle)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OfferUrl).IsRequired();

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentTypeId");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(minute,(30),getdate()))");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderAddressId");

                entity.HasOne(d => d.DeliveryEmp)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DeliveryEmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveryEmpId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserId");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Crust)
                    .WithMany()
                    .HasForeignKey(d => d.CrustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_CrustId");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_OrderId");

                entity.HasOne(d => d.Pizza)
                    .WithMany()
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_PizzaId");

                entity.HasOne(d => d.Size)
                    .WithMany()
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_SizeId");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.NetAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OfferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_OfferId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_PaymentOrderId");

                entity.HasOne(d => d.PaymentTypeNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaymentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_PaymentType");
            });

            modelBuilder.Entity<PaymentDetail>(entity =>
            {
                entity.Property(e => e.CardName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CvvNumber)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Month)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PaytmNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpiId).HasMaxLength(50);

                entity.Property(e => e.Year)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentDetails_UserId");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("PaymentType");

                entity.Property(e => e.IsActive).HasDefaultValueSql("('TRUE')");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pincode>(entity =>
            {
                entity.HasKey(e => e.Pincode1)
                    .HasName("PK__Pincodes__546084482FF99667");

                entity.Property(e => e.Pincode1)
                    .ValueGeneratedNever()
                    .HasColumnName("Pincode");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Pincodes)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PincodeCityId");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Pincodes)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PincodeCountryId");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Pincodes)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PincodeStateId");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza");

                entity.Property(e => e.CreationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl).IsRequired();

                entity.Property(e => e.IsActive).HasDefaultValueSql("('TRUE')");

                entity.Property(e => e.ModificationTime).HasColumnType("datetime");

                entity.Property(e => e.PizzaName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaType).IsRequired();

                entity.Property(e => e.Rating).HasColumnType("decimal(2, 1)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoryId");
            });

            modelBuilder.Entity<PizzaOrderTopping>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaOrderToppings_OrderId");

                entity.HasOne(d => d.Pizza)
                    .WithMany()
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaOrderToppings_PizzaId");

                entity.HasOne(d => d.Topping)
                    .WithMany()
                    .HasForeignKey(d => d.ToppingId)
                    .HasConstraintName("FK_PizzaOrderToppings_ToppingId");
            });

            modelBuilder.Entity<PizzaSize>(entity =>
            {
                entity.HasKey(e => e.SizeId)
                    .HasName("PK__PizzaSiz__83BD097A76AA6E78");

                entity.ToTable("PizzaSize");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<PizzaStore>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK__PizzaSto__3B82F10116F0B41A");

                entity.ToTable("PizzaStore");

                entity.HasIndex(e => e.ContactNumber, "UQ__PizzaSto__570665C62C49366E")
                    .IsUnique();

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CreationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.ModificationTime).HasColumnType("datetime");

                entity.Property(e => e.Rating).HasColumnType("decimal(2, 1)");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.CreationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Rating).HasColumnType("decimal(2, 1)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Reviews_OrderId");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Reviews_StoreId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reviews_UserId");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CountryId");
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.Property(e => e.CreationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("('TRUE')");

                entity.Property(e => e.ModificationTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress, "UQ__Users__49A1474033DE4531")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "UQ__Users__85FB4E38873205BA")
                    .IsUnique();

                entity.Property(e => e.CreationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("('TRUE')");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ModificationTime).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vcart>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VCart");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl).IsRequired();

                entity.Property(e => e.PizzaName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaType).IsRequired();

                entity.Property(e => e.Rating).HasColumnType("decimal(2, 1)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Vorder>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VOrder");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeePhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.PizzaId).HasMaxLength(4000);

                entity.Property(e => e.PizzaName)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Vpincode>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VPincode");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VpizzaOrderTopping>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VPizzaOrderToppings");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rating).HasColumnType("decimal(2, 1)");

                entity.Property(e => e.ToppingCost).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.ToppingId).HasMaxLength(4000);

                entity.Property(e => e.ToppingName)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
