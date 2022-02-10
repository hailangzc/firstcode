using AsciiParse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class AscParseController : ApiController
    {
        [HttpGet]
        public String test()
        {
            String str = "@6@R2F@R30@720150731@2    ABCDEFGHJ";
            String[] strs = str.Split('@'); 
            //AsciiTranslate o = new AsciiTranslate();
            //String s = o.GetAsciiParseValue();
            return "";
        }
    }
}
