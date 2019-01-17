using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AdvertisingWCF.Models;
using Microsoft.Win32;

namespace AdvertisingWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SpamService : ISpamService
    {
        public Advertising GetAdvertising()
        {
            Advertising advertising = null;

            Random random = new Random();

            int number = random.Next(1, 3);

            string path = Path.GetFullPath(@"Images\file" + number + ".jpg");

            using (var fileStream = File.OpenRead(path))
            {
                var result = new byte[fileStream.Length];

                fileStream.Read(result, 0, result.Length);

                var classes = Registry.ClassesRoot;

                var fileClass = classes.OpenSubKey(Path.GetExtension(fileStream.Name));

                advertising = new Advertising
                {
                    Image = result,
                    TypeImage = fileClass.GetValue("Content type").ToString()
                };
            }

            return advertising;
        }
    }
}
