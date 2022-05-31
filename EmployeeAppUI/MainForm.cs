using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EmployeeApp;

namespace EmployeeAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список всех сотрудников, загружаемых из файла
        /// </summary>
        private List<BaseEmployee> Employees { get; set; } = Project.GetEmployees();

        /// <summary>
        /// Строковая константа для отображения в <see cref="employeeTypeComboBox"/>
        /// </summary>
        private const string AllTypes = "Все";

        public MainForm()
        {
            InitializeComponent();
            InitControls();
        }

        /// <summary>
        /// Инициализация некоторых элементов управления начальными значениями
        /// </summary>
        private void InitControls()
        {
            employeeListBox.Items.AddRange(Employees.ToArray());

            employeeTypeComboBox.Items.Add(AllTypes);
            var values = Enum.GetValues(typeof(EmployeeType)).Cast<EmployeeType>().ToArray();
            foreach (var item in values)
            {
                employeeTypeComboBox.Items.Add(item.ToString().Replace('_', ' '));
            }
            employeeTypeComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Событие нажатия на кнопку "Добавить"
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object s, EventArgs e)
        {
            var eForm = new EmployeeForm();
            eForm.ShowDialog();

            if (eForm.DialogResult != DialogResult.OK)
                return;

            ConvertAndAddEmployee(eForm.CurrentEmployee, eForm.ExtraInfo);
            SortList();
        }

        /// <summary>
        /// Событие нажатия на кнопку "Изменить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, EventArgs e)
        {
            var index = employeeListBox.SelectedIndex;
            var employee = employeeListBox.SelectedItem as BaseEmployee;

            if (index == -1)
                return;

            var eForm = new EmployeeForm(employee);
            eForm.ShowDialog();

            if (eForm.DialogResult != DialogResult.OK)
                return;

            ConvertAndReplaceEmployee(eForm.CurrentEmployee, eForm.ExtraInfo, index);
            SortList();
        }

        /// <summary>
        /// Приведение к нужному типу и сохранение в список
        /// </summary>
        /// <param name="employee">Приводимый параметр</param>
        /// <param name="info">Дополнительная информация</param>
        private void ConvertAndAddEmployee(BaseEmployee employee, string info)
        {
            switch (employee.EmployeeType)
            {
                case EmployeeType.Рабочий:
                    var worker = employee as Worker;
                    worker.HeadLFM = info;
                    AddEmployee(worker);
                    break;

                case EmployeeType.Контролёр:
                    var controller = employee as Controller;
                    controller.EquipmentName = info;
                    AddEmployee(controller);
                    break;

                case EmployeeType.Руководитель_подразделения:
                    var unitHead = employee as UnitHead;
                    unitHead.UnitName = info;
                    AddEmployee(unitHead);
                    break;

                case EmployeeType.Директор:
                    var director = employee as Director;
                    director.CabinetNumber = info;
                    AddEmployee(director);
                    break;
            }
        }

        /// <summary>
        /// Добавление сотрудника в список
        /// </summary>
        /// <param name="employee">Сотрудник для добавления</param>
        private void AddEmployee(BaseEmployee employee)
        {
            Employees.Insert(0, employee);
            employeeListBox.Items.Insert(0, employee);
            employeeListBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Преобразование и обновление информации о сотруднике
        /// </summary>
        /// <param name="employee">Обновляемый сотрудник</param>
        /// <param name="info">Дополнительная информация</param>
        /// <param name="index">Индекс сотрудника в списке</param>
        private void ConvertAndReplaceEmployee(BaseEmployee employee, string info, int index)
        {
            switch (employee.EmployeeType)
            {
                case EmployeeType.Рабочий:
                    var worker = employee as Worker;
                    worker.HeadLFM = info;
                    ReplaceEmployee(worker, index);
                    break;

                case EmployeeType.Контролёр:
                    var controller = employee as Controller;
                    controller.EquipmentName = info;
                    ReplaceEmployee(controller, index);
                    break;

                case EmployeeType.Руководитель_подразделения:
                    var unitHead = employee as UnitHead;
                    unitHead.UnitName = info;
                    ReplaceEmployee(unitHead, index);
                    break;

                case EmployeeType.Директор:
                    var director = employee as Director;
                    director.CabinetNumber = info;
                    ReplaceEmployee(director, index);
                    break;
            }
        }

        /// <summary>
        /// Обновление сотрудника в списке
        /// </summary>
        /// <param name="employee">Сотрудник для изменения</param>
        /// <param name="index">Индекс сотрудника в списке</param>
        private void ReplaceEmployee(BaseEmployee employee, int index)
        {
            Employees.RemoveAt(index);
            Employees.Insert(index, employee);
            employeeListBox.Items.RemoveAt(index);
            employeeListBox.Items.Insert(index, employee);
            employeeListBox.SelectedIndex = index;
        }

        /// <summary>
        /// Сортировка списка в соответствии с выбранным типом в <see cref="employeeTypeComboBox"/>
        /// </summary>
        private void SortList()
        {
            employeeListBox.Items.Clear();

            if (employeeTypeComboBox.SelectedItem.ToString() == AllTypes)
            {
                employeeListBox.Items.AddRange(Employees.ToArray());
            }
            else
            {
                var sortedList = Project.SortList(Employees, (EmployeeType)employeeTypeComboBox.SelectedIndex - 1);
                employeeListBox.Items.AddRange(sortedList.ToArray());
            }
        }

        /// <summary>
        /// Событие удаления сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var employee = employeeListBox.SelectedItem as BaseEmployee;

            if (employee == null)
            {
                MessageBox.Show("Не выбран сотрудник для удаления.");
                return;
            }

            Employees.Remove(employee);
            employeeListBox.Items.Remove(employee);
        }

        private void employeeTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) => SortList();

        private void MainForm_FormClosing(object s, FormClosingEventArgs e) =>
           Project.SaveEmployees(Employees);
    }
}
