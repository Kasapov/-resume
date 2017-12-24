using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    [Serializable]
   public class Room
    {
        public int _id;
        public int _sleeper;
        public int _price { get; set; }


        [NonSerialized]
        bool _free;


        public int _days { get; set; }

        public Room(int id,int sleeper, int price)
        {
            _sleeper = sleeper;
            _price = price;
            _free = true;
            _days = 0;
            _id = id;

        }
        public Room()
        { }

        public void SetDays()
        {
            Random rnd = new Random((new Random()).Next());
            int j = rnd.Next(1, 30);
            _days = j;

        }

        public void SetNotFree()
        {
            _free = false;

        }

        public void SetFree()
        {
            _free = true;
            _days = 0;

        }




    }
}
