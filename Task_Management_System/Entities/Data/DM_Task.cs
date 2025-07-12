namespace Task_Management_System.Entities.Data
{
    public class DM_Task
    {
        private int id;
        private string task_Name;
        private string task_Description;
        private int project_Id;
        private int assignee_Id;
        private double kpi;
        private DateTime due_Date;
        private int status_Id;
        private string file_Name;
        private string file_Path;
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

        public string Task_Name
        {
            get { return task_Name; }
            set { task_Name = value; }
        }

        public string Task_Description
        {
            get { return task_Description; }
            set { task_Description = value; }
        }

        public int Project_Id
        {
            get { return project_Id; }
            set { project_Id = value; }
        }

        public int Assignee_Id
        {
            get { return assignee_Id; }
            set { assignee_Id = value; }
        }

        public double Kpi
        {
            get { return kpi; }
            set { kpi = value; }
        }

        public DateTime Due_Date
        {
            get { return due_Date; }
            set { due_Date = value; }
        }

        public int Status_Id
        {
            get { return status_Id; }
            set { status_Id = value; }
        }

        public string File_Name
        {
            get { return file_Name; }
            set { file_Name = value; }
        }

        public string File_Path
        {
            get { return file_Path; }
            set { file_Path = value; }
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
