using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Salão.Models
{
    public class ScheduleModel
    {
        public int ID { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime DateSchedule { get; set; }
        public AdminModel User { get; set; }
    }
}