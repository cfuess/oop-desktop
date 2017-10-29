
using EmployeeTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeTracker
{
    public partial class EmployeeForm : Form
    {
        List<Employee> _employees;

        public EmployeeForm(List<Employee> employees)
        {
            InitializeComponent();
            _employees = employees;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.FirstName = txtFirst.Text;
            employee.LastName = txtLast.Text;
            employee.HireDate = DateTime.Parse(dtHireDate.Text);
            _employees.Add(employee);
        }
    }
}
