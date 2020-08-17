using System;
using System.Collections.Generic;
using System.Text;

namespace CrisBlazorApp.Business.Helpers
{
    public static class DictionaryHelper
    {
        public static bool FindObject(this Dictionary<string, object> dic, string key, string text)
        {
            if (dic.ContainsKey(key) && dic[key] != null)
            {
                return dic[key].ToString().Contains(text); // Case Sensitive
            }

            return false;
        }
    }
}
