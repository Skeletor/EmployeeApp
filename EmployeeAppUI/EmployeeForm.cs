using System;
using System.Windows.Forms;
using EmployeeApp;

namespace EmployeeAppUI
{
    public partial class EmployeeForm : Form
    {
        /// <summary>
        /// Задаваемый индекс. Служит для определения возможности обновления типа сотрудника
        /// </summary>
        private int ComboBoxIndex { get; set; } = 0;

        /// <summary>
        /// Текущий сотрудник
        /// </summary>
        public BaseEmployee CurrentEmployee { get; private set; }

        /// <summary>
        /// Дополнительная информация
        /// </summary>
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

        /// <summary>
        /// Инициализация некоторых элементов управления значениями по умолчанию
        /// </summary>
        private void InitControls()
        {
            FillComboBox(genderTypeComboBox, typeof(GenderType));
            FillComboBox(employeeTypeComboBox, typeof(EmployeeType));
        }

        /// <summary>
        /// Заполнение <see cref="ComboBox"/> значениями по умолчанию
        /// </summary>
        /// <param name="cb"><see cref="ComboBox"/> для заполнения</param>
        /// <param name="t">Тип перечисления</param>
        private void FillComboBox(ComboBox cb, Type t)
        {
            var names = Enum.GetNames(t);
            foreach (var item in names)
            {
                cb.Items.Add(item.Replace('_', ' '));
            }

            cb.SelectedIndex = ComboBoxIndex = 0;
        }

        /// <summary>
        /// Заполнение данных о сотруднике
        /// </summary>
        /// <param name="employee"></param>
        private void FillEmployeeInfo(BaseEmployee employee)
        {
            firstNameTextBox.Text = employee.FirstName;
            lastNameTextBox.Text = employee.LastName;
            middleNameTextBox.Text = employee.MiddleName;
            dateTimePicker.Value = employee.DateOfBirth;
            genderTypeComboBox.SelectedIndex = (int)employee.Gender;
            employeeTypeComboBox.SelectedIndex = (int)employee.EmployeeType;
            ComboBoxIndex = employeeTypeComboBox.SelectedIndex;

            FillExtraInfo(employee);
        }

        /// <summary>
        /// Заполнение дополнительных данных о сотруднике
        /// </summary>
        /// <param name="employee"></param>
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

        /// <summary>
        /// Меняет текст в <see cref="Label"/> в зависимости от выбранного типа сотрудника.
        /// Также проверяет, пытается ли пользователь понизить сотрудника в должности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void employeeTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = employeeTypeComboBox.SelectedIndex;

            if (!CanChangeType(index))
            {
                MessageBox.Show("Нельзя понизить сотрудника в должности.");
                employeeTypeComboBox.SelectedIndex = ComboBoxIndex;
                return;
            }

            switch ((EmployeeType)index)
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

        /// <summary>
        /// Сохранение данных о сотруднике
        /// </summary>
        private void SaveEmployeeInfo()
        {
            CurrentEmployee.FirstName = firstNameTextBox.Text;
            CurrentEmployee.LastName = lastNameTextBox.Text;
            CurrentEmployee.MiddleName = middleNameTextBox.Text;
            CurrentEmployee.Gender = (GenderType)genderTypeComboBox.SelectedIndex;
            CurrentEmployee.DateOfBirth = dateTimePicker.Value;
            ExtraInfo = extraTextBox.Text;
        }

        /// <summary>
        /// Обновление типа сотрудника
        /// </summary>
        private void UpdateEmployeeType()
        {
            switch ((EmployeeType)employeeTypeComboBox.SelectedIndex)
            {
                case EmployeeType.Рабочий:
                    CurrentEmployee = new Worker();
                    break;

                case EmployeeType.Контролёр:
                    CurrentEmployee = new Controller();
                    break;

                case EmployeeType.Руководитель_подразделения:
                    CurrentEmployee = new UnitHead();
                    break;

                case EmployeeType.Директор:
                    CurrentEmployee = new Director();
                    break;
            }

            SaveEmployeeInfo();
        }

        /// <summary>
        /// Метод-проверка на ввод корректных значений в <see cref="TextBox"/>
        /// </summary>
        /// <returns>true, если все поля заполнены какими-либо данными. Иначе - false</returns>
        private bool IsValid()
        {
            return !(firstNameTextBox.Text.Trim() == ""
                  || lastNameTextBox.Text.Trim() == ""
                  || middleNameTextBox.Text.Trim() == ""
                  || extraTextBox.Text.Trim() == "");
        }

        /// <summary>
        /// Метод-обработка ситуации сохранения частично незаполненной информации о сотруднике
        /// </summary>
        /// <returns>true, если пользователь согласен на сохранение частичной информации.
        /// Иначе - false</returns>
        private new bool Validate()
        {
            if (!IsValid())
            {
                return MessageBox.Show("Одно или несколько полей остались незаполненными. " +
                    "Все равно сохранить?", "", MessageBoxButtons.OKCancel) != DialogResult.Cancel;
            }

            return true;
        }

        /// <summary>
        /// Метод-проверка на возможность смены типа сотрудника в <see cref="ComboBox"/>
        /// </summary>
        /// <param name="cbIndex">Текущий выбранный индекс</param>
        /// <returns>true, если выбранный индекс больше или равен <see cref="ComboBoxIndex"/></returns>
        private bool CanChangeType(int cbIndex) => cbIndex >= ComboBoxIndex;

        /// <summary>
        /// Событие нажатия на кнопку "ОК"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (!Validate())
                return;

            UpdateEmployeeType();
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Событие нажатия на кнопку "Отмена"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}
