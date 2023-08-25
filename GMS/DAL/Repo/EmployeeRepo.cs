using DAL.EF.Models;
using DAL.iINTERFACES;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
        public class EmployeeRepo : Repo, IRepo<Employee, int, bool>
        {
            public bool Create(Employee obj)
            {
                db.Employees.Add(obj);
                return db.SaveChanges() > 0;
            }

            public bool Delete(int id)
            {
                var exobj = Get(id);
                db.Employees.Remove(exobj);
                return db.SaveChanges() > 0;
            }

            public List<Employee> Get()
            {
                return db.Employees.ToList();
            }

            public Employee Get(int id)
            {
                return db.Employees.Find(id);
            }

            public bool Update(Employee obj)
            {
                var exObj = Get(obj.Id);
                if (exObj == null)
                {
                    return false;
                }
                exObj.Name = obj.Name;
                exObj.UserName = obj.UserName;
                exObj.PhoneNumber = obj.PhoneNumber;
                exObj.Email = obj.Email;
                exObj.NID = exObj.NID;
                exObj.DOB = exObj.DOB;
                exObj.Gender = exObj.Gender;
                exObj.Address = exObj.Address;
                exObj.Status = exObj.Status;
                exObj.Image = exObj.Image;
                exObj.CreatedAt = exObj.CreatedAt;
                exObj.UserType = exObj.UserType;
                exObj.Department = exObj.Department;
                exObj.Salary = exObj.Salary;
                exObj.Password = exObj.Password;

                db.Employees.AddOrUpdate(exObj);
                return db.SaveChanges() > 0;
            }
        }
    
}
