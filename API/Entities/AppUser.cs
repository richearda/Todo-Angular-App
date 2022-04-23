using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUser
    {
    public int Id { get; set; } 
    public string UserName { get; set; }        
    public string Password { get; set; } 
    }
}