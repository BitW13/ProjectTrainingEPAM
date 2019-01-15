using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Models;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Spam : ISpam
    {
        public Advertising GetSpamImage()
        {
            Advertising advertising;

            using (var fileStream = File.OpenRead(@"~\Images\file.jpg"))
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
