using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace natura_process_api.Models
{
    public class Jwt
    {
        public string key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
    }
}
