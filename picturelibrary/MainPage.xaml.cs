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
        //observable collection observabes the list and updates the class if there is any changes happened by user in the list of items.
        //it will do it on its own.we dont have to do it by any codes. 
        private List<Icon> iconimage;
        private ObservableCollection<Picture> bigimage;
        private ObservableCollection<Picture> picturesbig;
        public MainPage()
        {
            this.InitializeComponent();
             pictures = new ObservableCollection<Picture>();//creating instance for the object pictures(so that it creates memory space.)
             PictureManager.GetAllPictures(pictures);//calling GetAllPicture utility method from PictureManager.cs and passing pictures into that method.

            bigimage = new ObservableCollection<Picture>();//creating instance for the object bigimage
            PictureManager.GetAllPictures(bigimage);

            picturesbig = new ObservableCollection<Picture>();//creating instance for the object picturesbig


            iconimage = new List<Icon>();//creating instance for the object iconimage
            //since icon list has less work and no methods to call and no need for observablecollection it wont change that much
            //we are not creating seperate utility class for icon list and assing proerty values in xaml.cs itself.
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
            //this will make the pane open if it is not open and close it if it is open.
           
        }

        private void Backbutton_Click(object sender, RoutedEventArgs e)
        {
            PictureManager.GetAllPictures(pictures);
            Backbutton.Visibility = Visibility.Collapsed;
            Title.Text = "Nature";
            iconitems.SelectedItem = null;//it will stop the icon showing as selected(blue imaage on selected icon) after it moves to different image. 
        }

        private void imagegridview_ItemClick(object sender, ItemClickEventArgs e)
        {
            bigimagegridview.Visibility = Visibility.Visible;
            var selectitem = (Picture)e.ClickedItem;//e is the item clicked(which is Picture class object in grid view) 
            PictureManager.OnePicture(picturesbig, selectitem.Name);
            Backbutton.Visibility = Visibility.Collapsed;
            Title.Visibility = Visibility.Collapsed;
        }

        private void iconitems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var items = (Icon)e.ClickedItem;//e is the item clicked which is Icon class Object.
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
