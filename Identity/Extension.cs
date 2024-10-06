using ProjetoBacharelatoFilas.Repositories;

namespace ProjetoBacharelatoFilas.Identity
{
    public static class Extension
    {
        public static void SeedData(this WebApplication application)
        {
            using (var scope = application.Services.CreateScope())
            {
               var result= scope.ServiceProvider.GetRequiredService<ISeedUserRoleInitial>();
                result.SeedUsers();
                 result.SeedRoles();
            }
            //var scope = application.Services.GetRequiredService<ISeedUserRoleInitial>();
            //scope.SeedRoles();
            //scope.SeedUsers();
        }
    }
}
