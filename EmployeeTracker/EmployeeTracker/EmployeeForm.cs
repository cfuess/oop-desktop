
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
        delegate void SetText(string message);
        event SetText ShowResults;

        public EmployeeForm(List<Employee> employees)
        {
            InitializeComponent();
            _employees = employees;
            ShowResults += results_ShowResults;
            ShowResults("");
        }

        private void results_ShowResults(string message)
        {
            lblResult.Text = message;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.FirstName = txtFirst.Text;
            employee.LastName = txtLast.Text;
            employee.HireDate = DateTime.Parse(dtHireDate.Text);
            _employees.Add(employee);
            ShowResults("Saved");
        }

        private void txtLast_TextChanged(object sender, EventArgs e)
        {
            ShowResults("");
        }

        private void txtFirst_TextChanged(object sender, EventArgs e)
        {
            ShowResults("");
        }

        private void dtHireDate_ValueChanged(object sender, EventArgs e)
        {
            ShowResults("");
        }

    }
}
