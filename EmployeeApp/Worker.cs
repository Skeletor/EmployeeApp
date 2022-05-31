namespace EmployeeApp
{
    /// <summary>
    /// Тип "Рабочий"
    /// </summary>
    public class Worker : BaseEmployee
    {
        /// <summary>
        /// ФИО руководителя
        /// </summary>
        public string HeadLFM { get; set; }

        /// <summary>
        /// Тип сотрудника, определяемый как <see cref="EmployeeType.Рабочий"/>
        /// </summary>
        public override EmployeeType EmployeeType => EmployeeType.Рабочий;
    }
}
