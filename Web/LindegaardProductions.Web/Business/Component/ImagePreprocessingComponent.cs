using ImageProcessor;
using ImageProcessor.Imaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Configuration.UmbracoSettings;
using Umbraco.Core.IO;
using Umbraco.Core.Models;
using Umbraco.Core.PropertyEditors.ValueConverters;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;

namespace LindegaardProductions.Web.Business.Component
{
    public class ImagePreprocessingComponent : IComponent
    {
        private readonly IMediaFileSystem _mediaFileSystem;
        private readonly IContentSection _contentSection;
        private readonly int ImageWidth = 1920;

        public ImagePreprocessingComponent(IMediaFileSystem mediaFileSystem, IContentSection contentSection)
        {
            _mediaFileSystem = mediaFileSystem;
            _contentSection = contentSection;
        }
        public void Initialize()
        {
            MediaService.Saving += MediaService_Saving;
        }

        public void Terminate()
        {
        }
        private void MediaService_Saving(IMediaService sender, Umbraco.Core.Events.SaveEventArgs<Umbraco.Core.Models.IMedia> e)
        {
            IEnumerable<string> supportedTypes = _contentSection.ImageFileTypes.ToList();
            foreach (IMedia media in e.SavedEntities)
            {
                if (media.HasProperty("umbracoFile"))
                {
                    //Make sure it's an image.
                    string cropInfo = media.GetValue<string>("umbracoFile");
                    if (!cropInfo.EndsWith(".pdf") && !cropInfo.EndsWith(".mp4") && !cropInfo.EndsWith(".mp3"))
                    {
                        string path = JsonConvert.DeserializeObject<ImageCropperValue>(cropInfo).Src;
                        string extension = Path.GetExtension(path).Substring(1);
                        if (supportedTypes.InvariantContains(extension))
                        {
                            //Resize the image to 1920px wide, height is driven by the aspect ratio of the image.
                            string fullPath = _mediaFileSystem.GetFullPath(path);
                            using (ImageFactory imageFactory = new ImageFactory(true))
                            {
                                ResizeLayer layer = new ResizeLayer(new Size(ImageWidth, 0), ResizeMode.Max)
                                {
                                    Upscale = false
                                };

                                var image = imageFactory.Load(fullPath);
                                // Only manipulate the image if it is larger than 1920px wide. 
                                if (image.Image.Width > ImageWidth)
                                {
                                    image.Resize(layer);
                                    media.SetValue("umbracoWidth", image.Image.Width);
                                    media.SetValue("umbracoHeight", image.Image.Height);
                                    image.Save(fullPath);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
