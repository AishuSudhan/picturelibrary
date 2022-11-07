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
using picturelibrary.Model;
using System.Collections.ObjectModel;
using Windows.UI.Core;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace picturelibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Picture> pictures;
        private List<Icon> iconimage;
        private ObservableCollection<Picture> bigimage;
        private ObservableCollection<Picture> picturesbig;
        public MainPage()
        {
            this.InitializeComponent();
             pictures = new ObservableCollection<Picture>();
            PictureManager.GetAllPictures(pictures);

            bigimage = new ObservableCollection<Picture>();
            PictureManager.GetAllPictures(bigimage);

            picturesbig = new ObservableCollection<Picture>();
            

            iconimage = new List<Icon>();
            iconimage.Add(new Icon
            {
                IconFile = $"Assets/IconFile/flower.jpg",
                Category = PictureCategory.flowers
            });
            iconimage.Add(new Icon
            {
                IconFile = $"assets/IconFile/sun.jpg",
                Category =PictureCategory.sunrise
            });
            Backbutton.Visibility = Visibility.Collapsed;
            
        }

        private void Hamburgerbutton_Click(object sender, RoutedEventArgs e)
        {
            ContentSplitView.IsPaneOpen = !ContentSplitView.IsPaneOpen;
           
        }

        private void Backbutton_Click(object sender, RoutedEventArgs e)
        {
            PictureManager.GetAllPictures(pictures);
            Backbutton.Visibility = Visibility.Collapsed;
            Title.Text = "Nature";
            iconitems.SelectedItem = null;
        }

        private void imagegridview_ItemClick(object sender, ItemClickEventArgs e)
        {
            bigimagegridview.Visibility = Visibility.Visible;
            var selectitem = (Picture)e.ClickedItem;
            PictureManager.OnePicture(picturesbig, selectitem.Name);
            Backbutton.Visibility = Visibility.Collapsed;
            Title.Visibility = Visibility.Collapsed;
        }

        private void iconitems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var items = (Icon)e.ClickedItem;
            PictureManager.GetAllPicturesByCategory(pictures, items.Category);
            Title.Text = items.Category.ToString();
           Title.Visibility = Visibility.Collapsed;
            Backbutton.Visibility = Visibility.Visible;
        }

        private void backtonormalsize_Click(object sender, RoutedEventArgs e)
        {
            bigimagegridview.Visibility = Visibility.Collapsed;
            PictureManager.GetAllPictures(pictures);
            Backbutton.Visibility = Visibility.Collapsed;
            Title.Text = "Nature";
            iconitems.SelectedItem = null;
        }

        
    }
}
