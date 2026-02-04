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
using TRPO12.Models;
using TRPO12.Service;

namespace TRPO12.Pages
{
    /// <summary>
    /// Логика взаимодействия для StudentFormPage.xaml
    /// </summary>
    public partial class StudentFormPage : Page
    {
        private StudentsService _service = new();
        public Student _student = new();
        bool isEdit = false;
        public StudentFormPage(Student? _editStudent = null)
        {
            InitializeComponent();
            if (_editStudent != null)
            {
                _student = _editStudent;
                isEdit = true;
            }
            if (_student.Passport == null) //если сущности паспорта нет - создаем её
                _student.Passport = new();
            DataContext = _student;
        }
        private void save(object sender, RoutedEventArgs e)
        {
            if (isEdit)
                _service.Commit();
            else
                _service.Add(_student);
            NavigationService.GoBack();
        }
        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
