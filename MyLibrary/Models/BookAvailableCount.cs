using MyLibrary.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyLibrary.Models
{
    public partial class Book
    {
        [NotMapped]
        public int AvailableCount
        {
            get
            {
                int busy = DatabaseHelper.GetBusyBookCount(this.Id);
                return this.Count - busy;
            }
        }
    }
}