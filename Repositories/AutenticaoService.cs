
using Microsoft.AspNetCore.Identity;
using ProjetoBacharelatoFilas.Identity;
using ProjetoBacharelatoFilas.Models;

namespace ProjetoBacharelatoFilas.Repositories
{
    public class AutenticaoService : IAuthenticate
    {
        private readonly UserManager<AspNetUser> _userManager;
        private readonly SignInManager<AspNetUser> _signInManager;
        public AutenticaoService(UserManager<AspNetUser> userManager, SignInManager<AspNetUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RegisterUserAsync(string email, string password, int funcionarioId)
        {
            var applicationUser = new AspNetUser
            {
                UserName = email,
                Email = email,
                FuncionarioId= funcionarioId
            };
            var result = await _userManager.CreateAsync(applicationUser, password);
            if (result.Succeeded)
                await _signInManager.SignInAsync(applicationUser, isPersistent: false);
            return result.Succeeded;
        }
    }
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AspNetUser> _userManager;
        public SeedUserRoleInitial(RoleManager<IdentityRole> roleManager, UserManager<AspNetUser> user, IFuncionarioRepository funcionarioRepository)
        {
            _roleManager = roleManager;
            _userManager = user;
            _funcionarioRepository = funcionarioRepository;
        }
        public  void SeedRoles()
        {
            if (_userManager.FindByEmailAsync("martinho@instic.ao").Result == null)
            {
                CriarFuncionario();

                AspNetUser user = new AspNetUser();
                user.FuncionarioId = 1;
                user.UserName = "martinho@instic.ao";
                user.Email = "martinho@instic.ao";
                user.NormalizedUserName = "martinho@instic.ao".ToUpper();
                user.NormalizedEmail = "martinho@instic.ao".ToUpper();
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();
                IdentityResult result = _userManager.CreateAsync(user, "Martinho123#").Result;
                if (result.Succeeded)
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
        public  bool CriarFuncionario()
        {
            var funcionario = new Funcionario
            {
                NomeCompleto = "Domingos Martinho",
                NumeroIdentidade = "0034545454BA04",
                Telefone = "940243432",
                Email = "martinho@instic.ao"
            };

            return  _funcionarioRepository.Adicionar(funcionario).Result;
        }

        public void SeedUsers()
        {


            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }
    }
}
