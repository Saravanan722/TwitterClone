using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;

namespace Twitter
{
    class MainViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        List<TwitterFeed> twitterFeeds;
        public List<TwitterFeed> TwitterFeeds
        {
            get => twitterFeeds;
            set
            {
                twitterFeeds = value;
                OnPropertyChanged("TwitterFeeds");
            }
        }

        public MainViewModel()
        {
            TwitterFeeds = new List<TwitterFeed> 
            {
                new TwitterFeed
                {
                    Name = "Anbalagan D",
                    UserName = "@anbu",
                    DateAndTime = "12 hours ago",
                    Description = "Xamarin.Forms provides a consistent API for creating UI elements across platforms. This API can be implemented in either XAML or C# and supports databinding for patterns such as Model-View-ViewModel (MVVM)."
                },
                new TwitterFeed
                {
                    Name = "Saravanan T",
                    UserName = "@saravanan",
                    DateAndTime = "8 hours ago",
                    Description = "தமிழர் என்பவர் தமிழைத் தாய்மொழியாகக் கொண்டவர்களாவர். மிகப் பழைய தமிழ்ச் சமுதாயங்கள் தென்னிந்தியா, இலங்கையைச் சேர்ந்தவைகள் ஆகும்.உலகம் முழுவதிலும் இன்று தமிழர் பரவி வாழ்ந்தாலும் அவர்களது தாயகம் தமிழ்நாடும், தமிழீழமுமே ஆகும்."
                }
            };

            GetPosts();
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        async void GetPosts()
        {
            var client = new HttpClient();
            var respose = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
            var responseString = await respose.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<List<Post>>(responseString);

            TwitterFeeds = posts.ConvertAll(obj => new TwitterFeed {
                Name = "Saravanan T",
                UserName = "@saravanan",
                DateAndTime = "8 hours ago",
                Description = obj.body
            });

            Debug.WriteLine(responseString);
        }

        
    }
}
