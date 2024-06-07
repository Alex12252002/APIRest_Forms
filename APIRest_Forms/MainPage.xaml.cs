using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace APIRest_Forms
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "https://jsonplaceholder.typicode.com/posts";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Model_Post> _post;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    string content = await client.GetStringAsync(Url);
                    List<Model_Post> posts = JsonConvert.DeserializeObject<List<Model_Post>>(content);
                    _post = new ObservableCollection<Model_Post>(posts);
                    MyListView.ItemsSource = _post;
                }
                catch (HttpRequestException httpEx)
                {
                    // Handle HTTP request exceptions
                    await DisplayAlert("Error", "Error de solicitud HTTP: " + httpEx.Message, "OK");
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    await DisplayAlert("Error", "Se produjo un error: " + ex.Message, "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "No hay conexión a Internet.", "OK");
            }
        }
    }
}
