using MediaSample.Lib.Shared;
using Plugin.Media;
using System.IO;
using Xamarin.Forms;

namespace MediaSample
{
    public partial class MediaPage : ContentPage
  {
    public MediaPage()
    {
      InitializeComponent();

      pickPhoto.Clicked += async (sender, args) =>
      {
        if (!CrossMedia.Current.IsPickPhotoSupported)
        {
          await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
          return;
        }
          using (var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
          {
              PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
          }))
          {


              if (file == null)
                  return;

              image.Source = ImageSource.FromStream(() =>
              {
                  var stream = file.GetStream();

                  return stream;
              });

              var converter = DependencyService.Get<IConverter>();
              var outputpath = await converter?.Save(file.Path, "", ImageFileType.PNG);
          }
      };

            openFile.Clicked += async (sender, args) =>
            {

                var result = await Plugin.FilePicker.CrossFilePicker.Current.PickFile();
                System.Diagnostics.Debug.WriteLine(result.FileName);
            };
    }
  }
}
