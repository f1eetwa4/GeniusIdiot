using ClassLibrary;
using GeniusIdiotConsoleApp;

namespace GeniusIdiotWindowsFormsApp
{
    public partial class mainForm : Form
    {
        private List<Question> questions;
        private List<Question> copiedQuestions;
        private Question currentQuestion;
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
            string pathResults = @"results.txt";
            userStorage = new UsersResultStorage(pathResults);

            string pathQuestions = @"questions.txt";
            questionsStorage = new QuestionsStorage(pathQuestions);

            questions = QuestionsStorage.GetQuestions(questionsStorage);
            copiedQuestions = QuestionsStorage.GetQuestions(questionsStorage);

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
            if (!InputChecker.IsCorrectInput(userAnswerTextBox.Text))
            {
                MessageBox.Show("ФИО не может быть пустым!");
                userAnswerTextBox.Clear();
                return;
            }

            if (isGameStarted)
            {
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
                    MessageBox.Show($"\nПроцент правильных ответов: {percentage}%");

                    string diagnosis = Diagnosis.MakeDiagnosis(percentage);
                    MessageBox.Show($"{user.FullName}, ваш диагноз: {diagnosis}");

                    user.Percentage = percentage;
                    user.Diagnosis = diagnosis;

                    string text = $"{user.FullName}|{user.Percentage}|{user.Diagnosis}";

                    userStorage.Users.Add(user);
                    UsersResultStorage.SaveResult("results.txt", text);
                    RestartGame();
                    return;
                }
            }
            else
            {

                user.FullName = userAnswerTextBox.Text;
                isGameStarted = true;
                questionNumberLabel.Visible = true;
            }
            ShowNextQuestion();
            userAnswerTextBox.Clear();
        }

        private void buttonResults_Click(object sender, EventArgs e)
        {
            ResultsForm resultsForm = new ResultsForm(userStorage.Users);
            resultsForm.Show();
        }

        private void buttonQuestionList_Click(object sender, EventArgs e)
        {
            QuestionsForm questionsForm = new QuestionsForm(questionsStorage);
            questionsForm.Show();
        }
        private void RestartGame()
        {
            string pathResults = @"results.txt";
            userStorage = new UsersResultStorage(pathResults);

            string pathQuestions = @"questions.txt";
            questionsStorage = new QuestionsStorage(pathQuestions);

            questions = QuestionsStorage.GetQuestions(questionsStorage);
            copiedQuestions = QuestionsStorage.GetQuestions(questionsStorage);

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
            ResultsForm resultsForm = new ResultsForm(userStorage.Users);
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

