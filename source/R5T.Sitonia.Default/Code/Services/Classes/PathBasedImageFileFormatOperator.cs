using System;

using R5T.Lombardy;
using R5T.Philippi;
using R5T.Sparta;


namespace R5T.Sitonia.Default
{
    public class PathBasedImageFileFormatOperator : IPathBasedImageFileFormatOperator
    {
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public PathBasedImageFileFormatOperator(IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        /// <summary>
        /// Uses the <see cref="ImageFileFormatOperator.GetFileFormatAllowUnknown(FilePath, IStringlyTypedPathOperator)"/> implementation as the default.
        /// </summary>
        public FileFormat GetFileFormat(FilePath imageFilePath)
        {
            var fileFormat = ImageFileFormatOperator.GetFileFormatAllowUnknown(imageFilePath, this.StringlyTypedPathOperator);
            return fileFormat;
        }
    }
}
