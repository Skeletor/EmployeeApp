namespace EmployeeApp
{
    /// <summary>
    /// Тип "Директор"
    /// </summary>
    public class Director : BaseEmployee
    {
        /// <summary>
        /// Номер кабинета. Может иметь вид, например, "123-Ф"
        /// </summary>
        public string CabinetNumber { get; set; }

        /// <summary>
        /// Тип сотрудника, определяемый как <see cref="EmployeeType.Директор"/>
        /// </summary>
        public override EmployeeType EmployeeType => EmployeeType.Директор;
    }
}
