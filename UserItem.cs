using System.Drawing;
namespace DatabaseTests
{
    public class UserItem : Item 
    {
        public string _Username;
        public string _Email;
        public string _Password;
        public string _Thumbnail;
        public UserPhone _UserPhone;
        public string Username {
            get { return _Username; }
            set { _Username = value; }
        }
        public string Email {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Password {
            get { return _Password; }
            set { _Password = value; }
        }
        public string Thumbnail {
            get { return _Thumbnail; }
            set { _Thumbnail = value; }
        }
        public UserPhone UserPhone { 
            get { return _UserPhone;  } 
            set { _UserPhone = value; }
        }
    }
}
