using System;

namespace WorkflowEngine.Model.Security
{
    public class Login
    {
        public Login()
        {

        }

        public String Domain { get; set; }

        public String UserName { get; set; }

        public String Password { get; set; }
    }
}
