﻿using Course6_ye_yang_Common;
using Course6_ye_yang_Model.Employee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course6_ye_yang_Dao
{
    public class EmployeeDao : IEmployeeDao
    {
        /// <summary>
        /// 定義空值為Null by http://blog.darkthread.net/post-2015-08-18-where-is-null-or-trick.aspx
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="convEmpty"></param>
        /// <returns></returns>
        public object NullToDBNullValue(object obj, bool convEmpty = false)
        {
            try
            {
                if (convEmpty && obj == null)
                {
                    return DBNull.Value;
                }
            }
            catch { Exception e; }
            try
            {
                if (convEmpty && (int)obj == 0)
                {
                    return DBNull.Value;
                }
            }
            catch { Exception e; }
            return obj;
        }

        /// <summary>
        /// 取得emp by 表單上的data
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public DataTable GetSearchResultByArg(EmployeeSearchArg arg)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT hs.EmployeeID, hs.FirstName + hs.LastName AS EmployeeName, 
                                  ct1.CodeId + '-' + ct1.CodeVal AS Type, convert(varchar, hs.HireDate, 111) HireDate,
                                  ct2.CodeVal AS Gender, Year(GETDATE())-Year(BirthDate) Age
                            FROM HR.Employees hs JOIN CodeTable ct1
	                            ON (ct1.CodeId = hs.Title AND ct1.CodeType = 'TITLE')
								LEFT JOIN CodeTable ct2
								ON (ct2.CodeId = hs.Gender AND ct2.CodeType = 'GENDER') 
                            WHERE (@employeeID IS NULL OR @employeeID = EmployeeID) AND
	                              (@employeeName IS NULL OR FirstName LIKE '%' + @employeeName + '%' OR hs.LastName LIKE '%' + @employeeName + '%') AND
	                              (@codeVal IS NULL OR @codeVal = hs.Title) AND
	                              (@startHireDate IS NULL OR @endHireDate IS NULL OR HireDate BETWEEN @startHireDate AND @endHireDate)  ;";
            using (SqlConnection conn = new SqlConnection(ConfigTool.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@employeeID", NullToDBNullValue(arg.EmployeeId, true)));
                cmd.Parameters.Add(new SqlParameter("@employeeName", NullToDBNullValue(arg.EmployeeName, true)));
                cmd.Parameters.Add(new SqlParameter("@codeVal", NullToDBNullValue(arg.Title, true)));
                cmd.Parameters.Add(new SqlParameter("@startHireDate", NullToDBNullValue(arg.StartHireDate, true)));
                cmd.Parameters.Add(new SqlParameter("@endHireDate", NullToDBNullValue(arg.EndHireDate, true)));
                /*如果用string的方式，可以改成下面這兩行*/
                //cmd.Parameters.Add(new SqlParameter("@startHireDate", arg.StartHireDate.ToString() == null ? string.Empty : arg.StartHireDate.ToString()));
                //cmd.Parameters.Add(new SqlParameter("@endHireDate", arg.EndHireDate.ToString() == null ? string.Empty : arg.EndHireDate.ToString()));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return dt;
        }

        /// <summary>
        /// 取得Data By CodeType (用於建立DropdownList)
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetDataByCodeType(string type)
        {
            DataTable dt = new DataTable();
            string sql = @"Select Distinct CodeVal, CodeId 
                            From CodeTable
                            WHERE CodeType = @type";
            using (SqlConnection conn = new SqlConnection(ConfigTool.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@type", type));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return dt;
        }

        /// <summary>
        /// 取得所有主管ID(Employee.ManagerID)
        /// </summary>
        /// <returns></returns>
        public DataTable GetManagerID()
        {
            DataTable dt = new DataTable();
            string sql = @"Select Distinct FirstName + LastName AS CodeVal, EmployeeID AS CodeId 
                            From HR.Employees";
            using (SqlConnection conn = new SqlConnection(ConfigTool.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return dt;
        }

        /// <summary>
        /// 新增一筆Employee
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public int InsertEmployee(Employee arg)
        {
            string sql = @" INSERT INTO [HR].[Employees]
                                    ([LastName],[FirstName],[Title],[TitleOfCourtesy],[BirthDate],
                                     [HireDate],[Address],[City],[Country],[Phone],[ManagerID],
                                     [Gender],[MonthlyPayment],[YearlyPayment])
                             VALUES (@LastName, @FirstName, @Title,@TitleOfCourtesy,@BirthDate,
                                    @HireDate,@Address,@City,@Country,@Phone,@ManagerID,
                                    @Gender,@MonthlyPayment,@YearlyPayment)
                             Select SCOPE_IDENTITY()
                             ";
            int EmployeeID;
            using (SqlConnection conn = new SqlConnection(ConfigTool.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@LastName", NullToDBNullValue(arg.LastName, true)));
                cmd.Parameters.Add(new SqlParameter("@FirstName", NullToDBNullValue(arg.FirstName, true)));
                cmd.Parameters.Add(new SqlParameter("@Title", NullToDBNullValue(arg.Title, true)));
                cmd.Parameters.Add(new SqlParameter("@TitleOfCourtesy", NullToDBNullValue(arg.TitleOfCourtesy, true)));
                cmd.Parameters.Add(new SqlParameter("@BirthDate", NullToDBNullValue(arg.BirthDate, true)));
                cmd.Parameters.Add(new SqlParameter("@HireDate", NullToDBNullValue(arg.HireDate, true)));
                cmd.Parameters.Add(new SqlParameter("@Address", NullToDBNullValue(arg.Address, true)));
                cmd.Parameters.Add(new SqlParameter("@City", NullToDBNullValue(arg.City, true)));
                cmd.Parameters.Add(new SqlParameter("@Country", NullToDBNullValue(arg.Country, true)));
                cmd.Parameters.Add(new SqlParameter("@Phone", NullToDBNullValue(arg.Phone, true)));
                cmd.Parameters.Add(new SqlParameter("@ManagerID", NullToDBNullValue(arg.ManagerID, true)));
                cmd.Parameters.Add(new SqlParameter("@Gender", NullToDBNullValue(arg.Gender, true)));
                cmd.Parameters.Add(new SqlParameter("@MonthlyPayment", NullToDBNullValue(arg.MonthlyPayment, true)));
                cmd.Parameters.Add(new SqlParameter("@YearlyPayment", NullToDBNullValue(arg.YearlyPayment, true)));

                EmployeeID = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();
            }
            return EmployeeID;
        }

        /// <summary>
        /// 取得emp資訊 by 輸入的ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetEmployeeByID(string id)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT [EmployeeID],[LastName],[FirstName],[Title],[TitleOfCourtesy],
                                  [BirthDate],[HireDate],[Address],[City],[Country],[Phone],
                                  [ManagerID],[Gender],[MonthlyPayment],[YearlyPayment]
                          FROM [HR].[Employees]
                          WHERE EmployeeID = @employeeID";
            using (SqlConnection conn = new SqlConnection(ConfigTool.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@employeeID", id));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return dt;
        }

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="arg"></param>
        public void UpdateEmployee(Employee arg)
        {
            string sql = @"UPDATE [HR].[Employees]
                           SET [LastName] = @LastName,[FirstName] = @FirstName,[Title] = @Title,
                               [TitleOfCourtesy] = @TitleOfCourtesy,[BirthDate] = @BirthDate,
                               [HireDate] = @HireDate,[Address] = @Address,[City] = @City,
                               [Country] = @Country,[Phone] = @Phone,[ManagerID] = @ManagerID,
                               [Gender] = @Gender,[MonthlyPayment] = @MonthlyPayment,
                               [YearlyPayment] = @YearlyPayment
                            WHERE [EmployeeID] = @EmployeeID";

            using (SqlConnection conn = new SqlConnection(ConfigTool.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@LastName", NullToDBNullValue(arg.LastName, true)));
                cmd.Parameters.Add(new SqlParameter("@FirstName", NullToDBNullValue(arg.FirstName, true)));
                cmd.Parameters.Add(new SqlParameter("@Title", NullToDBNullValue(arg.Title, true)));
                cmd.Parameters.Add(new SqlParameter("@TitleOfCourtesy", NullToDBNullValue(arg.TitleOfCourtesy, true)));
                cmd.Parameters.Add(new SqlParameter("@BirthDate", NullToDBNullValue(arg.BirthDate, true)));
                cmd.Parameters.Add(new SqlParameter("@HireDate", NullToDBNullValue(arg.HireDate, true)));
                cmd.Parameters.Add(new SqlParameter("@Address", NullToDBNullValue(arg.Address, true)));
                cmd.Parameters.Add(new SqlParameter("@City", NullToDBNullValue(arg.City, true)));
                cmd.Parameters.Add(new SqlParameter("@Country", NullToDBNullValue(arg.Country, true)));
                cmd.Parameters.Add(new SqlParameter("@Phone", NullToDBNullValue(arg.Phone, true)));
                cmd.Parameters.Add(new SqlParameter("@ManagerID", NullToDBNullValue(arg.ManagerID, true)));
                cmd.Parameters.Add(new SqlParameter("@Gender", NullToDBNullValue(arg.Gender, true)));
                cmd.Parameters.Add(new SqlParameter("@MonthlyPayment", NullToDBNullValue(arg.MonthlyPayment, true)));
                cmd.Parameters.Add(new SqlParameter("@YearlyPayment", NullToDBNullValue(arg.YearlyPayment, true)));
                cmd.Parameters.Add(new SqlParameter("@EmployeeID", arg.EmployeeID));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        /// <summary>
        /// 刪除By ID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEmployee(string id)
        {
            try
            {
                string sql = "DELETE FROM [HR].[Employees] WHERE EmployeeID = @EmployeeID";
                using (SqlConnection conn = new SqlConnection(ConfigTool.GetDBConnectionString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@EmployeeID", id));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
