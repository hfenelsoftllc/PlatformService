namespace PlatformService.Data
{
    public static class DataSeeder
    {
        public static void SeedDb(IApplicationBuilder app)
        {
            using ( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any()){
                Console.WriteLine("---> seeding data");
                context.Platforms.AddRange(
                    new Models.Platform(){ Name="Dot net", Publisher="Microsoft", Cost="Free"},
                    new Models.Platform(){ Name="Sql Server Express", Publisher="Microsoft", Cost="Free"},
                    new Models.Platform(){ Name="Kubernetes", Publisher="Google", Cost="Free"}
                );
                context.SaveChanges();
            }
            else{
                Console.WriteLine("---> we already have data");
            }
        }
    }
}