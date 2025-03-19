using System.Data;

namespace Task_Management_System.Entities.Data_Provider
{
    public class Procedure_Param
    {
        private string name;
        private string typeName;

        public Procedure_Param(string name, string typeName)
        {
            this.name = name;
            this.typeName = typeName;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Type_Name
        {
            get { return typeName; }
            set { typeName = value; }
        }

        public SqlDbType Db_Type
        {
            get
            {
                SqlDbType ret;
                switch (Type_Name)
                {
                    case "": ret = SqlDbType.NVarChar; break;
                    default: ret = SqlDbType.NVarChar; break;
                }

                return ret;
            }
        }
    }
}
