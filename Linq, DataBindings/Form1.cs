using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {


        Form2 GroupFrm = new Form2();
        Form3 StudFrm = new Form3();
        private BindingSource binding;
        private BindingSource _students;
        List<Group> Groups = new List<Group>();
      





        public Form1()
        {
            InitializeComponent();

            binding = new BindingSource();
            binding.DataSource = Groups;

            _students = new BindingSource();

            dataGridView2.DataSource = binding;
            listBox1.DataSource = _students;



            dataGridView2.RowHeaderMouseDoubleClick += DataGridView2_RowHeaderMouseDoubleClick;


            


        }

        private void DataGridView2_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            _students.DataSource = Groups[e.RowIndex].Students;
            _students.ResetBindings(true);

        }

        private void AddGroup_Click(object sender, EventArgs e)
        {
            if (GroupFrm.IsDisposed)
                GroupFrm = new Form2();
            if (!GroupFrm.Visible)
                GroupFrm.ShowDialog();
            else
                GroupFrm.Activate();

            Groups.Add(new Group(GroupFrm.name));
            binding.ResetBindings(true);
            Groups = Groups.OrderBy(x => x.Name).ToList();
            binding.DataSource = Groups;
            binding.ResetBindings(true);



        }

    

        private void AddStudent_Click(object sender, EventArgs e)
        {
            if (StudFrm.IsDisposed)
                StudFrm = new Form3();
            if (!StudFrm.Visible)
                StudFrm.ShowDialog();
            else
                StudFrm.Activate();
            if (dataGridView2.CurrentCell != null   ) { 
           
                Groups[dataGridView2.CurrentCell.RowIndex].Students.Add(new Student(StudFrm.name, StudFrm.surname));               
        }
            else
            {
                MessageBox.Show("Выберите группу");
                return;

            }

        }

        private void DeleteGroup_Click(object sender, EventArgs e)
        {
            Groups.RemoveAt(dataGridView2.CurrentCell.RowIndex);
            dataGridView2.CurrentCell.Dispose();
            binding.ResetBindings(true);

        }

        private void DeleteStudent_Click(object sender, EventArgs e)
        {
           
            _students.RemoveCurrent();
            _students.ResetBindings(true);
        }

        private void RenameGroup_Click(object sender, EventArgs e)
        {
            if (GroupFrm.IsDisposed)
                GroupFrm = new Form2();
            if (!GroupFrm.Visible)
                GroupFrm.ShowDialog();
            else
                GroupFrm.Activate();

            Groups[dataGridView2.CurrentCell.RowIndex].Name = GroupFrm.name;
            binding.ResetBindings(true);
        }
    }
}

