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
using EmployeeTracker.Models;

namespace EmployeeTracker
{
    public partial class EmployeeListForm : Form
    {
        //declare field variables
        private DataStore _dataStore;
        private FileManager _fileManager;
        private bool _loading = true;

        public EmployeeListForm()
        {
            InitializeComponent();
            _fileManager = new FileManager();
            _dataStore = _fileManager.Load();
            loadEmployees();
            loadProjects();
            _loading = false;
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {

            EmployeeForm employeeForm = new EmployeeForm(_dataStore.Employees);
            employeeForm.SaveComplete += saved_Completed;
            employeeForm.Show();
        }

        private void loadEmployees()
        {
            //// clear the list
            //lstEmployees.Items.Clear();

            //// put all the employees in the list
            //foreach (var employee in _dataStore.Employees)
            //{
            //    lstEmployees.Items.Add($"{employee.FirstName} {employee.LastName}");
            //}

            _loading = true;
            lstEmployees.DataSource = null;
            lstEmployees.DisplayMember = "FullName";
            lstEmployees.DataSource = _dataStore.Employees;
            _loading = false;
        }

        private void loadProjects()
        {
            // clear the list
            lstProjects.Items.Clear();

            // put all the employees in the list
            foreach (var proj in _dataStore.Projects)
            {
                lstProjects.Items.Add(proj.Name);
            }
        }

        public void saved_Completed(object sender, EventArgs e)
        {
            _fileManager.Save(_dataStore);
            loadEmployees();
            loadProjects();
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            ProjectForm projectForm = new ProjectForm(_dataStore.Projects);
            projectForm.SaveComplete += saved_Completed;
            projectForm.Show();
        }

        private void lstEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loading == false)
            {
                //int value = (listBox1.SelectedItem as SomeData).Value;
                ListBox empListBox = sender as ListBox;
                Employee selectedEmployee = empListBox.SelectedItem as Employee;

                EmployeeForm employeeForm = new EmployeeForm(_dataStore.Employees, selectedEmployee.Id);
                employeeForm.SaveComplete += saved_Completed;
                employeeForm.Show();
            }
        }
    }
}
