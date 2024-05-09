using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ApiError
    {
        public string message { get; set;}
        public ApiError(string Menssage) { message = Menssage;}
    }
}
