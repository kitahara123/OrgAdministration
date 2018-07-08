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

namespace OrgAdministration
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		PresenterMainWindow p;

		public MainWindow()
		{
			InitializeComponent();
			MainGrid.DataContext = p = new PresenterMainWindow();
			
		}


		private void People_MouseDoubleClick(object sender, MouseButtonEventArgs e) =>
						new EmployeeEditor(People.SelectedItem as Employee).ShowDialog();

		private void AddEmployee_Click(object sender, RoutedEventArgs e) =>
						new EmployeeEditor().ShowDialog();

		private void Departments_Click(object sender, RoutedEventArgs e) =>
						new DepartmentEditor().ShowDialog();

		private void SetTestData_Click(object sender, RoutedEventArgs e) =>
				Model.SetTestData();

		private void MainWindow_OnClose(object sender, EventArgs e)
		{
			Model.SaveDeps();
			Model.SavePeople();
		}
		private void Employee_Delete(object sender, EventArgs e)
		{
			Employee emp = People.SelectedItem as Employee;
			if (emp != null)
			{
				Model.Employees.Remove(emp);
				Model.deletedEmps.Add(emp);
			}
			
			
		}

	}
}
