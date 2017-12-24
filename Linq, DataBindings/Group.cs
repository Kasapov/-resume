using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{

    public class Group
    {
        
        public string Name { get; set; }

        public virtual IList<Student> Students { get; set; }

        public Group()
        {
            Students = new List<Student>();
        }
        public Group(string name)
        {
            Name = name;
            Students = new List<Student>();
        }
        


    }
}
