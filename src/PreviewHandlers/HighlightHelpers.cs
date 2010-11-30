using System.IO;
using System.Xml.Linq;
using Wayloop.Highlight;
using Wayloop.Highlight.Configuration;
using Wayloop.Highlight.Engines;

namespace FuelAdvance.PreviewHandlerPack.PreviewHandlers
{
    public static class HighlightHelpers
    {
        public static string GetHighlightedHtml(string definition, Stream stream)
        {
            //Read the source code in
            string sourceText = string.Empty;
            using (StreamReader reader = new StreamReader(stream))
                sourceText = reader.ReadToEnd();

            return GetHighlightedHtml(definition, sourceText);
        }

        public static string GetHighlightedHtml(string definition, string source)
        {
            var configuration = new XmlConfiguration(XDocument.Load(("Definitions.xml")));
            var engine = new HtmlEngine();
            Highlighter highlighter = new Highlighter(configuration, engine);
            string sourceHtml = highlighter.Highlight(source, definition);

            //Preserve the layout
            sourceHtml = string.Format("<pre>{0}</pre>", sourceHtml);
            return sourceHtml;
        }
    }
}