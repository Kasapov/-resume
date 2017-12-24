using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Threading;
using System.Xml.Serialization;
using System.IO;
using Timer = System.Threading.Timer;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        TimerCallback timeH;
        TimerCallback timeC;
        TimerCallback timeD;
        TimerCallback timeB;
        XmlSerializer formatter;
        Hotel hotel;
        Thread thread1;
        Thread thread2;
        Timer time;
        Timer time1;
        Timer time2;
        Timer time3;
        bool disposed = false;

        public Form1()
        {
            hotel = new Hotel(10);
            hotel.MakeRooms();
            InitializeComponent();
             formatter = new XmlSerializer(typeof(Room));

        }

        private void CloseHotel_Click(object sender, EventArgs e)
        {
            time.Dispose();
            time1.Dispose();
           
            hotel.SetAllFree();


        }
        private DataTable CreateTable()
        {
            //создаём таблицу
            DataTable dt = new DataTable("Hotel");
            //создаём три колонки
            DataColumn colID = new DataColumn("_id", typeof(Int32));
            DataColumn colSleep = new DataColumn("_sleeper", typeof(Int32));
            DataColumn colprice = new DataColumn("_price", typeof(Int32));
            DataColumn colDays = new DataColumn("_days", typeof(Int32));
            //добавляем колонки в таблицу
            dt.Columns.Add(colID);
            dt.Columns.Add(colSleep);
            dt.Columns.Add(colprice);
            dt.Columns.Add(colDays);
            return dt;
        }


        private DataTable ReadXml()
        {
            DataTable dt = null;
            try
            {
                //загружаем xml файл
                XDocument xDoc = XDocument.Load(@"C:\Users\stud32\Desktop\Спз 6\WindowsFormsApp6\XMLFile1.xml");
                //создаём таблицу
                dt = CreateTable();
                DataRow newRow = null;
                //получаем все узлы в xml файле
                foreach (XElement elm in xDoc.Descendants("Room"))
                {
                    //создаём новую запись
                    newRow = dt.NewRow();
                    
                   
                         
                     if (elm.Element("_id") != null)
                        {
                            //получаем значение атрибута
                            newRow["_id"] = int.Parse(elm.Element("_id").Value);
                        }
                  
                    //проверяем наличие xml элемента 
                    if (elm.Element("_sleeper") != null)
                    {
                        newRow["_sleeper"] = int.Parse(elm.Element("_sleeper").Value);
                    }

                    if (elm.Element("_price") != null)
                    {
                        newRow["_price"] = int.Parse(elm.Element("_price").Value);
                    }

                    if (elm.Element("_days") != null)
                    {
                        newRow["_days"] = int.Parse(elm.Element("_days").Value);
                    }
                    //добавляем новую запись в таблицу
                    dt.Rows.Add(newRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        private void ShowHotelInfo_Click(object sender, EventArgs e)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(hotel.Rooms.GetType());
            using (FileStream fs = new FileStream(@"C:\Users\stud32\Desktop\Спз 6\WindowsFormsApp6\XMLFile1.xml", FileMode.OpenOrCreate))
                x.Serialize(fs, hotel.Rooms);
            dataGridView1.DataSource = ReadXml();
        }



        private void HotelOpen_Click(object sender, EventArgs e)
        {
             timeH = new TimerCallback(OpenHotel);
         
            time = new Timer(timeH, null, 0, 1000);
            
            timeC = new TimerCallback(LeaveHotel);

            time1 = new Timer(timeC, null, 5000, 5000);

            timeD = new TimerCallback(TimeControl);

            time2 = new Timer(timeD, null, 0,3000);

           
        }

        public void TimeControl(object state)
        {

            if (hotel.Rooms.FindAll(x => x._days == 0).Count() == 0)
            {
                time.Dispose();
                disposed = true;
                MessageBox.Show("Hotel is full");
            }

           



        }

       

        public void Time1Control()
        {

            if (hotel.Rooms.FindAll(x => x._days == 0).Count() > 2 )
            {
                timeH = new TimerCallback(OpenHotel);

                time = new Timer(timeH, null, 0, 1000);
                disposed = false;

            }

        }

        public void OpenHotel(object state)
        {
            int j = hotel.Rooms.FindAll(x => x._days == 0).Count();
            if (j > 0)
            {
                hotel.Rooms[hotel.Rooms.IndexOf(hotel.Rooms.Find(x => x._days == 0))].SetNotFree();
                hotel.Rooms[hotel.Rooms.IndexOf(hotel.Rooms.Find(x => x._days == 0))].SetDays();
            }
       
        }
        public void LeaveHotel(object state)
        {

            if(hotel.Rooms.FindAll(x => x._days != 0).Count() > 1)
            {
                hotel.Rooms[hotel.Rooms.IndexOf(hotel.Rooms.Find(x => x._days != 0))].SetFree(); }

             if(disposed == true)
            {
                Time1Control();

            }
          
           


        }

      
    }
}
