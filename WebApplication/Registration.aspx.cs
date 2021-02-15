using System;
using System.Web;

namespace WebApplication
{   public partial class Registration : System.Web.UI.Page
    {   Requests request = new Requests();
        protected void Page_Load(object sender, EventArgs e)
        { Label1.Visible = false; }
        protected void Button2_Click(object sender, EventArgs e)
        {  Response.Redirect("Login.aspx", false);  }
        protected void Button1_Click(object sender, EventArgs e)
        {   Label1.Visible = false;
            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text=="")
            {  Label1.Text = " Необходимо заполнить все поля! "; Label1.Visible = true;  }
            else
            {   Label1.Visible = false;
                string answer = request.Pasword_and_status_by_login(TextBox1.Text);
                if (answer == "")
                {   request.Add_user(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text);
                    HttpCookie login = new HttpCookie("login", TextBox1.Text);
                    HttpCookie sign = new HttpCookie("sign", SignGeneration.GetSign(TextBox1.Text + "sign"));
                    Response.Cookies.Add(login); Response.Cookies.Add(sign);
                    Response.Redirect("UserPage.aspx", false);
                }
                else { Label1.Text = "Пользователь с таким логином уже существует !"; Label1.Visible = true; }
            }
        }
        protected void Page_Unload(object sender, EventArgs e)
        { request.CloseConnection(); }
    }
}