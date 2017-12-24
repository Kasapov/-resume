using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp6
{
    class Hotel
    {
        bool ifopen;
        int _number;
        public virtual List<Room> Rooms { get; set; }
        public Hotel(int number)
        {
            ifopen = true;
               Rooms = new List<Room>(number);
            _number = number;

        }

        public void Close()
        {
            ifopen = false;

        }
        public void Open()
        {
            ifopen = true;

        }
        public void MakeRooms()
        {
            Random rnd = new Random((new Random()).Next());
            for (int i = 0; i < (_number); i++)
            {
                int j = rnd.Next(1, 5);
                if (j == 1)
                    Rooms.Add(new Room((i+1),j, 100));
                if (j == 2)
                    Rooms.Add(new Room((i+1),j, 200));
                if (j == 3)
                    Rooms.Add(new Room((i+1),j, 300));
                if (j == 4)
                    Rooms.Add(new Room((i+1),j, 400));
                if (j == 5)
                    Rooms.Add(new Room((i+1),j, 500));

            }
            Rooms.GroupBy(x => x._days);
        }

        public void SetAllFree()
        {
            for (int i = 0; i < (_number); i++)
            {

                Rooms[i].SetFree();



            }




        }

          

        

    }
}
