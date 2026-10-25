namespace GeniusIdiotWindowsFormsApp
{
    partial class QuestionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataQuestions = new DataGridView();
            label1 = new Label();
            textBoxQuestion = new TextBox();
            buttonAddQuestion = new Button();
            label2 = new Label();
            label3 = new Label();
            textBoxAnswerQuestion = new TextBox();
            label4 = new Label();
            textBoxNumberQuestion = new TextBox();
            label5 = new Label();
            buttonRemoveQuestion = new Button();
            ((System.ComponentModel.ISupportInitialize)dataQuestions).BeginInit();
            SuspendLayout();
            // 
            // dataQuestions
            // 
            dataQuestions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataQuestions.Location = new Point(12, 12);
            dataQuestions.Name = "dataQuestions";
            dataQuestions.ReadOnly = true;
            dataQuestions.RowTemplate.Height = 20;
            dataQuestions.Size = new Size(931, 378);
            dataQuestions.TabIndex = 0;
            dataQuestions.RowPostPaint += dataQuestions_RowPostPaint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 402);
            label1.Name = "label1";
            label1.Size = new Size(501, 20);
            label1.TabIndex = 1;
            label1.Text = "Чтобы добавить вопрос, введите текст вопроса, а также ответ на него:";
            // 
            // textBoxQuestion
            // 
            textBoxQuestion.Location = new Point(167, 433);
            textBoxQuestion.Name = "textBoxQuestion";
            textBoxQuestion.Size = new Size(776, 23);
            textBoxQuestion.TabIndex = 2;
            // 
            // buttonAddQuestion
            // 
            buttonAddQuestion.BackColor = Color.Lime;
            buttonAddQuestion.Font = new Font("Alef", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonAddQuestion.Location = new Point(12, 489);
            buttonAddQuestion.Name = "buttonAddQuestion";
            buttonAddQuestion.Size = new Size(127, 48);
            buttonAddQuestion.TabIndex = 3;
            buttonAddQuestion.Text = "Добавить вопрос";
            buttonAddQuestion.UseVisualStyleBackColor = false;
            buttonAddQuestion.Click += buttonAddQuestion_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 436);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 4;
            label2.Text = "Текст вопроса:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(12, 462);
            label3.Name = "label3";
            label3.Size = new Size(127, 20);
            label3.TabIndex = 5;
            label3.Text = "Ответ на вопрос:";
            // 
            // textBoxAnswerQuestion
            // 
            textBoxAnswerQuestion.Location = new Point(167, 459);
            textBoxAnswerQuestion.Name = "textBoxAnswerQuestion";
            textBoxAnswerQuestion.Size = new Size(776, 23);
            textBoxAnswerQuestion.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ButtonFace;
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.Location = new Point(16, 540);
            label4.Name = "label4";
            label4.Size = new Size(345, 20);
            label4.TabIndex = 7;
            label4.Text = "Чтобы удалить вопрос, введите номер вопроса:";
            // 
            // textBoxNumberQuestion
            // 
            textBoxNumberQuestion.Location = new Point(145, 568);
            textBoxNumberQuestion.Name = "textBoxNumberQuestion";
            textBoxNumberQuestion.Size = new Size(100, 23);
            textBoxNumberQuestion.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(16, 571);
            label5.Name = "label5";
            label5.Size = new Size(123, 20);
            label5.TabIndex = 9;
            label5.Text = "Номер вопроса:";
            // 
            // buttonRemoveQuestion
            // 
            buttonRemoveQuestion.BackColor = Color.Red;
            buttonRemoveQuestion.Font = new Font("Alef", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonRemoveQuestion.Location = new Point(16, 601);
            buttonRemoveQuestion.Name = "buttonRemoveQuestion";
            buttonRemoveQuestion.Size = new Size(123, 55);
            buttonRemoveQuestion.TabIndex = 10;
            buttonRemoveQuestion.Text = "Удалить вопрос";
            buttonRemoveQuestion.UseVisualStyleBackColor = false;
            buttonRemoveQuestion.Click += buttonRemoveQuestion_Click;
            // 
            // QuestionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(955, 668);
            Controls.Add(buttonRemoveQuestion);
            Controls.Add(label5);
            Controls.Add(textBoxNumberQuestion);
            Controls.Add(label4);
            Controls.Add(textBoxAnswerQuestion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(buttonAddQuestion);
            Controls.Add(textBoxQuestion);
            Controls.Add(label1);
            Controls.Add(dataQuestions);
            Name = "QuestionsForm";
            Text = "Questions";
            Load += Questions_Load;
            ((System.ComponentModel.ISupportInitialize)dataQuestions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataQuestions;
        private Label label1;
        private TextBox textBoxQuestion;
        private Button buttonAddQuestion;
        private Label label2;
        private Label label3;
        private TextBox textBoxAnswerQuestion;
        private Label label4;
        private TextBox textBoxNumberQuestion;
        private Label label5;
        private Button buttonRemoveQuestion;
    }
}