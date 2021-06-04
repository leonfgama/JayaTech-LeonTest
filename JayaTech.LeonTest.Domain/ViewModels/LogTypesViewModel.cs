using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JayaTech.LeonTest.Domain.ViewModels
{
    public class LogTypesViewModel
    {
        public LogTypesViewModel(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
