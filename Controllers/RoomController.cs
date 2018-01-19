using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project10.Controllers.Resource;
using Project10.Models;
using Project10.Persistence;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System;

namespace Project10.Controllers
{
    public class RoomController : Controller
    {
        private readonly UserManager<User> _UserManager;
        private readonly ProjectDbContext _context;
        private readonly IMapper _mapper;

        [HttpGet("room/get")]
        public async Task<IEnumerable<RoomResource>> GetRoom()
        {
            var rooms =await _context.Room.Include(m => m.User).ToListAsync();
            return _mapper.Map<List<Room>,List<RoomResource>>(rooms);
        }

       // [Authorize]
        [HttpPost("room/set")]
        public async Task<IActionResult> SetRoom([FromBody] RoomResource rs)
        {
             if(!ModelState.IsValid)
            {
                return BadRequest(rs);
            }
            var room = _mapper.Map<RoomResource,Room>(rs);
            room.Acceptance="pending";
            room.UserId= _UserManager.GetUserId(HttpContext.User);
            await _context.Room.AddAsync(room);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<Room,RoomResource>(room);
            return Ok(result);
            
        }

        public RoomController(ProjectDbContext context, IMapper mapper,UserManager<User>UserManager)
        {
            this._mapper = mapper;
            this._context = context;
            _UserManager = UserManager;
        }

        private string Encrypt(string clearText)
{
    string EncryptionKey = "MAKV2SPBNI99212";
    byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
    using (Aes encryptor = Aes.Create())
    {
        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        encryptor.Key = pdb.GetBytes(32);
        encryptor.IV = pdb.GetBytes(16);
        using (MemoryStream ms = new MemoryStream())
        {
            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(clearBytes, 0, clearBytes.Length);
                
            }
            clearText = Convert.ToBase64String(ms.ToArray());
        }
    }
    return clearText;
}
 
private string Decrypt(string cipherText)
{
    string EncryptionKey = "MAKV2SPBNI99212";
    byte[] cipherBytes = Convert.FromBase64String(cipherText);
    using (Aes encryptor = Aes.Create())
    {
        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        encryptor.Key = pdb.GetBytes(32);
        encryptor.IV = pdb.GetBytes(16);
        using (MemoryStream ms = new MemoryStream())
        {
            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(cipherBytes, 0, cipherBytes.Length);
            }
            cipherText = Encoding.Unicode.GetString(ms.ToArray());
        }
    }
    return cipherText;
}
    }
}