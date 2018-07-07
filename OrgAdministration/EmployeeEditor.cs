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
	public partial class EmployeeEditor : Window, IView
	{
		BackEnd back;
		public ItemCollection Data {
			get => Deps.Items;
		}
		PresenterEmployeeEditor p;
		public EmployeeEditor(Employee selectedEmployee)
		{
			InitializeComponent();
			p = new PresenterEmployeeEditor();
			selectedEmployee.MyPresenter = p;
			p.SelectedEmployee = selectedEmployee;

			empGrid.DataContext = p;

			back = new BackEnd(this);
			back.LoadData();

		}

		private void Deps_OnChange(object sender, SelectionChangedEventArgs e)
		{
			MessageBox.Show(p.SelectedEmployee.ToString());
		}

	}
}
