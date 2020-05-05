using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GigHub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //methanin thama ape thiyana prperties migration walata add karanne
        //migration walata add kanna ona hama property ekama methana define karala tyenna onaa

        public DbSet<Gig> Gigs { get; set; }//s ekak wadiyen tyna eka mata therenne nee Gig kiyala nathuwa Gigs kiyala neh tynne
        public DbSet<Genre> Genres { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        internal object Users(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}