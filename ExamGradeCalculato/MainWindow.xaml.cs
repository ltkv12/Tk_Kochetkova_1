using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExamGradeCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получаем баллы из текстовых полей
                double task1 = double.Parse(Task1TextBox.Text);
                double task2 = double.Parse(Task2TextBox.Text);
                double task3 = double.Parse(Task3TextBox.Text);
                double task4 = double.Parse(Task4TextBox.Text);

                // Проверяем допустимость баллов
                if (task1 < 0 || task1 > 10 || task2 < 0 || task2 > 50 ||
                    task3 < 0 || task3 > 30 || task4 < 0 || task4 > 10)
                {
                    MessageBox.Show("Баллы должны быть в допустимых диапазонах:\n" +
                                  "Задание 1: 0-10\n" +
                                  "Задание 2: 0-50\n" +
                                  "Задание 3: 0-30\n" +
                                  "Задание 4: 0-10",
                                  "Ошибка",
                                  MessageBoxButton.OK,
                                  MessageBoxImage.Error);
                    return;
                }

                // Суммируем баллы
                double total = task1 + task2 + task3 + task4;

                // Определяем оценку
                string grade;
                if (total >= 70)
                    grade = "5 (отлично)";
                else if (total >= 40)
                    grade = "4 (хорошо)";
                else if (total >= 20)
                    grade = "3 (удовлетворительно)";
                else
                    grade = "2 (неудовлетворительно)";

                // Выводим результат
                ResultTextBlock.Text = $"Сумма баллов: {total}\nОценка: {grade}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите числовые значения для всех заданий",
                              "Ошибка",
                              MessageBoxButton.OK,
                              MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}",
                              "Ошибка",
                              MessageBoxButton.OK,
                              MessageBoxImage.Error);
            }
        }
    }
}