using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App3
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        public static HttpClient client = new HttpClient();
        public static Uri url;
        public static MainUserObject finalObj;
        private async void goclick(object sender, RoutedEventArgs e)
        {
         //  url = new Uri("http://codeforces.com/api/user.info?handles=mishraiiit");
          // var temp = await client.GetStringAsync(url);
          //  finalObj = JsonConvert.DeserializeObject<MainUserObject>(temp);
            //disptextu.Text = finalObj.result[0].handle.ToString();
            InfoDetails("mishraiiit");

        }
        public Submission ProblemSolved(string handles) {
            string extractInfo = "http://codeforces.com/api/user.status?handle=" + handles.ToString();
            url = new Uri(extractInfo);
            var temp2 = client.GetStringAsync(url).Result;
            var problem_lists = JsonConvert.DeserializeObject<Submission>(temp2);
            return problem_lists;
        }
        private void GoNotification(object sender, RoutedEventArgs e)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode("Hello World!"));
            XmlNodeList toastImageAttributes = toastXml.GetElementsByTagName("image");
            ((XmlElement)toastImageAttributes[0]).SetAttribute("src", "https://codeforces.com/userphoto/title/mishraiiit/photo.jpg");
            ((XmlElement)toastImageAttributes[0]).SetAttribute("alt", "Logo.scale-100.png");
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");
            ((XmlElement)toastNode).SetAttribute("launch", "{\"type\"toast\",\"param1\"12345\",\"param2\"67890\"}");
            
            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);

        }
        public async void InfoDetails(string handleForCodeforces)
        {
            string extractInfo = "http://codeforces.com/api/user.info?handles=" + handleForCodeforces;
            url = new Uri(extractInfo);
                var temp = await client.GetStringAsync(url);
                finalObj = JsonConvert.DeserializeObject<MainUserObject>(temp);
                disptextu.Text = finalObj.result[0].handle.ToString();
                List<TextBlock> infotxt = new List<TextBlock>();
                //int j=0;
                TextBlock abc = new TextBlock();
                abc.Height = 38;
                foreach ( CodeForcesUser i in finalObj.result)
                {
                   // Handle.Text = i.handle.ToString();
                    Firstname.Text = i.firstName.ToString() + " " + i.lastName.ToString() + "\n\t( " + i.handle.ToString() + " )";
                    Rating.Text = i.rating.ToString() + "\n( Max: " + i.maxRating.ToString() + " )";
                    //MaxRank.Text = i.maxRank.ToString();
                    //MaxRating.Text =i.maxRating.ToString();
                    Ranking.Text = i.rank.ToString() + "\n( Best: " + i.maxRank.ToString() + " )";  
                    //i.city;
                    Submission problem_lists = (Submission)ProblemSolved(i.handle.ToString());
                    Submissions.Text = "";
                    foreach (Result problem in problem_lists.result ){
                        Submissions.Text += problem.problem.name.ToString() + " : " + problem.verdict + "\n";
                    }
                }
        }

        private async void UpdateInfo(object sender, RoutedEventArgs e)
        {
            string extractInfo = "http://codeforces.com/api/user.info?handles=" + handleForCodeforces;
            url = new Uri(extractInfo);
            var temp = await client.GetStringAsync(url);
            finalObj = JsonConvert.DeserializeObject<MainUserObject>(temp);
        }

    }
}
