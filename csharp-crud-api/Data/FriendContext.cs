using Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class FriendContext : DbContext
    {
        public FriendContext(DbContextOptions<FriendContext> options) : base(options)
        {
        }

        public DbSet<Friend> Friends { get; set; }
    }
}
