namespace Task_Management_System.Entities.Api
{
    public class Response_Project
    {
        private int id;
        private string project_Name;
        private string project_Description;
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

        public int Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }

    }
}
