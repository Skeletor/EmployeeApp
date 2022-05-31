namespace EmployeeApp
{
    /// <summary>
    /// Тип "Контролёр"
    /// </summary>
    public class Controller : BaseEmployee
    {
        /// <summary>
        /// Название оборудования
        /// </summary>
        public string EquipmentName { get; set; }

        /// <summary>
        /// Тип сотрудника, определяемый как <see cref="EmployeeType.Контролёр"/>
        /// </summary>
        public override EmployeeType EmployeeType => EmployeeType.Контролёр;
    }
}
