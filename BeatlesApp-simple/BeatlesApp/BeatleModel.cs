using System.Collections.Generic;
using Xamarin.Forms;

namespace BeatlesApp
{
    public class BeatleModel
    {
        public string Name { get; }
        public ImageSource Image { get; }
        public string Bio { get; }
        public BeatleModel(string name, ImageSource image, string bio)
        {
            Name = name;
            Image = image;
            Bio = bio;
        }

        public static IEnumerable<BeatleModel> GetBeatles()
        {
            yield return new BeatleModel("John Lennon", ImageSource.FromResource("BeatlesApp.Images.John.jpg"), "John Winston Ono Lennon, MBE (born John Winston Lennon; 9 October 1940 – 8 December 1980) was an English singer-songwriter and activist who co-founded the Beatles, the most commercially successful and musically influential band in the history of popular music. He and fellow member Paul McCartney formed a much-celebrated songwriting partnership.");
            yield return new BeatleModel("Paul McCartney", ImageSource.FromResource("BeatlesApp.Images.Paul.jpg"), "Sir James Paul McCartney, CH, MBE (born 18 June 1942) is an English singer-songwriter, multi-instrumentalist, and composer. He gained worldwide fame as the bass guitarist and singer for the rock band the Beatles, widely considered the most popular and influential group in the history of pop music. His songwriting partnership with John Lennon is the most celebrated of the post-war era. After the band's break-up, he pursued a solo career and formed the band Wings with his first wife, Linda, and Denny Laine.");
            yield return new BeatleModel("George Harrison", ImageSource.FromResource("BeatlesApp.Images.George.jpg"), "George Harrison, MBE (25 February 1943 – 29 November 2001) was an English guitarist, singer-songwriter, and producer who achieved international fame as the lead guitarist of The Beatles. Often referred to as \"the quiet Beatle\", Harrison embraced Hinduism and helped broaden the horizons of his fellow band mates as well as their American audience by incorporating Indian instrumentation in their music. Although most of the Beatles' songs were written by John Lennon and Paul McCartney, most Beatles albums from 1965 onwards contained at least two Harrison compositions. His songs for the group included \"Taxman\", \"Within You Without You\", \"While My Guitar Gently Weeps\", \"Here Comes the Sun\" and \"Something\", the last of which became the Beatles' second-most covered song.");
            yield return new BeatleModel("Ringo Starr", ImageSource.FromResource("BeatlesApp.Images.Ringo.jpg"), "Richard Starkey, MBE (born 7 July 1940), known professionally as Ringo Starr, is an English drummer, singer, songwriter and actor who gained worldwide fame as the drummer for the Beatles. He occasionally sang lead vocals, usually for one song on an album, including \"With a Little Help from My Friends\", \"Yellow Submarine\", \"Good Night\", and their cover of \"Act Naturally\". He also wrote the Beatles' songs \"Don't Pass Me By\" and \"Octopus's Garden\", and is credited as a co-writer of others, including \"What Goes On\" and \"Flying\".");
        }
    }
}
