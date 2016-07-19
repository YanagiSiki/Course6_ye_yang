﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course6_ye_yang_Model.Validation
{
    public class DatetimeMin : ValidationAttribute
    {
        public string OtherProperty { get; private set; }

        public DatetimeMin(string otherProperty)
        {
            OtherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(OtherProperty);//取得比較目標
            var otherValue = property.GetValue(validationContext.ObjectInstance, null);//取得目標的value
            if (otherValue != null && value != null)//不為null時才比較
            {
                if ((DateTime)value < (DateTime)otherValue)//不能夠比目標小，所以比目標小時要跳出錯誤
                {
                    var errorMsg = "時間範圍有誤";
                    return new ValidationResult(errorMsg);
                }
            }
            return ValidationResult.Success;
        }
    }
}
