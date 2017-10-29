using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeTracker.Data;

namespace EmployeeTracker
{
    public partial class EmployeeListForm : Form
    {
        //declare field variables
        private DataStore _dataStore;

        public EmployeeListForm()
        {
            InitializeComponent();

            _dataStore = new DataStore();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {

            EmployeeForm employeeForm = new EmployeeForm(_dataStore.Employees);
            employeeForm.Show();
        }

        private void btnViewEmployee_Click(object sender, EventArgs e)
        {
            // clear the list
            lstEmployees.Items.Clear();

            // put all the employees in the list
            foreach (var employee in _dataStore.Employees)
            {
                lstEmployees.Items.Add($"{employee.FirstName} {employee.LastName}");
            }
        }
    }
}
