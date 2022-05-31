using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace EmployeeApp
{
    /// <summary>
    /// Статический класс, предоставляющий методы для сохранения, загрузки и сортировки списков сотрудников
    /// </summary>
    public static class Project
    {
        /// <summary>
        /// Путь к файлу
        /// </summary>
        private static string FilePath =>
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Employees.json";

        /// <summary>
        /// Настройка для возможности сохранения производных типов
        /// </summary>
        private static JsonSerializerSettings Settings => new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        /// <summary>
        /// Сохранение списка сотрудников в файл
        /// </summary>
        /// <param name="employees">Список для сохранения</param>
        public static void SaveEmployees(List<BaseEmployee> employees)
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }

            var content = JsonConvert.SerializeObject(employees, Settings);

            File.WriteAllText(FilePath, content);
        }

        /// <summary>
        /// Загрузка списка сотрудников из файла
        /// </summary>
        /// <returns>Список для загрузки</returns>
        public static List<BaseEmployee> GetEmployees()
        {
            if (!File.Exists(FilePath))
            {
                return new List<BaseEmployee>();
            }

            var content = File.ReadAllText(FilePath);

            return JsonConvert.DeserializeObject<List<BaseEmployee>>(content, Settings)
                   ?? new List<BaseEmployee>();
        }

        /// <summary>
        /// Сортировка списка в соответствии с выбранным типом <see cref="EmployeeType"/>
        /// </summary>
        /// <param name="employees">Список для сортировки</param>
        /// <param name="type">Тип, по которому будет произведена выборка</param>
        /// <returns>Новый отсортированный список</returns>
        public static List<BaseEmployee> SortList(List<BaseEmployee> employees, EmployeeType type) =>
            new List<BaseEmployee>(employees).Where(x => x.EmployeeType == type).ToList();
    }
}
