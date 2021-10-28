using Xamarin.Forms;

namespace Twitter
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			BindingContext = new MainViewModel();
		}
	}
}
