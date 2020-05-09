using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebCK.Models
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var context = new ServerDBContext())
            {
                context.Database.CreateIfNotExists();
            }
        }
    }
    public class ServerDBContext: DbContext
    {
        // các thông tin truy xuất được lưu vào DB_WebCK
        public ServerDBContext(): base ("name=DB_WebCK")
        { 
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Specialize> Specializes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}