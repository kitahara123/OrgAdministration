using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgAdministration
{
	public class PresenterEmployeeEditor: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public Employee SelectedEmployee { get; set; }

		public Department Dep // Проперти при смене которой я хочу чтобы перерисовывался лейбл с объектом

		{ 
			get => SelectedEmployee.Dep;
			set 
			{
				SelectedEmployee.Dep = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedEmployee"));
			}
		}
	}
}
