using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HumanResources.Models;
using CSASPNETMessageBox;
using System.Web.Services;

public partial class wfEmployee : System.Web.UI.Page
{
    private HumanResourcesContext db = new HumanResourcesContext();

    /// <summary>
    /// handle load event
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        
        // only perform on page load
        if (!Page.IsPostBack)
        {
            // catch any database exceptions
            try
            {
                // table databinding
                IQueryable<Employee> employees = db.Employees;
                
                // linq query and adding datasource
                gvEmployees.DataSource = employees.ToList();

                // apply the databinding
                gvEmployees.DataBind();

                //set the login id
                lblUsername.Text = Page.User.Identity.Name;
            }
            catch (Exception)
            {
                // display messagebox
                string title = "My box title goes here";
                string text = "Do you want to Update this record?";
                // use my custom messagebox class
                MessageBox messageBox = new MessageBox(text, title, MessageBox.MessageBoxIcons.Question, MessageBox.MessageBoxButtons.YesOrNo, MessageBox.MessageBoxStyle.StyleA);
                messageBox.SuccessEvent.Add("YesModClick");

                // set text of asp:Literal#PopupBox in the aspx file
                PopupBox.Text = messageBox.Show(this);
            }
        }
    }
    /// <summary>
    /// actions to perform on the messagebox button click
    /// </summary>
    /// <param name="sender">object that triggered the event.</param>
    /// <param name="e">event</param>
    /// <returns>message based on the output of the method</returns>
    [WebMethod]
    public static string YesModClick(object sender, EventArgs e)
    {
        string strToRtn = "";
        // The code that you want to execute when the user clicked yes goes here
        return strToRtn;
    }

}