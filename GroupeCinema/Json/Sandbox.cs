using GroupeCinema.Cinema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Json
{
    public class Sandbox
    {
        public void testIt()
        {
            //Class1 class1 = new Class1().LoadSingleItem();
            //String convertClass1 = JsonConvert.SerializeObject(class1);

            List<Class1> listclass1 = new Class1().LoadMultipleItems();
            String convertListClass1 = JsonConvert.SerializeObject(listclass1);

            /*RegularClient regularClient = new RegularClient();
            regularClient.Id = 1;
            regularClient.Firstname = "Michel";
            regularClient.Lastname = "Michou";
            String regClient = JsonConvert.SerializeObject(regularClient);

            Class1 class1Revert = JsonConvert.DeserializeObject<Class1>(convertClass1);*/

            List<Class1> listclass1Revert = JsonConvert.DeserializeObject<List<Class1>>(convertListClass1);

        }
        

    }
}
