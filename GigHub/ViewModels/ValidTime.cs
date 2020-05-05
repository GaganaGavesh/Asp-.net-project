using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    public class ValidTime : ValidationAttribute
    {//api hadana class eka validation attribute class eken inherit karanna ona eke thama isvalid method eka tynne
        public override bool IsValid(object value)
        {//methana value ekata thama validate karana thana dana input eka ennee,eka aragena thama current 
         //date ekt ekka validate karanna onaaa

            //TryParseExact eken me property ekata value ekak denawa valid date ekak nam 

            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                                                 "HH:mm",
                                                 CultureInfo.CurrentCulture,
                                                 DateTimeStyles.None,
                                                 out _);

            //web.config eke culture eka override kaloth eka methenta dagannath ahaki 

            return (isValid);
        }
    }
}