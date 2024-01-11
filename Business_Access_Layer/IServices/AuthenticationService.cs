using ApplicationLayer.Bussiness_Logic_Layer.DTO;
using AutoMapper;
using Business_Access_Layer.ViewModels;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Services.UserAccountMapping;
using Newtonsoft.Json;
using RepositoryLayer.Data_Access_Layer.IRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Bussiness_Logic_Layer.IServices
{
    public class AuthenticationService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IAuthenticationRepository _AuthenticationRepository;
        public AuthenticationService(UserManager<ApplicationUser> userManager, ApplicationDbContext _context, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IAuthenticationRepository AuthenticationRepository,
           IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _AuthenticationRepository = AuthenticationRepository;
            this.userManager = userManager;
            context = _context;
            this.roleManager = roleManager;
            _mapper = mapper;
            _configuration = configuration;

        }
        private async Task<IdentityDto>GenerateAccessToken(string userName,string roleName)
        {
            var authstuSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var authClaims = new List<Claim>
                                    {

                                        new Claim(JwtRegisteredClaimNames.Jti,userName),
                                        new Claim(ClaimTypes.Role,roleName)
                                    };

            var Token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddDays(30),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authstuSigningKey, SecurityAlgorithms.HmacSha256)

                    );

            return new IdentityDto { Token = new JwtSecurityTokenHandler().WriteToken(Token), ExpirationDate = Token.ValidTo, roleName = roleName };

        }
        public async Task Register(RegisterDTO model)
        {
            var role = new IdentityRole();

            var userExists = await userManager.FindByNameAsync(model.UserName);

            if (userExists != null)
            {
                throw new Exception("you are a login user");
            }
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName

            };
            if (user.UserName == "ibrahimmahmoud")
            {
                role.Name = "Admin";
                role.Id = "1";
                await roleManager.CreateAsync(role);
                var Adminresult = await userManager.CreateAsync(user, model.Password);
                string Admin_user_id = user.Id;
                await userManager.AddToRoleAsync(user, role.Name);


            }
            else
            {
                role.Name = "Student";
                role.Id = "2";
                var result = await userManager.CreateAsync(user, model.Password);
                string user_id = user.Id;


                StudentDTO loginstudent = new StudentDTO()
                {

                    StudentID = user.Id,
                    StudentFName = model.StudentFName,
                    StudentLName = model.StudentLName,
                    StudentEmail = model.Email,

                };

                await userManager.AddToRoleAsync(user, role.Name);

                var student = _mapper.Map<StudentDTO, Student>(loginstudent);
                await _AuthenticationRepository.Register(student);

            }
        }





        
        public async Task<IdentityDto> Login(LoginDTO model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            string roleName = string.Empty;
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
              

                if (await userManager.IsInRoleAsync(user, "Admin"))
                {
                    roleName = "Admin";
                }
                else
                {
                    roleName = "Student";
                    StudentDTO student = new StudentDTO();
                    if (student.IsActive == false)
                    {

                        throw new Exception("401unauthorize");

                    }
                }

                return await GenerateAccessToken(user.UserName, roleName);
            }

            else return new IdentityDto();


            // Return the JSON response with token and status code
            //return new ContentResult
            //{
            //    Content = JsonConvert.SerializeObject(new { token = tokenString, StatusCode = StatusCodes.Status200OK }),
            //    ContentType = "application/json",
            //    StatusCode = StatusCodes.Status200OK,

            //};
        }
    }
}


//public async Task<ObjectResult> Login(LoginDTO model)
//{
//    var user = await userManager.FindByNameAsync(model.UserName);
//    string roleName = string.Empty;
//    if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
//    {
//        if (await userManager.IsInRoleAsync(user, "Admin"))
//        {
//            roleName = "Admin";
//        }
//        else
//        {
//            roleName = "Student";
//        }
//        var userRoles = await userManager.GetRolesAsync(user);
//        var authstuSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

//        var authClaims = new List<Claim>
//                        {

//                            new Claim(JwtRegisteredClaimNames.Jti, user.UserName),
//                            new Claim(ClaimTypes.Role,roleName),
//                        };

//        var Token = new JwtSecurityToken(
//                    issuer: _configuration["JWT:ValidIssuer"],
//                    audience: _configuration["JWT:ValidAudience"],
//                    expires: DateTime.Now.AddDays(30),
//                    claims: authClaims,
//                    signingCredentials: new SigningCredentials(authstuSigningKey, SecurityAlgorithms.HmacSha256)

//                );

//        if (await roleManager.RoleExistsAsync("Student"))
//        {
//            StudentDTO student = new StudentDTO();
//            if (student.IsActive == false)
//            {

//                return "401 unauthenticated";
//                //return new ContentResult() { Content = "401 unauthenticated", StatusCode = responseBadrequest };
//            }


//            string tokenString = new JwtSecurityTokenHandler().WriteToken(Token);
//            return new ObjectResult(tokenString, roleName);
//            // Return the JSON response with token and status code
//            //return new ContentResult
//            //{
//            //    Content = JsonConvert.SerializeObject(new { token = tokenString, StatusCode = StatusCodes.Status200OK }),
//            //    ContentType = "application/json",
//            //    StatusCode = StatusCodes.Status200OK,

//            //};
//        }
//    }
//    else
//    {
//        var authstuSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

//        var Token = new JwtSecurityToken(
//            issuer: _configuration["JWT:ValidIssuer"],
//            audience: _configuration["JWT:ValidAudience"],
//            expires: DateTime.Now.AddDays(30),
//            claims: authClaims,
//            signingCredentials: new SigningCredentials(authstuSigningKey, SecurityAlgorithms.HmacSha256)
//        );

//        var tokenString = new JwtSecurityTokenHandler().WriteToken(Token);
//        return tokenString;
//        // Return the JSON response with token and status code
//        //return new ContentResult
//        //{
//        //    Content = JsonConvert.SerializeObject(new { token = tokenString, StatusCode = StatusCodes.Status200OK }),
//        //    ContentType = "application/json",
//        //    StatusCode = StatusCodes.Status200OK
//        //};
//    }

//}

//            //var response = StatusCodes.Status401Unauthorized;
//            //return "401Unauthorized";
//            //return new ContentResult() { Content = "401Unauthorized", StatusCode = response };
//        }











   

  

