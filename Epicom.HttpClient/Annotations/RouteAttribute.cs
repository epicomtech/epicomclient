using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicom.Http.Client.Annotations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class RouteAttribute : Attribute
    {
        public RouteAttribute(string path, string httpMethod)
        {
            this.Path = path;
            this.HttpMethod = httpMethod;
        }

        public string Path { get; protected set; }

        public string HttpMethod { get; protected set; }
    }
}
