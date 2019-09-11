using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Notepad.Helpers
{
    public static class CompressionHelper
    {
        #region Public Methods

        public static byte[] ToByteArray(this string data, string archiveName, int compressLevel)
        {
            var result = default(byte[]);

            try
            {
                using (var msInput = new MemoryStream(Encoding.UTF8.GetBytes(data)))
                using (var msOutput = new MemoryStream())
                using (var zipStream = new ZipOutputStream(msOutput))
                {
                    zipStream.SetLevel(compressLevel);
                    zipStream.PutNextEntry(new ZipEntry(archiveName)
                    {
                        DateTime = DateTime.UtcNow
                    });

                    StreamUtils.Copy(msInput, zipStream, new byte[4096]);
                    zipStream.CloseEntry();

                    zipStream.IsStreamOwner = false;
                    zipStream.Close();

                    msOutput.Position = 0;

                    result = msOutput.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return result;
        }

        public static string ToStringText(this byte[] archiveArray)
        {
            var result = string.Empty;

            using (var msFile = new MemoryStream(archiveArray))
            using (var zFile = new ZipFile(msFile))
            {
                try
                {
                    var buffer = new byte[4096];

                    foreach (ZipEntry entry in zFile)
                    {
                        var zStream = zFile.GetInputStream(entry);
                        using (var msStream = new MemoryStream())
                        {
                            StreamUtils.Copy(zStream, msStream, buffer);
                            msStream.Position = 0;
                            result = Encoding.UTF8.GetString(msStream.ToArray());
                        }
                    }
                }
                finally
                {
                    zFile.IsStreamOwner = true;
                    zFile.Close();
                }
            }

            return result;
        }

        #endregion Public Methods
    }
}