using DriverETACloud.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DriverETACloud.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDriverEtaService" in both code and config file together.
    [ServiceContract]
    public interface IDriverEtaService
    {
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "driver/{id}")]
        Driver GetDriverID(string id);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddDriver")]
        Driver AddDriver(Driver driver);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "driver")]
        List<Driver> GetAllDrivers();

    }
}
