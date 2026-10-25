using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeniusIdiotWindowsFormsApp
{
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
        }
        private List<User> users { get; set; }
        public ResultsForm(List<User> Users) : this()
        {
            users = Users;
        }
        private void ResultsForm_Load(object sender, EventArgs e)
        {
            dataResults.DataSource = users;

            dataResults.Columns[0].HeaderText = "ФИО";
            dataResults.Columns[0].Width = 250;

            dataResults.Columns[1].HeaderText = "Процент выполнения";
            dataResults.Columns[1].Width = 120;

            dataResults.Columns[2].HeaderText = "Диагноз";

            dataResults.Columns[3].HeaderText = "Правильных ответов";
            dataResults.Columns[3].Width = 150;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
