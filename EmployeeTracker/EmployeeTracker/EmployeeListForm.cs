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
        private FileManager _fileManager;

        public EmployeeListForm()
        {
            InitializeComponent();
            _fileManager = new FileManager();
            _dataStore = _fileManager.Load();
            loadEmployees();
            loadProjects();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {

            EmployeeForm employeeForm = new EmployeeForm(_dataStore.Employees);
            employeeForm.SaveComplete += saved_Completed;
            employeeForm.Show();
        }

        private void loadEmployees()
        {
            // clear the list
            lstEmployees.Items.Clear();

            // put all the employees in the list
            foreach (var employee in _dataStore.Employees)
            {
                lstEmployees.Items.Add($"{employee.FirstName} {employee.LastName}");
            }
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
    }
}
