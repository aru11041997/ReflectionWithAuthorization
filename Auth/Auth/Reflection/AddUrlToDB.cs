using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auth.Models;

namespace Auth.Reflection
{
    public class AddUrlToDB
    {
        public static void addToDB()
        {
            AuthorizeDemoEntities db = new AuthorizeDemoEntities();
            CollectAllName collectAllName = new CollectAllName();
            List<string> urlList = collectAllName.getDetails();
            foreach(var url in urlList)
            {
                var checkURL = db.RouteTables.SingleOrDefault(m => m.URL.Equals(url));
                if(checkURL==null)
                {
                    db.RouteTables.Add(new RouteTable { URL=url });
                    db.SaveChanges();
                }
            }

        }
    }
}