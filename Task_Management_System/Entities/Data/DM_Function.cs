namespace Task_Management_System.Entities.Data
{
    public class DM_Function
    {
        private int id;
        private string function_Name;
        private string function_Group_Id;
        private string icon;

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

        public string Function_Name
        {
            get { return function_Name; }
            set { function_Name = value; }
        }

        public string Function_Group_Id
        {
            get { return function_Group_Id; }
            set { function_Group_Id = value; }
        }

        public string Icon
        {
            get { return icon; }
            set { icon = value; }
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
