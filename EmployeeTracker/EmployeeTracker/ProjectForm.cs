using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeTracker.Models;

namespace EmployeeTracker
{
    public partial class ProjectForm : Form
    {
        private readonly List<Project> _projects;
        private Project _project = new Project();


        public ProjectForm(List<Project> projects)
        {
            InitializeComponent();
            _projects = projects;
            txtId.Text = GetNextId().ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _project.Id = int.Parse(txtId.Text);
            _project.Name = txtName.Text;
            _project.Description = txtDescription.Text;
            _project.StartDate = DateTime.Parse(dtStartDate.Text);
            _project.EndDate = DateTime.Parse(dtEndDate.Text);
            _projects.Add(_project);
        }

        private void loadTechnologies()
        {
            // clear the list
            lstTechnologies.Items.Clear();

            // put all the technologies in the list
            foreach (var tech in _project.Technologies)
            {
                lstTechnologies.Items.Add(tech);
            }
        }

        private void results_ShowResults(string message)
        {
            lblResult.Text = message;
        }

        private void lstTechnologies_Click(object sender, EventArgs e)
        {
            string tech = Prompt.ShowDialog("Technology", "Add");
            _project.Technologies.Add(tech);
            loadTechnologies();
        }

        public int GetNextId()
        {
            if (!_projects.Any())
            {
                return 0;
            }
            else
            {
                return _projects.Max(p => p.Id) + 1;
            }
        }


    }
}
