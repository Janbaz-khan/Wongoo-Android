using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wongoo_Application.Shared
{
   public class CleanList
    {
        public static List<string> Clean(List<string> InputList)
        {
            if (InputList!=null)
            {
                var stringList = new List<string>();
                foreach (var item in InputList)
                {
                    if (item.Contains("en:"))
                    {
                        string s = item.Replace("en:", "");
                        stringList.Add(s);
                    }
                    else if (item.Contains("es:"))
                    {
                        string s = item.Replace("es:", "");
                        stringList.Add(s);
                    }
                    else
                    {
                        stringList.Add(item);
                    }
                }
                return stringList.ToList();
            }
            else
            {
                return new List<string>() { "Empty" };
            }
            
        }
    }
}
