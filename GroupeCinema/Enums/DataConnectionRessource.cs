using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Enums
{
    public enum DataConnectionResource : Int32
    {
        //[StringValue("Server=myServer;Port=3306; Database = db_name;Uid = userName;Pwd = password")]
        [StringValue("Server=127.0.0.1;Port=3306; Database = cinemagestion;Uid = root;Pwd = ''")]
        GENERICMYSQL = 1,
        [StringValue("Server=127.0.0.1;Port=3306; Database = cinemagestion;Uid = root;Pwd = ''")]
        LOCALMYQSL = 2,
        [StringValue("http://localhost:31560/api/")]
        LOCALAPI = 3,
    }
 
}
