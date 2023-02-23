﻿using System.ComponentModel.DataAnnotations;

namespace AjaxDemoASPMVC.Test
{
    public class CurrentDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            return dateTime <= DateTime.Now;
        }
    }
}
