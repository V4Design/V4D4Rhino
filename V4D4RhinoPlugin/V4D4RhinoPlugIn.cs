using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using CefSharp;
using CefSharp.WinForms;
using Rhino.PlugIns;
using Rhino.UI;


namespace V4D4Rhino
{
    ///<summary>
    /// <para>Every RhinoCommon .rhp assembly must have one and only one PlugIn-derived
    /// class. DO NOT create instances of this class yourself. It is the
    /// responsibility of Rhino to create an instance of this class.</para>
    /// <para>To complete plug-in information, please also see all PlugInDescription
    /// attributes in AssemblyInfo.cs (you might need to click "Project" ->
    /// "Show All Files" to see it in the "Solution Explorer" window).</para>
    ///</summary>
    public class V4D4RhinoPlugIn : Rhino.PlugIns.PlugIn
    {

        public static ChromiumWebBrowser Browser;

        public V4D4RhinoPlugIn()
        {
            Instance = this;
        }

        ///<summary>Gets the only instance of the V4D4RhinoPlugIn plug-in.</summary>
        public static V4D4RhinoPlugIn Instance
        {
            get; private set;
        }

        /// <summary>
        /// The tabbed dockbar user control
        /// </summary>
        public V4D4RhinoPanel PanelUserControl { get; set; }

        // You can override methods here to change the plug-in behavior on
        // loading and shut down, add options pages to the Rhino _Option command
        // and maintain plug-in wide options in a document.

        protected override LoadReturnCode OnLoad(ref string errorMessage)
        {

            Panels.RegisterPanel(this, typeof(V4D4RhinoPanel), "V4D4Rhino", V4D4Rhino.Properties.Resources.V4D4Rhino_1);

            if (!Cef.IsInitialized)
                InitializeCef();

            // initialise one browser instance
            InitializeChromium();

            return base.OnLoad(ref errorMessage);
        }

        private void InitializeCef()
        {
            Cef.EnableHighDPISupport();

            var assemblyLocation = Assembly.GetExecutingAssembly().Location;
            var assemblyPath = Path.GetDirectoryName(assemblyLocation);
            var pathSubprocess = Path.Combine(assemblyPath, "CefSharp.BrowserSubprocess.exe");
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            var settings = new CefSettings
            {
                LogSeverity = LogSeverity.Verbose,
                LogFile = "ceflog.txt",
                BrowserSubprocessPath = pathSubprocess,

            };

            settings.CefCommandLineArgs.Add("allow-file-access-from-files", "1");
            settings.CefCommandLineArgs.Add("disable-web-security", "1");
            Cef.Initialize(settings);
        }

        private void InitializeChromium()
        {
#if DEBUG
            //use localhost
            Browser = new ChromiumWebBrowser( @"http://localhost:8080/" );
            //Browser = new ChromiumWebBrowser(@"http://v4design.eu");
#else
            //use dist files
            var path = Directory.GetParent(Assembly.GetExecutingAssembly().Location);
            Debug.WriteLine(path, "V4D4Rhino");

            var indexPath = string.Format(@"{0}\app\index.html", path);

            if (!File.Exists(indexPath))
                Debug.WriteLine("V4D4Rhino: Error. The html file doesn't exists : {0}", "V4D4Rhino");

            indexPath = indexPath.Replace("\\", "/");

            Browser = new ChromiumWebBrowser(indexPath);
#endif
            // Allow the use of local resources in the browser
            Browser.BrowserSettings = new BrowserSettings
            {
                FileAccessFromFileUrls = CefState.Enabled,
                UniversalAccessFromFileUrls = CefState.Enabled
            };


            Browser.Dock = System.Windows.Forms.DockStyle.Fill;
        }



        protected override void OnShutdown()
        {
            Browser.Dispose();
            Cef.Shutdown();

            //Store.Dispose();
            V4D4RhinoPlugIn.Instance.PanelUserControl?.Dispose();
            base.OnShutdown();

        }
    }
}