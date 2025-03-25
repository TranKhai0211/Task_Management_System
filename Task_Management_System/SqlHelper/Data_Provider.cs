using System.Data;
using System.Data.SqlClient;
using Task_Management_System.Entities.Data_Provider;

namespace Task_Management_System.SqlHelper
{
    public class Data_Provider
    {
        private string connectionSTR = "Data Source=MSI\\SQLSERVER;Initial Catalog=TaskManagementSystem;Integrated Security=true";

        // Hàm lấy thông tin Store Procedure
        public List<Procedure_Param> Get_Store_Procedure_Param_Info(string p_strSP_Name)
        {
            List<Procedure_Param> arrPP = new List<Procedure_Param>();

            using (SqlConnection conn = new SqlConnection(connectionSTR))
            {
                conn.Open();
                string strQuery = @"SELECT 
	                                prm.name AS ParameterName,
	                                t.name AS DataType,
	                                prm.max_length
                                FROM sys.procedures p 
                                LEFT JOIN sys.parameters prm ON p.object_id = prm.object_id
                                LEFT JOIN sys.types t ON prm.user_type_id = t.user_type_id
                                WHERE P.name = @ProcedureName";

                using (SqlCommand cmd = new SqlCommand(strQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ProcedureName", p_strSP_Name);        // gán tham số cho câu truy vấn ở trên.

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["ParameterName"].ToString() != "")
                                arrPP.Add(new Procedure_Param(reader["ParameterName"].ToString(), reader["DataType"].ToString()));
                        }
                    }
                }
            }

            return arrPP;
        }


        // Hàm thiết lập tham số cho SqlCommand
        public void Set_Procedure_Parameters(SqlCommand p_cmd, string p_strProcedure_Name, params object[] procedureParams)
        {
            List<Procedure_Param> arrProcedure_Params = Get_Store_Procedure_Param_Info(p_strProcedure_Name);
            int paramCount = arrProcedure_Params.Count;

            if (procedureParams.Count() != paramCount)                  // So sánh số lượng tham số đâu vào và số lượng tham số của Store Procedure
                throw new Exception("Số lượng tham số không tương thích");

            // Truyền các tham số cần thiết cho đối tượng command
            for (int i = 0; i < paramCount; i++)
            {
                p_cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = arrProcedure_Params[i].Name,
                    SqlDbType = arrProcedure_Params[i].Db_Type,
                    Value = procedureParams[i]
                });
            }
        }


        // Thực thi store để lấy về dữ liệu (Get data)
        public DataTable ExecuteReader(string p_strProcedure_Name, params object[] procedureParams)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionSTR))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(p_strProcedure_Name, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                Set_Procedure_Parameters(cmd, p_strProcedure_Name, procedureParams);            // Thiết lập tham số cho Store Procedure

                SqlDataReader reader = cmd.ExecuteReader();                                     // Thực thi store

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }


        // Thực thi store để trả về kết quả là số dòng ảnh hưởng (Insert, Delete, Update, ...)
        public int ExecuteNonQuery(string p_strProcedure_Name, params object[] procedureParams)
        {
            using (SqlConnection conn = new SqlConnection(connectionSTR))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(p_strProcedure_Name, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                Set_Procedure_Parameters(cmd, p_strProcedure_Name, procedureParams);            // Thiết lập tham số cho Store Procedure

                return cmd.ExecuteNonQuery();                                                   // Thực thi và trả về kết quả là số dòng ảnh hưởng
            }
        }
    }
}
