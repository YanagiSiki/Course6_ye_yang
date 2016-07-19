using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course6_ye_yang_Model.Validation
{
    public class DatetimeFuture : ValidationAttribute
    {
        public DatetimeFuture()
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)//不為null時才比較
            {
                if ((DateTime)value > DateTime.Now)//不能夠比目標大，所以比目標大時要跳出錯誤
                {
                    var errorMsg = "你出生在未來= =?";
                    return new ValidationResult(errorMsg);
                }
            }
            return ValidationResult.Success;
        }
    }
}
