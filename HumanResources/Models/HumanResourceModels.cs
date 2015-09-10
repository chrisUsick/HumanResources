using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace HumanResources.Models
{
    /// <summary>
    /// Employee model
    /// </summary>
    public class Employee
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage="First name is required")]
        [Display(Name="First\nName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Last name is required.")]
        [Display(Name = "Last\nName")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Hire date is required")]
        [Display(Name="Hire\nDate")]
        [DisplayFormat(DataFormatString="{0:d}")]
        [DataType(DataType.DateTime, ErrorMessage="valid date")]
        public DateTime HireDate { get; set; }

        [DisplayFormat(DataFormatString="{0,10:C}")]
        public double Salary { get; set; }
        
        public virtual Department Department { get; set; }
    }

    /// <summary>
    /// Department model
    /// </summary>
    public class Department
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage="Department Name is require")]
        [Display(Name="Department\nName")]
        public string DepartmentName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }

    public class HumanResourcesContext : DbContext
    {
        public HumanResourcesContext() : base("name=HumanResourcesContext") { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}