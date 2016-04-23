using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Bundle_Library;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BundleTestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RecieverPage : Page
    {
        private Bundle data;

        public RecieverPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is Bundle)
                data = (Bundle) e.Parameter;
            else
                throw new InvalidBundleException("Invalid bundle passed");
            txt_RecievedData.Text = data.getString("SENT_DATA");
        }
    }
}
