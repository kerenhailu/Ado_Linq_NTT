using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ado_Linq_NTT.Models
{
    public class Room
    {
        public Room(int iD, int roomNumber, string tYPE, bool isBlank, int price)
        {
            ID = iD;
            RoomNumber = roomNumber;
            TYPE = tYPE;
            IsBlank = isBlank;
            Price = price;
        }

        public int ID { get; set; }
        public int RoomNumber { get; set; }
        public string  TYPE{ get; set; }
        public bool IsBlank { get; set; }
            public int Price { get; set; }
    }
}
