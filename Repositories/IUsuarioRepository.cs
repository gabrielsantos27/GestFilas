namespace ProjetoBacharelatoFilas.Repositories
{

    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task<bool> RegisterUserAsync(string email, string password, int funcionarioId);
        Task Logout();
    }
    public interface ISeedUserRoleInitial
    {
        void SeedUsers();
        void SeedRoles();
        bool CriarFuncionario();
    }

}
