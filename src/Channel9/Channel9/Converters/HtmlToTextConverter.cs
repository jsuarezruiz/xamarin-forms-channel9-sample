using HtmlAgilityPack;
using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace Channel9.Converters
{
    public class HtmlToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            var html = value.ToString();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            StringWriter sw = new StringWriter();
            var node = doc.DocumentNode;
            ConvertTo(node, sw);
            sw.Flush();

            return sw.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        private void ConvertTo(HtmlNode node, TextWriter result)
        {
            string html;

            switch (node.NodeType)
            {
                case HtmlNodeType.Document:
                    foreach (HtmlNode subnode in node.ChildNodes)
                    {
                        ConvertTo(subnode, result);
                    }
                    break;
                case HtmlNodeType.Text:
                    string parentName = node.ParentNode.Name;
                    if ((parentName == "script") || (parentName == "style"))
                        break;

                    html = ((HtmlTextNode)node).Text;

                    if (HtmlNode.IsOverlappedClosingElement(html))
                        break;

                    if (html.Trim().Length > 0)
                    {
                        result.Write(HtmlEntity.DeEntitize(html));
                    }
                    break;
                case HtmlNodeType.Element:
                    switch (node.Name)
                    {
                        case "p":
                            result.Write("\r\n");
                            break;
                    }

                    if (node.HasChildNodes)
                    {
                        foreach (HtmlNode subnode in node.ChildNodes)
                        {
                            ConvertTo(subnode, result);
                        }
                    }
                    break;
            }
        }
    }
}