using System;
using System.IO;
using System.Xml;

using Lonwas.Highlight;
using Lonwas.Highlight.Components;

using FuelAdvance.PreviewHandlerPack.PreviewHandlers.Resources;

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
            //Load the configuration for the highlighter
            XmlDocument highlighterConfig = new XmlDocument();
            highlighterConfig.LoadXml(HighlightResources.Definitions);

            //Highlight the source code
            Highlighter highlighter = new Highlighter(highlighterConfig);
            highlighter.OutputType = OutputType.Html;
            string sourceHtml = highlighter.Highlight(source, definition);

            //Preserve the layout
            sourceHtml = string.Format("<pre>{0}</pre>", sourceHtml);
            return sourceHtml;
        }
    }
}