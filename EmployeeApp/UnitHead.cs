namespace EmployeeApp
{
    /// <summary>
    /// Тип "Руководитель подразделения"
    /// </summary>
    public class UnitHead : BaseEmployee
    {
        /// <summary>
        /// Название подразделения
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// Тип сотрудника, определяемый как <see cref="EmployeeType.Руководитель_подразделения"/>
        /// </summary>
        public override EmployeeType EmployeeType => EmployeeType.Руководитель_подразделения;
    }
}
