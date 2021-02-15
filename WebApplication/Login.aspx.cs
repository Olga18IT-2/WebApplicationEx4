using System;
using System.Web;

namespace WebApplication
{   public partial class Login : System.Web.UI.Page
    {   private Requests request = new Requests();
        protected void Page_Load(object sender, EventArgs e)
        {  Label1.Visible = false;  }
        protected void Button1_Click(object sender, EventArgs e)
        {   string answer = request.Pasword_and_status_by_login(TextBox1.Text);
            if (answer == "") { Label1.Text = "Пользователь с таким логином не существует !"; Label1.Visible = true; }
            else
            {   string[] answ = answer.Split('#');
                if(answ[1]=="Blocked") { Label1.Text = " Пользователь с данным логином заблокирован !"; Label1.Visible = true; }
                else
                {   if(answ[0]==TextBox2.Text)
                    {   HttpCookie login = new HttpCookie("login", TextBox1.Text);
                        HttpCookie sign = new HttpCookie("sign", SignGeneration.GetSign(TextBox1.Text + "sign"));
                        Response.Cookies.Add(login); Response.Cookies.Add(sign);
                        Response.Redirect("UserPage.aspx", false);
                    }
                    else
                    {   Label1.Text = "Неправильно введённый пароль !";
                        Label1.Visible = true;
                    }
                }
            }
        }
        protected void Page_Unload(object sender, EventArgs e)
        {  request.CloseConnection();  }
        protected void Button2_Click(object sender, EventArgs e)
        {  Response.Redirect("Registration.aspx", false);  }
    }
}
 