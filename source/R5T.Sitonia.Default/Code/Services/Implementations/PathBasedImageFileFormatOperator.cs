using System;

using R5T.Lombardy;
using R5T.Philippi;
using R5T.Sparta;

using R5T.T0064;


namespace R5T.Sitonia.Default
{
    [ServiceImplementationMarker]
    public class PathBasedImageFileFormatOperator : IPathBasedImageFileFormatOperator, IServiceImplementation
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
