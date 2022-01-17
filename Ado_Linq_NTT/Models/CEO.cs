using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ado_Linq_NTT.Models
{
    public class CEO
    {
        public CEO(int id, string fullName, int age, string email, int wage)
        {
            Id = id;
            FullName = fullName;
            Age = age;
            Email = email;
            Wage = wage;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int Wage { get; set; }

    }
}