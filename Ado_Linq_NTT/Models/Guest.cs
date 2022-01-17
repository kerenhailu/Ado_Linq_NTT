using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ado_Linq_NTT.Models
{
    public class Guest
    {
        //public Guest(int id, string name, string lname, string gender, DateTime birthday, DateTime checkIn)
        //{
        //    Id = id;
        //    Name = name;
        //    Lname = lname;
        //    Gender = gender;
        //    Birthday = birthday;
        //    CheckIn = checkIn;
        //}

        public int Id { get; set; }
        public string Name { get; set; }
        public string Lname { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CheckIn { get; set; }
    }
}