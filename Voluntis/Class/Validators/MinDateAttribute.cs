using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Voluntis.Class.Validators
{
    public class MinDateAttribute : ValidationAttribute
    {
        private int minYear;

        public MinDateAttribute(int minYear)
        {
            this.minYear = minYear;
        }

        public override bool IsValid(object value)
        {
            if(value != null && value is DateTime)
            {
                DateTime dt = (DateTime)value;
                return dt.AddYears(this.minYear) <= DateTime.Now;
            }
            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(this.ErrorMessage, name, this.minYear);
        }
    }
}
