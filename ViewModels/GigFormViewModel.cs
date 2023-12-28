using GigHub.Controllers;
using GigHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }
        public string Action { 
            get {

               Expression<System.Func<GigsController, ActionResult>> update = (c => c.Edit(this));
               Expression<System.Func<GigsController, ActionResult>> create = (c => c.Create(this));
                var c1 = update;
                var c2 = create;
                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;

                
                }
        }
        [Required]
        public string Venue { get; set; }
        [Required]
        [CustomValidation.FutureDateValidation]
        public string Date { get; set; }
        [Required]
        [CustomValidation.TimeValidation]
        public string Time { get; set; }
        [Required]
        public int GenreId { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public string Heading { get;  set; }

        public DateTime getDateTime()
        {
            
                return DateTime.Parse(String.Format("{0} {1}", Date, Time));
                
        }
    }
}