using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace TestEtsy.TestDataAccess
{
    /// <summary>
    /// This class keep the set of data in excel and write the results in a file .txt
    /// </summary>
    public class ExcelDataAccess
    {

        //Convert the data from excel to datatable
        public static DataTable ExcelToDataTable(string filePath)
        {
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataSet result = excelReader.AsDataSet();
            DataTableCollection table = result.Tables;
            DataTable resultTable = table["Sheet1"];
            return resultTable;
        }

        //Create a list of UserData with the datatable
        public static List<UserData> GetUsers()
        {
            List<UserData> lstusers = new List<UserData>();
            string filePath = Settings.pathUsers;
            DataTable table = ExcelToDataTable(filePath);
            
            for (int row = 1; row < table.Rows.Count; row++)
            {
                    UserData user = new UserData()
                    {
                        Email = table.Rows[row][0].ToString(),
                        Password = table.Rows[row][1].ToString()
                    };
                
                lstusers.Add(user);
            }
            return lstusers;
        }

        //Create file .txt with the result
        public static void CreateTxt(UserData data, string error)
        {
            string text = data.Email + " " + data.Password + " " + error;

            using (StreamWriter mylogs = File.AppendText(Settings.pathLog))  
            {
                DateTime dateTime = new DateTime();
                dateTime = DateTime.Now;
                string strDate = Convert.ToDateTime(dateTime).ToString("dd/MM/yyyy HH:mm");
                mylogs.WriteLine(text + " " + strDate);
                mylogs.Close();
            }
        }
    }
}
