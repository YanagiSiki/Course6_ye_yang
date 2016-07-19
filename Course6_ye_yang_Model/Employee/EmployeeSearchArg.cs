using Course6_ye_yang_Model.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course6_ye_yang_Model.Employee
{
    public class EmployeeSearchArg
    {
        /// <summary>
        /// 員工編號
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 員工姓名
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// 職稱
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 任職日期(範圍開始)
        /// </summary>        
        [DatetimeMax("EndHireDate", ErrorMessage = "時間範圍有誤")]
        public DateTime? StartHireDate { get; set; }

        /// <summary>
        /// 任職日期(範圍結束)
        /// </summary>
        [DatetimeMin("StartHireDate", ErrorMessage = "時間範圍有誤")]
        public DateTime? EndHireDate { get; set; }
    }
}
