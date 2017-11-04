
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

        public event EventHandler SaveComplete;

        public EmployeeForm(List<Employee> employees)
        {
            InitializeComponent();
            _employees = employees;
            txtId.Text = GetNextId().ToString();
            ShowResults += results_ShowResults;
            ShowResults("");
        }

        public EmployeeForm(List<Employee> employees, int id) : this(employees)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            txtId.Text = employee.Id.ToString();
            txtFirst.Text = employee.FirstName;
            txtLast.Text = employee.LastName;
            dtHireDate.Text = employee.HireDate.ToString();
            ShowResults += results_ShowResults;
            ShowResults("");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Id = int.Parse(txtId.Text);
            employee.FirstName = txtFirst.Text;
            employee.LastName = txtLast.Text;
            employee.HireDate = DateTime.Parse(dtHireDate.Text);
            _employees.Add(employee);
            ShowResults("Saved");
            SaveComplete(this, EventArgs.Empty);
        }

        private void results_ShowResults(string message)
        {
            lblResult.Text = message;
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

        public int GetNextId()
        {
            if (!_employees.Any())
            {
                return 0;
            }
            else
            {
                return _employees.Max(p => p.Id) + 1;
            }
        }

    }
}
