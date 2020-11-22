using System;
using DeptManagerr.db;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DeptManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string cd;

            Console.Write("Olá usuário, digite o código do departamento:");
            cd = Console.ReadLine();

            using (var db = new employeesContext())
            {
                var GerenteDoDepartamento = db.DeptManager
                .Include(gd => gd.DeptNoNavigation) 
                .Include(gd => gd.EmpNoNavigation)
                .Where(gd => gd.DeptNoNavigation.DeptNo == cd)
                .OrderBy(gd => gd.ToDate);

                foreach (var GerenteDepartamento in GerenteDoDepartamento)
                {
                    Departments depart = GerenteDepartamento.DeptNoNavigation;
                    Employees ger = GerenteDepartamento.EmpNoNavigation;

                Console.WriteLine($"{depart.DeptName}, gerido por {ger.LastName}.");
                }

            }
        }
    }
}