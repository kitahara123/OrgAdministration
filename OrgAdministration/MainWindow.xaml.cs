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
	public partial class MainWindow : Window, IView
	{
		public ItemCollection Data
		{
			get => People.Items;
		}

		BackEnd back;

		public MainWindow()
		{
			InitializeComponent();
			back = new BackEnd(this);
			back.LoadData();

		}


		private void People_MouseDoubleClick(object sender, MouseButtonEventArgs e) =>
						new EmployeeEditor(People.SelectedItem as Employee).ShowDialog();

	}
}
