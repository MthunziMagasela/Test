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

                ds.Tables[0].Rows[xmlRow]["Surname"] = txtSurname.Text;
                ds.Tables[0].Rows[xmlRow]["Username"] = txtUsername.Text;
                ds.Tables[0].Rows[xmlRow]["Cellphone"] = txtCellphone.Text;
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
                XmlElement Surname = xmlEmloyeeDoc.CreateElement("Surname");
                Surname.InnerText = txtSurname.Text;
                XmlElement Username = xmlEmloyeeDoc.CreateElement("Username");
                Username.InnerText = txtUsername.Text;
                XmlElement Cellphone = xmlEmloyeeDoc.CreateElement("Cellphone");
                Cellphone.InnerText = txtCellphone.Text;


                ParentElement.AppendChild(ID);
                ParentElement.AppendChild(Surname);
                ParentElement.AppendChild(Username);
                ParentElement.AppendChild(Cellphone);

                xmlEmloyeeDoc.DocumentElement.AppendChild(ParentElement);
                xmlEmloyeeDoc.Save(Server.MapPath("~/Employees.xml"));
                BindGrid();               
            }
            ClearControl();
        }

        private void ClearControl()
        {
            txtID.Text = string.Empty;
            txtSurname.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtCellphone.Text = string.Empty;
            txtID.Enabled = true;
        }

        protected void grdxml_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grdxml.SelectedRow;
            txtID.Text = (row.FindControl("lblEmpId") as Label).Text;
            txtSurname.Text = (row.FindControl("lblEmpName") as Label).Text;
            txtUsername.Text = (row.FindControl("lblEmpDesignation") as Label).Text;
            txtCellphone.Text = (row.FindControl("lblEmpEmailID") as Label).Text;
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
