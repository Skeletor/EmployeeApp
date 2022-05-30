using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeApp;

namespace EmployeeAppUI
{
    public partial class EmployeeForm : Form
    {
        public BaseEmployee CurrentEmployee { get; private set; }

        public string ExtraInfo { get; private set; }

        public EmployeeForm()
        {
            InitializeComponent();
            InitControls();

            CurrentEmployee = new Worker();
        }

        public EmployeeForm(BaseEmployee employee) : this()
        {
            FillEmployeeInfo(CurrentEmployee = employee);
        }

        private void InitControls()
        {
            FillComboBox(genderTypeComboBox, typeof(GenderType));
            FillComboBox(employeeTypeComboBox, typeof(EmployeeType));
        }

        private void FillComboBox(ComboBox cb, Type t)
        {
            var names = Enum.GetNames(t);
            foreach (var item in names)
            {
                cb.Items.Add(item.Replace('_', ' '));
            }

            cb.SelectedIndex = 0;
        }

        private void FillEmployeeInfo(BaseEmployee employee)
        {
            firstNameTextBox.Text = employee.FirstName;
            lastNameTextBox.Text = employee.LastName;
            middleNameTextBox.Text = employee.MiddleName;
            dateTimePicker.Value = employee.DateOfBirth;
            genderTypeComboBox.SelectedIndex = (int)employee.Gender;
            employeeTypeComboBox.SelectedIndex = (int)employee.EmployeeType;

            FillExtraInfo(employee);
        }

        private void FillExtraInfo(BaseEmployee employee)
        {
            var info = "";

            switch (employee.EmployeeType)
            {
                case EmployeeType.Рабочий:
                    var worker = employee as Worker;
                    info = worker.HeadLFM;
                    break;

                case EmployeeType.Контролёр:
                    var controller = employee as Controller;
                    info = controller.EquipmentName;
                    break;

                case EmployeeType.Руководитель_подразделения:
                    var unitHead = employee as UnitHead;
                    info = unitHead.UnitName;
                    break;

                case EmployeeType.Директор:
                    var director = employee as Director;
                    info = director.CabinetNumber;
                    break;
            }

            extraTextBox.Text = info;
        }

        private void employeeTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((EmployeeType)employeeTypeComboBox.SelectedIndex)
            {
                case EmployeeType.Рабочий:
                    dynamicLabel.Text = "ФИО начальника";
                    break;

                case EmployeeType.Контролёр:
                    dynamicLabel.Text = "Название оборудования";
                    break;

                case EmployeeType.Руководитель_подразделения:
                    dynamicLabel.Text = "Название подразделения";
                    break;

                case EmployeeType.Директор:
                    dynamicLabel.Text = "Номер кабинета";
                    break;
            }
        }

        private void SaveEmployeeInfo()
        {
            CurrentEmployee.FirstName = firstNameTextBox.Text;
            CurrentEmployee.LastName = lastNameTextBox.Text;
            CurrentEmployee.MiddleName = middleNameTextBox.Text;
            CurrentEmployee.Gender = (GenderType)genderTypeComboBox.SelectedIndex;
            CurrentEmployee.DateOfBirth = dateTimePicker.Value;
            ExtraInfo = extraTextBox.Text;
        }

        private void UpdateEmployeeType()
        {
            switch ((EmployeeType)employeeTypeComboBox.SelectedIndex)
            {
                case EmployeeType.Рабочий:
                    CurrentEmployee = new Worker();
                    SaveEmployeeInfo();
                    break;

                case EmployeeType.Контролёр:
                    CurrentEmployee = new Controller();
                    SaveEmployeeInfo();
                    break;

                case EmployeeType.Руководитель_подразделения:
                    CurrentEmployee = new UnitHead();
                    SaveEmployeeInfo();
                    break;

                case EmployeeType.Директор:
                    CurrentEmployee = new Director();
                    SaveEmployeeInfo();
                    break;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            UpdateEmployeeType();
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
