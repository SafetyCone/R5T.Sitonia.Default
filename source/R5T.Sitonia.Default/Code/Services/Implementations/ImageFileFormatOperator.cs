using System;

using R5T.Cherusci;
using R5T.Lombardy;
using R5T.Magyar;
using R5T.Philippi;
using R5T.Sparta;

using R5T.T0064;


namespace R5T.Sitonia.Default
{
    [ServiceImplementationMarker]
    public class ImageFileFormatOperator : IImageFileFormatOperator, IServiceImplementation
    {
        #region Static

        public static FileFormat GetFileFormatAllowUnknown(FilePath imageFilePath, IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            var fileExtension = stringlyTypedPathOperator.GetFileExtension(imageFilePath.Value);

            var loweredFileExtension = fileExtension.ToLowerInvariant();
            switch (loweredFileExtension)
            {
                case FileExtensions.Bitmap:
                    return FileFormat.Bitmap;

                case FileExtensions.Jpg:
                case FileExtensions.Jpeg:
                    return FileFormat.Jpg;

                case FileExtensions.Png:
                    return FileFormat.Png;

                default:
                    return FileFormat.Unknown;
            }
        }

        public static FileFormat GetFileFormatNoUnknown(FilePath imageFilePath, IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            var fileFormat = ImageFileFormatOperator.GetFileFormatAllowUnknown(imageFilePath, stringlyTypedPathOperator);

            if (fileFormat == FileFormat.Unknown)
            {
                var fileExtension = stringlyTypedPathOperator.GetFileExtension(imageFilePath.Value);

                var message = EnumerationHelper.UnrecognizedEnumerationValueMessage<FileFormat>(fileExtension);
                throw new Exception(message);
            }

            return fileFormat;
        }

        public static string GetFileExtensionNoUnknown(FileFormat fileFormat)
        {
            switch(fileFormat)
            {
                case FileFormat.Bitmap:
                    return FileExtensions.Bitmap;

                case FileFormat.Jpg:
                    return FileExtensions.Jpg;

                case FileFormat.Png:
                    return FileExtensions.Png;

                default:
                    var message = EnumerationHelper.UnexpectedEnumerationValueMessage<FileFormat>(fileFormat);
                    throw new Exception(message);
            }
        }

        #endregion


        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public ImageFileFormatOperator(IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public string GetFileExtension(FileFormat fileFormat)
        {
            var fileExtension = ImageFileFormatOperator.GetFileExtensionNoUnknown(fileFormat);
            return fileExtension;
        }

        public FileFormat GetFileFormat(FilePath imageFilePath)
        {
            var fileFormat = ImageFileFormatOperator.GetFileFormatNoUnknown(imageFilePath, this.StringlyTypedPathOperator);
            return fileFormat;
        }
    }
}
