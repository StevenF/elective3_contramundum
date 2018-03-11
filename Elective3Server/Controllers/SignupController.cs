using System; 
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Elective3Server.Models;


namespace Elective3Server.Controllers
{
    public class SignupController : ApiController
    {
        

        // GET: api/Signup
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Signup/5
        public Signup Get(int id)
        {
            Signup signup = new Signup();
            signup.email = "johnstevenfrio@yahoo.com";
            signup.password = "1234";
            signup.username = "stevenfrio";

            return signup;
        }

        // POST: api/Signup
        public HttpResponseMessage Post([FromBody]Signup signupValue)
        {
            SignupPersistence signupPersistence = new SignupPersistence();
            long id;      
            id = signupPersistence.signupUser(signupValue);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created);
            httpResponseMessage.Headers.Location = new Uri(Request.RequestUri, String.Format("person/(0)", id));
            return httpResponseMessage;
        }

        // PUT: api/Signup/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Signup/5
        public void Delete(int id)
        {
        }
    }
}
