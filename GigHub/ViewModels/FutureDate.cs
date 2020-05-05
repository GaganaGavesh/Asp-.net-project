using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {//methana value ekata thama validate karana thana dana input eka ennee,eka aragena thama current 
         //date ekt ekka validate karanna onaaa

            //TryParseExact eken me property ekata value ekak denawa valid date ekak nam 

            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                                                 "dd MM yyyy",
                                                 CultureInfo.CurrentCulture,
                                                 DateTimeStyles.None,
                                                 out DateTime datetime);

            //web.config eke culture eka override kaloth eka methenta dagannath ahaki 

            return (isValid && datetime > DateTime.Now);
        }
    }
}