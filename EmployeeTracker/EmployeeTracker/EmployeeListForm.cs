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
        private int _selectedEmployee = 0;
        private int _selectedProject = 0;

        public EmployeeListForm()
        {
            InitializeComponent();
            _fileManager = new FileManager();
            _dataStore = _fileManager.Load();
            loadEmployeeList();
            loadProjectList();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            EmployeeForm employeeForm = new EmployeeForm(_dataStore.Employees);
            employeeForm.SaveComplete += save_Clicked;
            employeeForm.Show();
        }

        private void save_Clicked(object sender, EventArgs e)
        {
            _fileManager.Save(_dataStore);
            loadEmployeeList();
            loadProjectList();
        }

        private void loadEmployeeList()
        {
            //// clear the list
            //lstEmployees.Items.Clear();

            //// put all the employees in the list
            //foreach (var employee in _dataStore.Employees)
            //{
            //    lstEmployees.Items.Add(employee.FullName);
            //}

            // instead of loading the listbox with a bunch of strings 
            // bind to a collection of employees and set what is displayed
            lstEmployees.DataSource = null;
            lstEmployees.DataSource = _dataStore.Employees;
            lstEmployees.DisplayMember = "FullName";
        }

        private void loadProjectList()
        {
            //// clear the list
            //lstProjects.Items.Clear();

            //// put all the projects in the list
            //foreach (var project in _dataStore.Projects)
            //{
            //    lstProjects.Items.Add(project.Name);
            //}
            lstProjects.DataSource = null;
            lstProjects.DataSource = _dataStore.Projects;
            lstProjects.DisplayMember = "Name";
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            ProjectForm projectForm = new ProjectForm(_dataStore.Projects);
            projectForm.SaveComplete += save_Clicked;
            projectForm.Show();
        }

        private void lstEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListBox empListBox = sender as ListBox;
                Employee selectedEmployee = empListBox.SelectedItem as Employee;
                _selectedEmployee = selectedEmployee.Id;
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            EmployeeForm employeeForm = new EmployeeForm(_dataStore.Employees, _selectedEmployee);
            employeeForm.SaveComplete += save_Clicked;
            employeeForm.Show();
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (!isSure("Employee"))
            {
                return;
            }

            var employee = _dataStore.Employees.FirstOrDefault(emp => emp.Id == _selectedEmployee);
            if (employee != null)
            {
                _dataStore.Employees.Remove(employee);
            }
            save_Clicked(null, null);
        }

        private void btnEditProject_Click(object sender, EventArgs e)
        {
            ProjectForm projectForm = new ProjectForm(_dataStore.Projects, _selectedProject);
            projectForm.SaveComplete += save_Clicked;
            projectForm.Show();
        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            if (!isSure("Project"))
            {
                return;
            }

            var project = _dataStore.Projects.FirstOrDefault(proj => proj.Id == _selectedProject);
            if (project != null)
            {
                _dataStore.Projects.Remove(project);
            }
            save_Clicked(null, null);
        }

        private void lstProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListBox projListBox = sender as ListBox;
                Project selectedProject = projListBox.SelectedItem as Project;
                _selectedProject = selectedProject.Id;
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private bool isSure(string item)
        {
            string message = "Are you sure that you want to delete this " + item + "?";
            string caption = "Delete " + item;
            var result = MessageBox.Show(message, caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return false;
            }
            return true;
        }
    }
}
