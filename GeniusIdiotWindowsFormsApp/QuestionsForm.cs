using ClassLibrary;
using GeniusIdiotConsoleApp;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeniusIdiotWindowsFormsApp
{
    public partial class QuestionsForm : Form
    {
        private QuestionsStorage questionsStorage;
        public QuestionsForm()
        {
            InitializeComponent();
        }
        public QuestionsForm(QuestionsStorage questionsStorage) : this()
        {
            this.questionsStorage = questionsStorage;
        }

        private void Questions_Load(object sender, EventArgs e)
        {
            UpdateInfoTable();
        }
        private void dataQuestions_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var rowIndex = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dataQuestions.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void buttonAddQuestion_Click(object sender, EventArgs e)
        {
            string textQuestion = textBoxQuestion.Text;
            if (!InputChecker.IsCorrectInput(textQuestion))
            {
                MessageBox.Show("Напишите текст вопроса!");
                textBoxQuestion.Clear();
                return;
            }
            if (!InputChecker.IsNumber(textBoxAnswerQuestion.Text))
            {
                MessageBox.Show("Введите число(ответ на вопрос)!");
                return;
            }

            int answerQuestion = int.Parse(textBoxAnswerQuestion.Text);
            questionsStorage.AddQuestion("questions.txt", textQuestion, answerQuestion);
            textBoxQuestion.Clear();
            textBoxAnswerQuestion.Clear();
            UpdateInfoTable();
        }
        private void UpdateInfoTable()
        {
            dataQuestions.DataSource = null;
            dataQuestions.DataSource = questionsStorage.Questions;

            dataQuestions.Columns[0].Width = 700;
            dataQuestions.Columns[0].HeaderText = "Текст вопроса";

            dataQuestions.Columns[1].Width = 160;
            dataQuestions.Columns[1].HeaderText = "Ответ на вопрос";
        }

        private void buttonRemoveQuestion_Click(object sender, EventArgs e)
        {

            if (!InputChecker.IsNumber(textBoxNumberQuestion.Text))
            {
                MessageBox.Show("Введите число!");
                return;
            }

            int input = int.Parse(textBoxNumberQuestion.Text);
            if (input - 1 >= questionsStorage.Questions.Count || input < 1)
            {
                MessageBox.Show("Вопроса с таким номером нет!");
                return;
            }
            
            questionsStorage.RemoveQuestion("questions.txt", input);
            textBoxNumberQuestion.Clear();
            UpdateInfoTable();
        }
    }
}
