using System.Data;
using Task_Management_System.Entities.Data;
using Task_Management_System.SqlHelper;
using Task_Management_System.Utilities;
using DM_Task = Task_Management_System.Entities.Data.DM_Task;

namespace Task_Management_System.Controllers.MVC_Controller
{
    public class DM_Task_Controller
    {
        Data_Provider dataProvider = Data_Provider.Instance;

        // List
        public List<DM_Task> Get_All_Task()
        {
            List<DM_Task> lstTasks = new List<DM_Task>();
            DataTable dt = new DataTable();

            try
            {
                dt = dataProvider.ExecuteReader("sp_sel_Get_All_Task");

                foreach (DataRow dr in dt.Rows)
                {
                    DM_Task objTask = Utility.Map_Row_To_Entity<DM_Task>(dr);
                    lstTasks.Add(objTask);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                dt.Dispose();
            }

            return lstTasks;
        }

        // Get
        public DM_Task Get_Task_By_Id(int p_Id)
        {
            DM_Task objTask = null;
            DataTable dt = new DataTable();

            try
            {
                dt = dataProvider.ExecuteReader("", p_Id);

                if (dt.Rows.Count != 0)
                    objTask = Utility.Map_Row_To_Entity<DM_Task>(dt.Rows[0]);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dt.Dispose();
            }

            return objTask;
        }

        // Insert
        public void Insert_Task(DM_Task p_objTask)
        {
            try
            {
                dataProvider.ExecuteNonQuery("");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Update
        public void Update_Task(DM_Task p_objTask)
        {
            try
            {
                dataProvider.ExecuteNonQuery("");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Delete
        public void Delete_Task(int p_intId)
        {
            try
            {
                dataProvider.ExecuteNonQuery("");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
