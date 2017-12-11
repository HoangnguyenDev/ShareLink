using HtmlAgilityPack;
using ShareLink.Areas.AutoTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareLink.Areas.AutoTool.Services.NhanDienMau
{
    public class Vnexpress
    {
        public static bool Check(HtmlDocument doc)///div
        {
            var nodeP = doc.DocumentNode.SelectNodes(".//*[@id='list_sub_featured']");
            if (nodeP == null)
                return false;
            //if (nodeP.InnerText.Length <= GlobalChordAndLyric.MIN_MAIN_CONTENT)
            //    return false;
            //foreach (var item in nodeText)
            //{
            //     if (item.ParentNode.ParentNode != parentNodeH1)
            //        return false;
            //}
            return true;
        }
        public static NhanDienShareLinkViewModel GetContent(HtmlDocument doc, string url)
        {
            List<ShareLinkSimple> list = new List<ShareLinkSimple>();
            try
            {
                for (int i = 1; i < 9; i++)
                {
                    //*[@id="list_sub_featured"]/li[1]/a[1]
                    string nodestring = ".//*[@id='list_sub_featured']/li[" + i + "]/a[1]";
                    var text = doc.DocumentNode.SelectSingleNode(nodestring);
                    ShareLinkSimple shareLink = new ShareLinkSimple
                    {
                        Title = text.Attributes["title"].Value,
                        URL = text.Attributes["href"].Value

                    };
                    list.Add(shareLink);
                }
            }
            catch { }
            return new NhanDienShareLinkViewModel(list, "VnExpress");
        }
    }
}
