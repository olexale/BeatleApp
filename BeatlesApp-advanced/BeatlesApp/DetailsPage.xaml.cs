using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BeatlesApp
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(BeatleModel beatle)
        {
            InitializeComponent();

            Title.Text = beatle.Name;
            Image.Source = beatle.Image;
            Bio.Text = beatle.Bio;
        }

        async void Handle_Back(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
