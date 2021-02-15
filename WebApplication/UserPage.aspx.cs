using System;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication
{   public partial class UserPage : System.Web.UI.Page
    {   private Requests request = new Requests();
        protected void Block_users(string move, string status)
        {   for (int i = 0; i < GridView1.Rows.Count; i++)
            {   CheckBox chk = GridView1.Rows[i].FindControl("CheckBox1") as CheckBox;
                if (chk.Checked)
                {   int id = Convert.ToInt32(GridView1.Rows[i].Cells[1].Text);
                    if (move == "update") request.Update_status(id, status);
                    if (move == "delete") request.Delete_user(id);
                }
            }   GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {   a1.ServerClick += new EventHandler(a1_ServerClick);
            a2.ServerClick += new EventHandler(a2_ServerClick);
            a3.ServerClick += new EventHandler(a3_ServerClick);

            HttpCookie login = Request.Cookies["login"];
            HttpCookie sign = Request.Cookies["sign"];
            if (login!=null && sign!=null)
            {   if (sign.Value == SignGeneration.GetSign(login.Value+"sign"))
                {   request.Update_last_login(login.Value);
                    Label1.Text = " Welcome, " + login.Value + " !";
                    return;
                }
            }   Response.Redirect("Login.aspx");
        }
        protected void a1_ServerClick(object sender, EventArgs e)
        {   Can_user_do_move();
            Block_users("update", "Blocked");
            Can_user_do_move();
        }
        protected void a2_ServerClick(object sender, EventArgs e)
        {   Can_user_do_move();
            Block_users("update", "NOT blocked");
        }
        protected void a3_ServerClick(object sender, EventArgs e)
        {   Can_user_do_move();
            Block_users("delete", "");
            Can_user_do_move();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {Response.Redirect("Logout.aspx");}

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {   }
        protected void Page_Unload(object sender, EventArgs e)
        {  request.CloseConnection();  }

        private void Can_user_do_move()
        {   bool exit = false;
            HttpCookie login = Request.Cookies["login"];
            string temp = request.Pasword_and_status_by_login(login.Value);
            if (temp == "") exit = true; 
            else { string[] t = temp.Split('#'); if (t[1] == "Blocked") exit = true; }
            if (exit) Response.Redirect("Logout.aspx");
        }
    }
}