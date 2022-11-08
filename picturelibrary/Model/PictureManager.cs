using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace picturelibrary.Model
{
    internal class PictureManager
    {
        public static void GetAllPictures( ObservableCollection<Picture> pictures)
            //this method will update the list incase any changes happened and get all the pictures from GetPictures
        {
            var allpictures = GetPictures();
            pictures.Clear();
            allpictures.ForEach(picture => pictures.Add(picture));
        }
        public static void GetAllPicturesByCategory(ObservableCollection<Picture> pictures,
            PictureCategory category)
            //this method filter the pictures which matches the category with user clicked icon and make a list.
        {
            var allpictures = GetPictures();
            pictures.Clear();
            var selectedpictures = allpictures.Where(picture => 
            picture.Category == category).ToList();
            selectedpictures.ForEach(picture => pictures.Add(picture));
        }
        public static void OnePicture(ObservableCollection<Picture> picturesbig,string name)
            //this method willdo the part(choose the clicked picture and make it big) to change the image size after its been clicked.
        {
            var bigimage = GetBigPicture();
            picturesbig.Clear();
            var selectname = bigimage.Where(picture => picture.Name == name).ToList();
            selectname.ForEach(picture => picturesbig.Add(picture));
            
        }
        
          private static List<Picture> GetPictures()//initial List of pictures.
          {
            var pictures = new List<Picture>();
            pictures.Add(new Picture("sunrise1", PictureCategory.sunrise));
            pictures.Add(new Picture("sunrise2", PictureCategory.sunrise));
            pictures.Add(new Picture("sunrise3", PictureCategory.sunrise));
            pictures.Add(new Picture("flowers1", PictureCategory.flowers));
            pictures.Add(new Picture("flowers2", PictureCategory.flowers));
            pictures.Add(new Picture("flowers3", PictureCategory.flowers));

            return pictures;
        }
       private static List<Picture> GetBigPicture()// we are using this list of pictures to show the bigger image.
            //pictures and its size are same.we are using two lists so that we can show the thumbnail size and bigger image back and forth.
            //if we use only one list,then the images are showing either big or small(depends on code)not back and forth.
        {

            var picturesbig = new List<Picture>();
            picturesbig.Add(new Picture("sunrise1", PictureCategory.sunrise));
            picturesbig.Add(new Picture("sunrise2", PictureCategory.sunrise));
            picturesbig.Add(new Picture("sunrise3", PictureCategory.sunrise));
            picturesbig.Add(new Picture("flowers1", PictureCategory.flowers));
            picturesbig.Add(new Picture("flowers2", PictureCategory.flowers));
            picturesbig.Add(new Picture("flowers3", PictureCategory.flowers));

            return picturesbig;
        }
    }
}
