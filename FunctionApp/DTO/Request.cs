using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionApp.DTO
{
    public class RequestDTO
    {
        public string Text { get; set; }
        public bool Encrypt { get; set; }
        public int Steps { get; set; }
    }
}
