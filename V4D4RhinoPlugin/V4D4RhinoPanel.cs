using System.Windows.Forms;
using CefSharp.WinForms;

namespace V4D4Rhino
{
    /// <summary>
    /// This is the user control that is buried in the tabbed, docking panel.
    /// </summary>
    [System.Runtime.InteropServices.Guid("4C10B3EF-7033-4461-9FC3-A0C902D16B88")]
    public partial class V4D4RhinoPanel : UserControl
    {
        /// <summary>
        /// Returns the ID of this panel.
        /// </summary>
        public static System.Guid PanelId => typeof(V4D4RhinoPanel).GUID;

        /// <summary>
        /// Public constructor
        /// </summary>
        public V4D4RhinoPanel()
        {
            InitializeComponent();
            this.Controls.Add(V4D4RhinoPlugIn.Browser);

            // Set the user control property on our plug-in
            V4D4RhinoPlugIn.Instance.PanelUserControl = this;
        }
    }
}
