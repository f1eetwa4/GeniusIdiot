namespace GeniusIdiotWindowsFormsApp
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nextButton = new Button();
            questionNumberLabel = new Label();
            questionTextLabel = new Label();
            userAnswerTextBox = new TextBox();
            buttonQuestionList = new Button();
            menuStrip1 = new MenuStrip();
            менюToolStripMenuItem = new ToolStripMenuItem();
            перезапуститьToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            показатьРезультатыВикториыToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // nextButton
            // 
            nextButton.Font = new Font("Tahoma", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            nextButton.Location = new Point(183, 249);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(326, 160);
            nextButton.TabIndex = 0;
            nextButton.Text = "Далее";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // questionNumberLabel
            // 
            questionNumberLabel.AutoSize = true;
            questionNumberLabel.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            questionNumberLabel.Location = new Point(12, 63);
            questionNumberLabel.Name = "questionNumberLabel";
            questionNumberLabel.Size = new Size(93, 19);
            questionNumberLabel.TabIndex = 1;
            questionNumberLabel.Text = "Вопрос №1";
            questionNumberLabel.Click += questionNumberLabel_Click;
            // 
            // questionTextLabel
            // 
            questionTextLabel.AutoSize = true;
            questionTextLabel.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            questionTextLabel.Location = new Point(12, 91);
            questionTextLabel.Name = "questionTextLabel";
            questionTextLabel.Size = new Size(135, 23);
            questionTextLabel.TabIndex = 2;
            questionTextLabel.Text = "Текст вопроса";
            // 
            // userAnswerTextBox
            // 
            userAnswerTextBox.Location = new Point(12, 128);
            userAnswerTextBox.Name = "userAnswerTextBox";
            userAnswerTextBox.Size = new Size(655, 23);
            userAnswerTextBox.TabIndex = 3;
            // 
            // buttonQuestionList
            // 
            buttonQuestionList.Location = new Point(265, 168);
            buttonQuestionList.Name = "buttonQuestionList";
            buttonQuestionList.Size = new Size(148, 52);
            buttonQuestionList.TabIndex = 5;
            buttonQuestionList.Text = "Список вопросов";
            buttonQuestionList.UseVisualStyleBackColor = true;
            buttonQuestionList.Click += buttonQuestionList_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { менюToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(679, 33);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // менюToolStripMenuItem
            // 
            менюToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { перезапуститьToolStripMenuItem, выходToolStripMenuItem, показатьРезультатыВикториыToolStripMenuItem });
            менюToolStripMenuItem.Font = new Font("Segoe UI", 13F);
            менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            менюToolStripMenuItem.Size = new Size(74, 29);
            менюToolStripMenuItem.Text = "Меню";
            // 
            // перезапуститьToolStripMenuItem
            // 
            перезапуститьToolStripMenuItem.Name = "перезапуститьToolStripMenuItem";
            перезапуститьToolStripMenuItem.Size = new Size(351, 30);
            перезапуститьToolStripMenuItem.Text = "Перезапустить";
            перезапуститьToolStripMenuItem.Click += перезапуститьToolStripMenuItem_Click;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(351, 30);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // показатьРезультатыВикториыToolStripMenuItem
            // 
            показатьРезультатыВикториыToolStripMenuItem.Name = "показатьРезультатыВикториыToolStripMenuItem";
            показатьРезультатыВикториыToolStripMenuItem.Size = new Size(351, 30);
            показатьРезультатыВикториыToolStripMenuItem.Text = "Показать результаты викторины";
            показатьРезультатыВикториыToolStripMenuItem.Click += показатьРезультатыВикториыToolStripMenuItem_Click;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(679, 421);
            Controls.Add(buttonQuestionList);
            Controls.Add(userAnswerTextBox);
            Controls.Add(questionTextLabel);
            Controls.Add(questionNumberLabel);
            Controls.Add(nextButton);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "mainForm";
            Text = "Гений Идиот";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button nextButton;
        private Label questionNumberLabel;
        private Label questionTextLabel;
        private TextBox userAnswerTextBox;
        private Button buttonQuestionList;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem менюToolStripMenuItem;
        private ToolStripMenuItem перезапуститьToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem показатьРезультатыВикториыToolStripMenuItem;
    }
}
