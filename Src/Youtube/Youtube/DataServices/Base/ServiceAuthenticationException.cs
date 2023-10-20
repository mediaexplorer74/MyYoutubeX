using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.DataServices.Base
{
    public class ServiceAuthenticationException : Exception
    {
        public  string Content { get; }

        public ServiceAuthenticationException()
        {
         //   
        }

        public ServiceAuthenticationException(string content)
        {
            Debug.WriteLine("[i] ServiceAuthenticationException Content: " + content);
            Content = content;
        }
    }
}
