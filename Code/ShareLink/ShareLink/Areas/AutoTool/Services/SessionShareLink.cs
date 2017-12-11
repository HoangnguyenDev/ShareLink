using Microsoft.AspNetCore.Http;
using ShareLink.Areas.AutoTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareLink.Areas.AutoTool.Session
{
    public class SessionShareLink
    {
        public static void SetSessionGoogleSearch(List<ShareLinkSimple> listsearch, HttpContext http)
        {
            try
            {
                int i = 0;
                foreach (var item in listsearch)
                {
                    http.Session.SetString($"URL{i}", item.URL);
                    http.Session.SetString($"Title{i}", item.Title);
                    i++;
                }
                http.Session.SetInt32("number", i);
            }
            catch { }
        }

        public static List<ShareLinkSimple> GetSessionGoogleSearch(HttpContext http)
        {
            try
            {
                List<ShareLinkSimple> listSearch = new List<ShareLinkSimple>();
                int? count = http.Session.GetInt32("number");
                if (count.HasValue)
                {
                    for (int i = 0; i < count; i++)
                    {
                        var Title = http.Session.GetString($"Title{i}");
                        var URL = http.Session.GetString($"URL{i}");
                        listSearch.Add(new ShareLinkSimple { Title = Title, URL = URL });
                    }
                }
                return listSearch;
            }
            catch
            {
                return null;
            }
        }
    }
}
