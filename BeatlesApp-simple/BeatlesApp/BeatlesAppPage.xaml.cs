using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BeatlesApp
{
    public partial class BeatlesAppPage : ContentPage
    {
        IList<BeatleModel> _beatles = BeatleModel.GetBeatles().ToList();
        IList<Image> _images;

        public BeatlesAppPage()
        {
            InitializeComponent();
            _beatles = BeatleModel.GetBeatles().ToList();
            _images = new List<Image> { TopLeftImage, TopRightImage, BottomLeftImage, BottomRightImage };

            InitBeatleCell(TopLeftLabel, 0);
            InitBeatleCell(TopRightLabel, 1);
            InitBeatleCell(BottomLeftLabel, 2);
            InitBeatleCell(BottomRightLabel, 3);
        }

        private void InitBeatleCell(Label label, int index)
        {
            var beatle = _beatles[index];
            var image = _images[index];

            image.Source = beatle.Image;
            label.Text = beatle.Name;

            var t = new TapGestureRecognizer();
            t.Tapped += async (sender, e) => await OpenDetails(beatle);
            image.GestureRecognizers.Add(t);
            label.GestureRecognizers.Add(t);
        }

        private Task OpenDetails(BeatleModel beatle)
        {
            var details = new DetailsPage(beatle);
            return Navigation.PushAsync(details);
        }
    }
}
