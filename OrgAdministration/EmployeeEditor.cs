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
using System.Windows.Shapes;

namespace OrgAdministration
{
	/// <summary>
	/// Логика взаимодействия для Window1.xaml
	/// </summary>
	public partial class EmployeeEditor : Window
	{
		
		PresenterEmployeeEditor p;

		public EmployeeEditor(Employee selectedEmployee)
		{
			InitializeComponent();
			p = new PresenterEmployeeEditor();
			p.SelectedEmployee = selectedEmployee;

			empGrid.DataContext = p;

		}

		public EmployeeEditor()
		{
			InitializeComponent();
			p = new PresenterEmployeeEditor();
			empGrid.DataContext = p;

		}

		private void EmployeeEditor_onClose(object sender, EventArgs e)
		{
			p.SelectedEmployee.FullInfo = "nu i debilizm"; // Я НЕ ПОНИМАЮ КАК ЭТО СДЕЛАТЬ ПРАВИЛЬНО

		}

	}
}
