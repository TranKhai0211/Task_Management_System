namespace Task_Management_System.Entities.Data
{
    public class Project
    {
        private int id;
        private string project_Name;
        private string project_Description;
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

        public string Project_Name
        {
            get { return project_Name; }
            set { project_Name = value; }
        }

        public string Project_Description
        {
            get { return project_Description; }
            set { project_Description = value; }
        }

        public int Created_By_User_Id
        {
            get { return Created_By_User_Id; }
            set { Created_By_User_Id = value; }
        }

        public DateTime Created_Date
        {
            get { return created_Date; }
            set { created_Date = value; }
        }

        public int Last_Updated_By_User_Id
        {
            get { return last_Updated_By_User_Id; }
            set { Last_Updated_By_User_Id = value; }
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
