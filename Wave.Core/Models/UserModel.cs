using System;
using System.Collections.Generic;
using System.Text;

namespace Wave.Core.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string SenhaHash { get; set; }
    }
}
