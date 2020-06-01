using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoomBooking.Models;

namespace RoomBooking.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Service> Services { get; set; }
        public DbSet<TypeRoom> TypeRooms { get; set; }
        public DbSet<TypeRoomService> RoomServices { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogPostCategory> blogPostCategories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        
        

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            /*========================================================================

            /* Relation 

                1. n - n: BlogPost - BlogCategory
                2. n - n: TypeRoom - Service

                */

            //===================== 1 ========================

            builder.Entity<BlogPostCategory>()
                .HasKey(bc => new { bc.CategoryId, bc.PostId });

            builder.Entity<BlogPostCategory>()
                .HasOne(bc => bc.Post)
                .WithMany(b => b.PostCategories)
                .HasForeignKey(bc => bc.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BlogPostCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.PostCategories)
                .HasForeignKey(bc => bc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            //===================== 2 ========================

            builder.Entity<TypeRoomService>()
                .HasKey(bc => new { bc.TypeRoomId, bc.ServiceId });

            builder.Entity<TypeRoomService>()
                .HasOne(bc => bc.Service)
                .WithMany(b => b.TypeRoomServices)
                .HasForeignKey(bc => bc.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<TypeRoomService>()
                .HasOne(bc => bc.TypeRoom)
                .WithMany(c => c.TypeRoomServices)
                .HasForeignKey(bc => bc.TypeRoomId)
                .OnDelete(DeleteBehavior.Cascade);

            /*========================================================================

            /* Default value 

                1. Avatar : ApplicationUser
                2. Avatar : Customer

             */

            builder.Entity<ApplicationUser>()
                  .Property(b => b.Avatar)
                  .HasDefaultValue("/uploads/avatar_default.jpg");

            builder.Entity<Customer>()
                  .Property(b => b.Avatar)
                  .HasDefaultValue("/uploads/employee-avatar.png");
        }
    }
}