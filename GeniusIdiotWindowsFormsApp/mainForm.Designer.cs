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
            buttonResults = new Button();
            buttonQuestionList = new Button();
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
            questionNumberLabel.Location = new Point(12, 34);
            questionNumberLabel.Name = "questionNumberLabel";
            questionNumberLabel.Size = new Size(93, 19);
            questionNumberLabel.TabIndex = 1;
            questionNumberLabel.Text = "Вопрос №1";
            // 
            // questionTextLabel
            // 
            questionTextLabel.AutoSize = true;
            questionTextLabel.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            questionTextLabel.Location = new Point(12, 73);
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
            // buttonResults
            // 
            buttonResults.Location = new Point(12, 186);
            buttonResults.Name = "buttonResults";
            buttonResults.Size = new Size(148, 52);
            buttonResults.TabIndex = 4;
            buttonResults.Text = "Показать результаты викторины";
            buttonResults.UseVisualStyleBackColor = true;
            buttonResults.Click += buttonResults_Click;
            // 
            // buttonQuestionList
            // 
            buttonQuestionList.Location = new Point(519, 186);
            buttonQuestionList.Name = "buttonQuestionList";
            buttonQuestionList.Size = new Size(148, 52);
            buttonQuestionList.TabIndex = 5;
            buttonQuestionList.Text = "Список вопросов";
            buttonQuestionList.UseVisualStyleBackColor = true;
            buttonQuestionList.Click += buttonQuestionList_Click;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(679, 421);
            Controls.Add(buttonQuestionList);
            Controls.Add(buttonResults);
            Controls.Add(userAnswerTextBox);
            Controls.Add(questionTextLabel);
            Controls.Add(questionNumberLabel);
            Controls.Add(nextButton);
            Name = "mainForm";
            Text = "Гений Идиот";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button nextButton;
        private Label questionNumberLabel;
        private Label questionTextLabel;
        private TextBox userAnswerTextBox;
        private Button buttonResults;
        private Button buttonQuestionList;
    }
}
