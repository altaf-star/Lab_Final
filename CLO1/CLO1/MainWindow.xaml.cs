using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CLO1
{
    public partial class MainWindow : Window
    {
        // Connection string to connect to the SQL Server database
        private string connectionString = @"Server=DESKTOP-UOE9NMU\SQLEXPRESS;Database=Clo;Integrated Security=True;";

        public MainWindow()
        {
            InitializeComponent();
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            try
            {
                List<QuizQuestion> questions = new List<QuizQuestion>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM QuizQuestion", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        questions.Add(new QuizQuestion
                        {
                            Id = (int)reader["Id"],
                            QuestionText = (string)reader["QuestionText"],
                            Options = (string)reader["Options"],
                            CorrectAnswer = (string)reader["CorrectAnswer"],
                            AssignedMarks = (int)reader["AssignedMarks"],
                            TimeLimit = (int)reader["TimeLimit"]
                        });
                    }
                }

                questionsDataGrid.ItemsSource = questions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void AddQuestion(QuizQuestion question)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO QuizQuestion (QuestionText, Options, CorrectAnswer, AssignedMarks, TimeLimit) VALUES (@QuestionText, @Options, @CorrectAnswer, @AssignedMarks, @TimeLimit)", connection);

                command.Parameters.AddWithValue("@QuestionText", question.QuestionText);
                command.Parameters.AddWithValue("@Options", question.Options);
                command.Parameters.AddWithValue("@CorrectAnswer", question.CorrectAnswer);
                command.Parameters.AddWithValue("@AssignedMarks", question.AssignedMarks);
                command.Parameters.AddWithValue("@TimeLimit", question.TimeLimit);

                command.ExecuteNonQuery();
            }

            LoadQuestions();
        }

        private void EditQuestion(QuizQuestion question)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE QuizQuestion SET QuestionText = @QuestionText, Options = @Options, CorrectAnswer = @CorrectAnswer, AssignedMarks = @AssignedMarks, TimeLimit = @TimeLimit WHERE Id = @Id", connection);

                command.Parameters.AddWithValue("@Id", question.Id);
                command.Parameters.AddWithValue("@QuestionText", question.QuestionText);
                command.Parameters.AddWithValue("@Options", question.Options);
                command.Parameters.AddWithValue("@CorrectAnswer", question.CorrectAnswer);
                command.Parameters.AddWithValue("@AssignedMarks", question.AssignedMarks);
                command.Parameters.AddWithValue("@TimeLimit", question.TimeLimit);

                command.ExecuteNonQuery();
            }

            LoadQuestions();
        }

        private void DeleteQuestion(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM QuizQuestion WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }

            LoadQuestions();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            QuizQuestion newQuestion = new QuizQuestion
            {
                QuestionText = "New Question",
                Options = "Option1, Option2, Option3, Option4",
                CorrectAnswer = "Option1",
                AssignedMarks = 1,
                TimeLimit = 30
            };

            AddQuestion(newQuestion);
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (questionsDataGrid.SelectedItem is QuizQuestion selectedQuestion)
            {
                selectedQuestion.QuestionText = "Edited Question";
                EditQuestion(selectedQuestion);
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (questionsDataGrid.SelectedItem is QuizQuestion selectedQuestion)
            {
                DeleteQuestion(selectedQuestion.Id);
            }
        }
    }

    public class QuizQuestion
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string Options { get; set; }
        public string CorrectAnswer { get; set; }
        public int AssignedMarks { get; set; }
        public int TimeLimit { get; set; }
    }
}
