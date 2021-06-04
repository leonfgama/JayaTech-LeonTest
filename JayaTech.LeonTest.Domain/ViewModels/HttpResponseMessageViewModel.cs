using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JayaTech.LeonTest.Domain.ViewModels
{
    public class HttpResponseMessageViewModel
    {
        public HttpResponseMessageViewModel(string message, Exception ex)
        {
            this.IsSuccess = false;
            this.Message = message;
        }
        public HttpResponseMessageViewModel(bool isSuccess, string message, object content)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
            this.Content = content;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Content { get; set; }
    }
}
