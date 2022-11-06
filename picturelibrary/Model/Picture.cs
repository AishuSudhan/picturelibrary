using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml.Media;

namespace picturelibrary.Model
{
    internal enum PictureCategory
    {
        sunrise,
        flowers

    }
    internal class Picture
    {
        public string Name { get; set; }
        public string ImageFile { get; set; }
        public PictureCategory Category { get; set; }
        public Stretch Stretch { get; set; }
       
        public Picture(string name,PictureCategory category)
        {
            Name = name;
            Category = category;
            ImageFile = $"Assets/{category}/{name}.jpg";
        }

        
    }

}
