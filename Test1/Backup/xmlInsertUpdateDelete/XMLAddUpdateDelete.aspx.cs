using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

namespace xmlInsertUpdateDelete
{
    public partial class XMLAddUpdateDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            DataSet ds = new DataSet();

            ds.ReadXml(Server.MapPath("~/Employees.xml"));

            if (ds != null && ds.HasChanges())
            {

                grdxml.DataSource = ds;

                grdxml.DataBind();

            }
            else
            {

                grdxml.DataBind();

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text.ToString().Equals("Update Record"))
            {
                DataSet ds = new DataSet();

                ds.ReadXml(Server.MapPath("~/Employees.xml"));

                int xmlRow = Convert.ToInt32(Convert.ToString( ViewState["gridrow"]));

                ds.Tables[0].Rows[xmlRow]["Name"] = txtName.Text;
                ds.Tables[0].Rows[xmlRow]["Designation"] = txtDesignation.Text;
                ds.Tables[0].Rows[xmlRow]["EmailID"] = txtEmailID.Text;
                ds.Tables[0].Rows[xmlRow]["City"] = txtCity.Text;
                ds.Tables[0].Rows[xmlRow]["Country"] = txtCountry.Text;
                ds.Tables[0].Rows[xmlRow]["Technology"] = txtTechnology.Text;
                ds.WriteXml(Server.MapPath("~/Employees.xml"));
                BindGrid();

            }
            else
            {
                XmlDocument xmlEmloyeeDoc = new XmlDocument();
                xmlEmloyeeDoc.Load(Server.MapPath("~/Employees.xml"));
                XmlElement ParentElement = xmlEmloyeeDoc.CreateElement("Employee");
                XmlElement ID = xmlEmloyeeDoc.CreateElement("ID");
                ID.InnerText = txtID.Text;
                XmlElement Name = xmlEmloyeeDoc.CreateElement("Name");
                Name.InnerText = txtName.Text;
                XmlElement Designation = xmlEmloyeeDoc.CreateElement("Designation");
                Designation.InnerText = txtDesignation.Text;
                XmlElement EmailID = xmlEmloyeeDoc.CreateElement("EmailID");
                EmailID.InnerText = txtEmailID.Text;
                XmlElement City = xmlEmloyeeDoc.CreateElement("City");
                City.InnerText = txtCity.Text;
                XmlElement Country = xmlEmloyeeDoc.CreateElement("Country");
                Country.InnerText = txtCountry.Text;
                XmlElement Technology = xmlEmloyeeDoc.CreateElement("Technology");

                Technology.InnerText = txtTechnology.Text;
                ParentElement.AppendChild(ID);
                ParentElement.AppendChild(Name);
                ParentElement.AppendChild(Designation);
                ParentElement.AppendChild(EmailID);
                ParentElement.AppendChild(City);
                ParentElement.AppendChild(Country);
                ParentElement.AppendChild(Technology);
                xmlEmloyeeDoc.DocumentElement.AppendChild(ParentElement);
                xmlEmloyeeDoc.Save(Server.MapPath("~/Employees.xml"));
                BindGrid();               
            }
            ClearControl();
        }

        private void ClearControl()
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtDesignation.Text = string.Empty;
            txtEmailID.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtTechnology.Text = string.Empty;
            txtID.Enabled = true;
        }

        protected void grdxml_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grdxml.SelectedRow;
            txtID.Text = (row.FindControl("lblEmpId") as Label).Text;
            txtName.Text = (row.FindControl("lblEmpName") as Label).Text;
            txtDesignation.Text = (row.FindControl("lblEmpDesignation") as Label).Text;
            txtEmailID.Text = (row.FindControl("lblEmpEmailID") as Label).Text;
            txtCity.Text = (row.FindControl("lblEmpCity") as Label).Text;
            txtCountry.Text = (row.FindControl("lblEmpCountry") as Label).Text;
            txtTechnology.Text = (row.FindControl("lblEmpTechnology") as Label).Text;
            ViewState["gridrow"] = row.RowIndex.ToString();
            btnAdd.Text = "Update Record";
            txtID.Enabled = false;


            
        }

        protected void grdxml_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/Employees.xml"));            
            ds.Tables[0].Rows.RemoveAt(e.RowIndex);
            ds.WriteXml(Server.MapPath("~/Employees.xml"));
            BindGrid();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl();

        }

    }
}
