using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HumanResources.Models;
using System.Data.Linq;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SalaryAdjustment" in code, svc and config file together.
public class SalaryAdjustment : ISalaryAdjustment
{
    private HumanResourcesContext db = new HumanResourcesContext();

    /// <summary>
    /// update salary
    /// </summary>
    /// <param name="employeeId">id of employee</param>
    public void UpdateSalary(int employeeId)
    {
        Employee employee = db.Employees.Find(employeeId);
        double adjustmentRate = 0;

        TimeSpan yearsEmployeed = DateTime.Now - employee.HireDate;
        if (yearsEmployeed > new TimeSpan(365 * 10, 0, 0, 0, 0))
        {
            adjustmentRate = 1.25;
        }
        else if (yearsEmployeed > new TimeSpan(365 * 5, 0, 0, 0))
        {
            adjustmentRate = 1.1;
        }
        else
        {
            adjustmentRate = 0.03;
        }

        employee.Salary *= adjustmentRate;
        db.SaveChanges();
    }
}
