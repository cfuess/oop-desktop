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
            
            // instantiate object
            _fileManager = new FileManager();

            // get the saved data from the file system
            _dataStore = _fileManager.Load();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {

            EmployeeForm employeeForm = new EmployeeForm(_dataStore.Employees);
            employeeForm.Show();
        }


    }
}
