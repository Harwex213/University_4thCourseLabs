namespace Lab03.DataAccess
{
    public static class State
    {
        public static AppDbContext DbContext { get; set; } = new AppDbContext();
    }
}