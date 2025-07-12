namespace Task_Management_System.Entities.Data
{
    public class User
    {
        private int id;
        private string user_Name;
        private string display_Name;
        private string password_Hash;
        private string email;
        private int user_Group_Id;
        private int status_Id;
        private int created_By_User_Id;
        private DateTime created_Date;
        private int last_Updated_By_User_Id;
        private DateTime last_Updated_Date;
        private int deleted;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string User_Name
        {
            get { return user_Name; }
            set { user_Name = value; }
        }

        public string Display_Name
        {
            get { return display_Name; }
            set { display_Name = value; }
        }

        public string Password_Hash
        {
            get { return password_Hash; }
            set { password_Hash = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int User_Group_Id
        {
            get { return user_Group_Id; }
            set { user_Group_Id = value; }
        }

        public int Status_Id
        {
            get { return status_Id; }
            set { status_Id = value; }
        }

        public int Created_By_User_Id
        {
            get { return created_By_User_Id; }
            set { created_By_User_Id = value; }
        }

        public DateTime Created_Date
        {
            get { return created_Date; }
            set { created_Date = value; }
        }

        public int Last_Updated_By_User_Id
        {
            get { return last_Updated_By_User_Id; }
            set { last_Updated_By_User_Id = value; }
        }

        public DateTime Last_Updated_Date
        {
            get { return last_Updated_Date; }
            set { last_Updated_Date = value; }
        }

        public int Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}
