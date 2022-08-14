namespace Api.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add configurations
        }
    }
}
