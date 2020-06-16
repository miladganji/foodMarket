using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.User
{
    public class Users : Baseentity<Guid>
    {
        private Users()
        {

        }
        public Users(string _firstname, string _lastename, string _password, string _mobile)
        {
            this.FirsName = _firstname;
            this.CreateDate = DateTime.Now;
            this.LastName = _lastename;
            this.Mobile = _mobile;
            this.Password = _password;
            this.state = UserState.Active;
            
        }

        public string FirsName { get;private set; }
        public string LastName { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
       
        public DateTime CreateDate { get; private set; }
        public UserState state { get; private set; }


        public void InactiveUser()
        {
            this.state = UserState.InActive;
        }

        public void chanegPassword(string _NewPass)
        {
            if (this.state==UserState.InActive)
            {
                throw new Exception("User Is Not Active . . .");
            }

            this.state = UserState.Active;
        }

    }



    public enum UserState
    {

        Active,
        InActive
    }
}
