using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebCasino
{
    public partial class Players : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                dt = BUSINESS.Player.GetPlayer();
                if (dt.Rows.Count <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERROR", "alert('No player records.');", true);
                }
                else
                {
                    GridViewPlayers.DataSource = dt;
                    GridViewPlayers.DataBind();
                }
            }
            catch(Exception ex)
            {
                BUSINESS.Player.CatchExceptions(ex);
                ScriptManager.RegisterClientScriptBlock(this.ButtonAddPlayer, GetType(), "Warning", "window.alert('Error showing the players.');", true);
            }
        }

        protected void ButtonAddPlayer_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = TextBoxAddPlayerName.Text.Trim();
                string LastName = TextBoxAddPlayerLastName.Text.Trim();
                decimal MoneyAccount = Convert.ToDecimal(TextBoxAddMoneyAccount.Text.Trim());
                if (Name.Length != 0 || LastName.Length != 0)
                {
                    BUSINESS.Player.AddPlayer(Name, LastName, MoneyAccount);
                    DataTable dt = new DataTable();
                    dt = BUSINESS.Player.GetPlayer();
                    GridViewPlayers.DataSource = dt;
                    GridViewPlayers.DataBind();

                    ScriptManager.RegisterClientScriptBlock(this.ButtonAddPlayer, GetType(), "Warning", "window.alert('Has been saved a new player.');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.ButtonAddPlayer, GetType(), "Warning", "window.alert('One or more values are empty.');", true);

                }
            }
            catch (Exception ex)
            {
                BUSINESS.Player.CatchExceptions(ex);
                ScriptManager.RegisterClientScriptBlock(this.ButtonAddPlayer, GetType(), "Warning", "window.alert('Error adding the new player.');", true);
            }
        }


        protected void ButtonUpdatePlayer_Click(object sender, EventArgs e)
        {
            try
            {
                int IdPlayer = Convert.ToInt32(Session["SelectedId"]);
                string Name = TextBoxUpdatePlayer.Text.Trim();
                string LastName = TextBoxUpdateLastName.Text.Trim();
                decimal MoneyAccount = Convert.ToDecimal(TextBoxUpdateMoneyAccount.Text.Trim());
                if (Name.Length != 0 || LastName.Length != 0)
                {
                    BUSINESS.Player.UpdatePlayer(IdPlayer, Name, LastName, MoneyAccount);
                    DataTable dt = new DataTable();
                    dt = BUSINESS.Player.GetPlayer();
                    GridViewPlayers.DataSource = dt;
                    GridViewPlayers.DataBind();

                    ScriptManager.RegisterClientScriptBlock(this.ButtonUpdatePlayer, GetType(), "Warning", "window.alert('A new player has been saved.');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.ButtonUpdatePlayer, GetType(), "Warning", "window.alert('One or more fields are empty.');", true);

                }
            }
            catch (Exception ex)
            {
                BUSINESS.Player.CatchExceptions(ex);
                ScriptManager.RegisterClientScriptBlock(this.ButtonUpdatePlayer, GetType(), "Warning", "window.alert('Error adding the new player.');", true);
            }
        }

        protected void ButtonDeletePlayer_Click(object sender, EventArgs e)
        {
            try
            {
                int IdPlayer = Convert.ToInt32(Session["SelectedId"]);
                BUSINESS.Player.DeletePlayer(IdPlayer);
                DataTable dt = new DataTable();
                dt = BUSINESS.Player.GetPlayer();
                GridViewPlayers.DataSource = dt;
                GridViewPlayers.DataBind();
                ScriptManager.RegisterClientScriptBlock(this.ButtonUpdatePlayer, GetType(), "Warning", "window.alert('The selected player have been removed.');", true);

            }
            catch (Exception ex)
            {
                BUSINESS.Player.CatchExceptions(ex);
                ScriptManager.RegisterClientScriptBlock(this.ButtonUpdatePlayer, GetType(), "Warning", "window.alert('Error deleting the selected player.');", true);
            }
        }

        protected void GridViewPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se obtiene la fila seleccionada del gridview
            GridViewRow row = GridViewPlayers.SelectedRow;
            //Obtengo el id de la entidad que se esta editando
            Session["SelectedId"] = Convert.ToInt32(row.Cells[1].Text);
            Session["SelectedName"] = row.Cells[2].Text;
            TextBoxUpdatePlayer.Text = Convert.ToString(Session["SelectedName"] = row.Cells[2].Text);
            TextBoxUpdateLastName.Text = Convert.ToString(Session["SelectedLastName"] = row.Cells[3].Text);
            TextBoxUpdateMoneyAccount.Text = Convert.ToString(Session["SelectedMoneyAccount"] = row.Cells[4].Text);
        }


        protected void GridViewPlayers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = new DataTable();
            GridViewPlayers.PageIndex = e.NewPageIndex;
            dt = BUSINESS.Player.GetPlayer();
            GridViewPlayers.DataSource = dt;
            GridViewPlayers.DataBind();
        }
        protected void GridViewPlayers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridViewPlayers.EditIndex = e.NewEditIndex;
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["Data"];
            this.GridViewPlayers.DataSource = dt;
            this.GridViewPlayers.DataBind();
        }
        protected void GridViewPlayers_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

            }
        }
    }
}