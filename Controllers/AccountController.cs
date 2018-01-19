using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Project10.Controllers.Resource;
using Project10.Models;
using Project10.Persistence;

namespace Project10.Controllers
{
    //[Route("/account/new")]
    public class AccountController:Controller
    {
        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _SignInManager;
        private readonly IMapper _mapper;
        private readonly ProjectDbContext _context;

        [HttpPost("/account/new")]
        public async Task<IActionResult> register([FromBody] UserResource userresource )
        {
            if(ModelState.IsValid)
            {
             var user=_mapper.Map<UserResource,User>(userresource);
             var result = await _UserManager.CreateAsync(user,user.PasswordHash);
            // _context.User.Add(user);
            // await _context.SaveChangesAsync();
                if(result.Succeeded)
                {
                    return Ok(result);
                }
             
            }

            return BadRequest(userresource);
        }
        [HttpPost("/account/signin")]
        public async Task<IActionResult> login([FromBody]SigninResource sr)
        {
            if(ModelState.IsValid)
            {
                var result =await _SignInManager.PasswordSignInAsync(sr.email,sr.password,false,false);
                if(result.Succeeded)
                {
                    return Ok(new
                    {
                        Id= _UserManager.GetUserId(HttpContext.User),
                        name=_UserManager.GetUserName(HttpContext.User)
                    });
                }

            }
            return BadRequest(sr);
        }
        public AccountController(UserManager<User>UserManager,SignInManager<User>SignInManager,IMapper mapper,ProjectDbContext context)
        {
            _SignInManager=SignInManager;
            _UserManager=UserManager;
            _mapper=mapper;
            _context=context;
        }
    }
}