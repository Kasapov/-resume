using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public class Student
    {
       
        public string Name { get; set; }
        public string Surname { get; set; }

        public Student(string _name, string _surname)
        {
            Name = _name;
            Surname = _surname;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Surname, Name);
        }

    }

  

}

