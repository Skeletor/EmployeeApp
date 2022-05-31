using System;

namespace EmployeeApp
{
    /// <summary>
    /// Базовый тип с информацией, свойственной для всех сотрудников
    /// </summary>
    public abstract class BaseEmployee
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public GenderType Gender { get; set; }

        /// <summary>
        /// Тип сотрудника
        /// </summary>
        public abstract EmployeeType EmployeeType { get; }

        /// <summary>
        /// Отображение сотрудника как "Имя Фамилия Отчество"
        /// </summary>
        /// <returns></returns>
        public override string ToString() => FirstName + ' ' + LastName + ' ' + MiddleName;
    }
}
