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
	/// Логика взаимодействия для DepartmentEditor.xaml
	/// </summary>
	public partial class DepartmentEditor : Window
	{
		PresenterDepartmentEditor p;
		public DepartmentEditor()
		{
			InitializeComponent();
			DepGrid.DataContext = p = new PresenterDepartmentEditor();

		}

		private void AddDep_Click(object sender, RoutedEventArgs e)
		{
			p.AddNewDep(newDepName.Text);
		}
	}
}
