using System;

using R5T.Lombardy;
using R5T.Magyar;
using R5T.Philippi;
using R5T.Sparta;


namespace R5T.Sitonia.Default
{
    public class PathBasedImageFileFormatOperator : IPathBasedImageFileFormatOperator
    {
        #region Static

        public static FileFormat GetFileFormatAllowUnknown(FilePath imageFilePath, IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            var fileExtension = stringlyTypedPathOperator.GetFileExtension(imageFilePath.Value);

            var upperFileExtension = fileExtension.ToUpperInvariant();
            switch (upperFileExtension)
            {
                case "BMP":
                    return FileFormat.BMP;

                case "JPG":
                case "JPEG":
                    return FileFormat.JPG;

                case "PNG":
                    return FileFormat.JPG;

                default:
                    return FileFormat.Unknown;
            }
        }

        public static FileFormat GetFileFormatNoUnknown(FilePath imageFilePath, IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            var fileFormat = PathBasedImageFileFormatOperator.GetFileFormatAllowUnknown(imageFilePath, stringlyTypedPathOperator);

            if (fileFormat == FileFormat.Unknown)
            {
                var fileExtension = stringlyTypedPathOperator.GetFileExtension(imageFilePath.Value);

                var message = EnumHelper.UnrecognizedEnumerationValueMessage<FileFormat>(fileExtension);
                throw new Exception(message);
            }

            return fileFormat;
        }

        #endregion


        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public PathBasedImageFileFormatOperator(IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        /// <summary>
        /// Uses the <see cref="PathBasedImageFileFormatOperator.GetFileFormatAllowUnknown(FilePath, IStringlyTypedPathOperator)"/> implementation as the default.
        /// </summary>
        public FileFormat GetFileFormat(FilePath imageFilePath)
        {
            var fileFormat = PathBasedImageFileFormatOperator.GetFileFormatAllowUnknown(imageFilePath, this.StringlyTypedPathOperator);
            return fileFormat;
        }
    }
}
