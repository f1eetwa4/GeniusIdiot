using ClassLibrary;
using GeniusIdiotConsoleApp;

namespace GeniusIdiotWindowsFormsApp
{
    public partial class mainForm : Form
    {
        private List<Question> questions;
        public Question? currentQuestion;
        private QuestionsStorage questionsStorage;
        private UsersResultStorage userStorage;
        private User user;
        private int questionNumber = 1;
        private bool isGameStarted = false;
        public mainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userStorage = new UsersResultStorage();

            questionsStorage = new QuestionsStorage();


            questionNumberLabel.Visible = false;
            questionTextLabel.Text = "Введите ваше ФИО";

            user = new User();

        }

        private void ShowNextQuestion()
        {
            var random = new Random();
            var index = random.Next(0, questions.Count);

            currentQuestion = questions[index];

            questionNumberLabel.Text = $"Вопрос №{questionNumber}";
            questionNumber++;

            questionTextLabel.Text = currentQuestion.QuestionText;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            
            if (isGameStarted)
            {
                if (!InputChecker.IsNumber(userAnswerTextBox.Text))
                {
                    MessageBox.Show("Введите число!");
                    userAnswerTextBox.Clear();
                    return;
                }

                var userAnswer = Convert.ToInt32(userAnswerTextBox.Text);
                if (currentQuestion.IsCorrectAnswer(userAnswer))
                {
                    user.IncreaseCorrectAnswersCount();
                }
                questions.Remove(currentQuestion);

                var endGame = questions.Count == 0;
                if (endGame)
                {
                    double percentage = Math.Round((double)user.CorrectAnswersCount * 100 / questionsStorage.Questions.Count);
                    user.Percentage = percentage;
                    MessageBox.Show($"\nПроцент правильных ответов: {percentage}%");

                    string diagnosis = Diagnosis.MakeDiagnosis(percentage);
                    user.Diagnosis = diagnosis;
                    MessageBox.Show($"{user.FullName}, ваш диагноз: {diagnosis}");

                    userStorage.AddResult(user);
                    RestartGame();
                    return;
                }
            }
            else
            {
                if (questionsStorage.Questions.Count == 0)
                {
                    MessageBox.Show("Добавьте хотя бы 1 вопрос!");
                    return;
                }
                if (!InputChecker.IsCorrectInput(userAnswerTextBox.Text))
                {
                    MessageBox.Show("ФИО не может быть пустым!");
                    userAnswerTextBox.Clear();
                    return;
                }
                

                user.FullName = userAnswerTextBox.Text;
                questions = questionsStorage.GetQuestions();
                isGameStarted = true;
                questionNumberLabel.Visible = true;
            }
            ShowNextQuestion();
            userAnswerTextBox.Clear();
        }

        private void buttonResults_Click(object sender, EventArgs e)
        {
            ResultsForm resultsForm = new ResultsForm(userStorage.GetResults());
            resultsForm.Show();
        }

        private void buttonQuestionList_Click(object sender, EventArgs e)
        {
            QuestionsForm questionsForm = new QuestionsForm(questionsStorage);
            questionsForm.Show();
        }
        private void RestartGame()
        {
            userStorage = new UsersResultStorage();

            questionsStorage = new QuestionsStorage();

            questions = questionsStorage.GetQuestions();

            questionNumberLabel.Visible = false;
            questionTextLabel.Text = "Введите ваше ФИО";

            user = new User();
            questionNumber = 1;
            isGameStarted = false;

            userAnswerTextBox.Clear();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void показатьРезультатыВикториыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultsForm resultsForm = new ResultsForm(userStorage.GetResults());
            resultsForm.ShowDialog();
        }

        private void перезапуститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void questionNumberLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

