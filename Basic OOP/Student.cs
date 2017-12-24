using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum comp { bolshe, menshe, ravno };

namespace ConsoleApplication1
{
    public class Student
    {
        string FIO;
        ulong NumBook;
        int curs;
        double av_mark;
        double[] marks;
      

        public Student(string _fio, ulong _numbook, int _curs, double[] _mark)
        {
            bool error = false;
            if ((_curs < 1) || (_curs > 6))
                error = true;
            for (int i = 0; i < _mark.Length; ++i)
            {
                if ((_mark[i] < 0.0) || (_mark[i] > 100.0))
                    error = true;
            }
            if (error)
            {
                Console.Write("Error\n");
                return;
            }
            FIO = _fio;
            NumBook = _numbook;
            curs = _curs;
            marks = new double[10];
            for (int i = 0; i < _mark.Length; ++i)
            {
                av_mark = av_mark + _mark[i];
                marks[i] = _mark[i];
            }
            av_mark = av_mark / 10;
        }

        public void SetMark(int index, double mark)
        {
            if ((index < 0) || (index > 9) || (mark < 0.0) || (mark > 100.0))
            {
                Console.Write("Error\n");
                return;
            }
            marks[index] = mark;
        }
        public double GetMark(int i)
        {
            if ((i < 0) || (i > 9))
            {
                Console.Write("Error\n");
                return 0.0;
            }
            return marks[i];
        }
        public override string ToString()
        {

            return string.Format("Name = {0}\n",FIO);
        }

        public comp CompareAvMarkWith(Student student)
        {
            if (this.av_mark > student.av_mark)
            {
                return comp.bolshe;
            }
            if (this.av_mark == student.av_mark)
            {
                return comp.ravno;
            }
            return comp.menshe;
        }
        public double[] CompareMarksWith(Student student, double[] _raznica)
        {
            for (int i = 0; i < this.marks.Length; ++i)
            {
                _raznica[i] = this.marks[i] - student.marks[i];
            }

            return _raznica;
        }
    }
}
