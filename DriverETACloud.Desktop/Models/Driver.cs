namespace DriverETACloud.Desktop.Models
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public  class Driver 
    {  
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
       
        public DateTime? DOB { get; set; }

        public bool? IsActive { get; set; }

        
    }
}
