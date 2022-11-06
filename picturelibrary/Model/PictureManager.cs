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
        {
            var allpictures = GetPictures();
            pictures.Clear();
            allpictures.ForEach(picture => pictures.Add(picture));
        }
        public static void GetAllPicturesByCategory(ObservableCollection<Picture> pictures,
            PictureCategory category)
        {
            var allpictures = GetPictures();
            pictures.Clear();
            var selectedpictures = allpictures.Where(picture => 
            picture.Category == category).ToList();
            selectedpictures.ForEach(picture => pictures.Add(picture));
        }
        public static void OnePicture(ObservableCollection<Picture> pictures,string name)
        {
            var bigimage = GetPictures();
            pictures.Clear();
            var selectname = bigimage.Where(picture => picture.Name == name).ToList();
            selectname.ForEach(picture => pictures.Add(picture));
            
        }
        
        private static List<Picture> GetPictures()
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
    }
}
