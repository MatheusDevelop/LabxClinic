using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class UserInsertViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    
    
    public class UserLoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
