﻿using System.Data;
using Task_Management_System.Entities.Data;
using Task_Management_System.SqlHelper;
using Task_Management_System.Utilities;

namespace Task_Management_System.Controllers.MVC_Controller
{
    public class Project_Controller
    {
        Data_Provider dataProvider = new Data_Provider();

        public List<Project> Get_All_Project()
        {
            List<Project> lstProjects = new List<Project>();
            DataTable dt = new DataTable();

            try
            {
                dt = dataProvider.ExecuteReader("sp_sel_Get_All_Project");

                foreach (DataRow dr in dt.Rows)
                {
                    Project objProject = Utility.Map_Row_To_Entity<Project>(dr);
                    lstProjects.Add(objProject);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dt.Dispose();
            }

            return lstProjects;
        }

        public Project Get_Project_By_Id(int p_Id)
        {
            Project objProject = null;
            DataTable dt = new DataTable();

            try
            {
                dt = dataProvider.ExecuteReader("sp_sel_Get_Project_By_Id", p_Id);

                if (dt.Rows.Count != 0)
                    objProject = Utility.Map_Row_To_Entity<Project>(dt.Rows[0]);
            }
             catch (Exception)
            {
                throw;
            }
            finally { dt.Dispose(); }

            return objProject;
        }

        public void Insert_Project(Project p_objProject)
        {
            try
            {
                dataProvider.ExecuteNonQuery("sp_ins_Insert_Project", p_objProject.Project_Name, p_objProject.Project_Description,
                    p_objProject.Status_Id, p_objProject.Created_By_User_Id, p_objProject.Created_Date, p_objProject.Last_Updated_By_User_Id,
                    p_objProject.Last_Updated_Date);
            } 
            catch (Exception)
            {
                throw;
            }
        }

        public void Update_Project(Project p_objProject)
        {
            try
            {
                dataProvider.ExecuteNonQuery("sp_upd_Update_Project_By_Id", p_objProject.Id, p_objProject.Project_Name, p_objProject.Project_Description,
                    p_objProject.Status_Id, p_objProject.Created_By_User_Id, p_objProject.Created_Date, p_objProject.Last_Updated_By_User_Id,
                    p_objProject.Last_Updated_Date);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete_Project(int p_intId)
        {
            try
            {
                dataProvider.ExecuteNonQuery("sp_del_Delete_Project_By_Id", p_intId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
