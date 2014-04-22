using Bitrave.Azure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App2
{
    public class LeaderBoard
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "score")]
        public int Score { get; set; }

        public override string ToString()
        {
            return UserName + " " + Score;
        }
    }


    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }
        AzureMobileServices azure;
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            string AzureEndPoint = "https://unityleaderboard.azure-mobile.net/";
            string ApplicationKey = "sMkhPtZJYlndEGAWTxxKoOfadQIvmo27";

            azure = new AzureMobileServices(AzureEndPoint, ApplicationKey);

            azure.Where<LeaderBoard>(p => p.UserName != null, ReadHandler);
        }
        public void ReadHandler(AzureResponse<List<LeaderBoard>> response)
        {

            Debug.WriteLine("readhandler");
            var list = response.ResponseData;

            Debug.WriteLine("Items ==================");
            foreach (var item in list)
            {
                Debug.WriteLine(item.ToString());
                //_leaders.Add(item);
            }
            Debug.WriteLine("==================");
        }
    }
}
