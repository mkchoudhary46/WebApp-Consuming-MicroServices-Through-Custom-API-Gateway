using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Gateway.WebAPI.Routing
{
    public class ModelRoute
    {
        public string Endpoint { get; set; }
        public Destination Destination { get; set; }
    }
}
