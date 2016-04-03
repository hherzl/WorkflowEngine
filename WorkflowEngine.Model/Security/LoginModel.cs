using System;

namespace WorkflowEngine.Model.Security
{
    public class LoginModel
    {
        public LoginModel()
        {

        }

        public LoginModel(String domain, String userName, String password)
        {
            Domain = domain;
            UserName = userName;
            Password = password;
        }

        public String Domain { get; set; }

        public String UserName { get; set; }

        public String Password { get; set; }
    }
}
