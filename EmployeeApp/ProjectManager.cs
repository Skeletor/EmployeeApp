using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace EmployeeApp
{
    public static class ProjectManager
    {
        private static string FilePath =>
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Employees.json";

        private static JsonSerializerSettings Settings => new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        public static void SaveEmployees(List<BaseEmployee> employees)
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }

            var content = JsonConvert.SerializeObject(employees, Settings);

            File.WriteAllText(FilePath, content);
        }

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

        public static List<BaseEmployee> SortList(List<BaseEmployee> employees, EmployeeType type) =>
            new List<BaseEmployee>(employees).Where(x => x.EmployeeType == type).ToList();
    }
}
