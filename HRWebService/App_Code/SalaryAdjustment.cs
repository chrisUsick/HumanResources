using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HumanResources.Models;
using System.Data.Linq;
using System.ServiceModel.Activation;

/// <summary>
/// SalaryAdjustment web service
/// </summary>
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class SalaryAdjustment : ISalaryAdjustment
{
    private HumanResourcesContext db = new HumanResourcesContext();

    /// <summary>
    /// update salary
    /// </summary>
    /// <param name="employeeId">id of employee</param>
    public void UpdateSalary(int employeeId)
    {
        // get the employee
        Employee employee = db.Employees.Find(employeeId);

        double adjustmentRate = 0;

        // time stan since employee has worked for the company
        TimeSpan yearsEmployed = DateTime.Now - employee.HireDate;

        // set adjustment rate
        if (yearsEmployed > new TimeSpan(365 * 10, 0, 0, 0, 0))
        {
            adjustmentRate = 1.25;
        }
        else if (yearsEmployed > new TimeSpan(365 * 5, 0, 0, 0))
        {
            adjustmentRate = 1.1;
        }
        else
        {
            adjustmentRate = 1.03;
        }

        // update salary and commit changes
        employee.Salary *= adjustmentRate;
        db.SaveChanges();
    }
}
