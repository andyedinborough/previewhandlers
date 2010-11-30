using System.IO;
using System.Windows.Forms;

namespace FuelAdvance.PreviewHandlerPack.PreviewHandlers.Handlers
{
	public class CodePreviewHandlerControl : StreamBasedPreviewHandlerControl
	{
		private string _definition = string.Empty;

		public CodePreviewHandlerControl(string definition)
		{
			this._definition = definition;
		}

		public override void Load(Stream stream)
		{
			string sourceHtml = HighlightHelpers.GetHighlightedHtml(_definition, stream);

			//Display the source code
			WebBrowser webBrowser = new WebBrowser();
			webBrowser.Dock = DockStyle.Fill;
			webBrowser.DocumentText = sourceHtml;
			Controls.Add(webBrowser);
		}
	}
}