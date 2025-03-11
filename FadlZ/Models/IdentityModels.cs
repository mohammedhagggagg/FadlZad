using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace FadlZ.Models
{
    public partial class Contact
    {
        public int ID { get; set; }
        public string  FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
    public partial class  Feedback
    {
        [Key]
        public int FeedID { get; set; }
        public string ProductName { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        
        
    }
    public partial class Product
    {
        [Key]
        public string Pro_ID { get; set; }
        public string Pro_Name { get; set; }
        public string Pro_Description { get; set; }
        public string Pro_Type { get; set; }
        public string Pro_Image { get; set; }

        public string User_ID { get; set; }
        [ForeignKey("User_ID")]
        public virtual ApplicationUser User { get; set; }

        public int Cat_ID { get; set; }
        [ForeignKey("Cat_ID")]
        public virtual Category Cat { get; set; }
    }

    public partial class Category
    {
        [Key]
        public int Cat_ID { get; set; }
        public string Cat_Name { get; set; }
        public string Cat_Des { get; set; }
        
    } 
    public enum status
    {
        Single,Married
    }
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser  : IdentityUser
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string User_ID { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
        public DbSet<Product> products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feedback> Feeback { get; set; }
        public DbSet<Contact> Contacts { get; set; }


        // public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}