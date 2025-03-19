using System.Data;
using System.Globalization;
using System.Reflection;

namespace Task_Management_System.Utilities
{
    public class Utility
    {
        public static T Map_Row_To_Entity<T>(DataRow p_Row) where T : new()
        {
            // create a new object
            T v_objItem = new T();

            foreach (DataColumn v_colValue in p_Row.Table.Columns)
            {
                PropertyInfo v_objPropertyInfo = v_objItem.GetType().GetProperty(v_colValue.ColumnName);

                if (v_objPropertyInfo != null && p_Row[v_colValue] != DBNull.Value)
                {
                    MethodInfo v_objMethodInfo = v_objPropertyInfo.SetMethod;
                    if (v_objMethodInfo != null)
                    {
                        string v_strDataType = v_colValue.DataType.Name;
                        switch (v_strDataType)
                        {
                            case "String": v_objPropertyInfo.SetValue(v_objItem, Convert.ChangeType(p_Row[v_objPropertyInfo.Name], v_objPropertyInfo.PropertyType)); break;
                            case "Int16": v_objPropertyInfo.SetValue(v_objItem, Convert.ToInt32(p_Row[v_colValue])); break;
                            case "Int32": v_objPropertyInfo.SetValue(v_objItem, Convert.ToInt32(p_Row[v_colValue])); break;
                            case "Int64": v_objPropertyInfo.SetValue(v_objItem, Convert.ToInt64(p_Row[v_colValue])); break;
                            case "Double": v_objPropertyInfo.SetValue(v_objItem, Convert.ToDouble(p_Row[v_colValue])); break;
                            case "DateTime": v_objPropertyInfo.SetValue(v_objItem, Convert.ToDateTime(p_Row[v_colValue])); break;
                            case "Decimal": v_objPropertyInfo.SetValue(v_objItem, Convert.ToDouble(p_Row[v_colValue])); break;
                        }
                    }
                }
            }

            return v_objItem;
        }

        public static string Convert_To_String(double p_objData, int p_Formatter)
        {
            string strResult = "";
            switch (p_Formatter)
            {
                case (int)String_Formatter.Currency_US:
                    strResult = p_objData.ToString("N0", new CultureInfo("en_US")); break;

                case (int)String_Formatter.Currency_Vn:
                    strResult = p_objData.ToString("N0", new CultureInfo("vi_VN")); break;
            }

            return strResult;
        }
    }
}
