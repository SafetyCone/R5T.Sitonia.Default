using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;


namespace R5T.Sitonia.Default
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ImageFileFormatOperator"/> implementation of <see cref="IImageFileFormatOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddImageFileFormatOperator(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperator)
        {
            services
                .AddSingleton<IImageFileFormatOperator, ImageFileFormatOperator>()
                .Run(stringlyTypedPathOperator)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ImageFileFormatOperator"/> implementation of <see cref="IImageFileFormatOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IImageFileFormatOperator> AddImageFileFormatOperatorAction(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperator)
        {
            var serviceAction = ServiceAction.New<IImageFileFormatOperator>(() => services.AddImageFileFormatOperator(
                stringlyTypedPathOperator));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="PathBasedImageFileFormatOperator"/> implementation of <see cref="IPathBasedImageFileFormatOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddPathBasedImageFileFormatOperator(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperator)
        {
            services
                .AddSingleton<IPathBasedImageFileFormatOperator, PathBasedImageFileFormatOperator>()
                .Run(stringlyTypedPathOperator)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="PathBasedImageFileFormatOperator"/> implementation of <see cref="IPathBasedImageFileFormatOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IPathBasedImageFileFormatOperator> AddPathBasedImageFileFormatOperatorAction(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperator)
        {
            var serviceAction = ServiceAction.New<IPathBasedImageFileFormatOperator>(() => services.AddPathBasedImageFileFormatOperator(
                stringlyTypedPathOperator));

            return serviceAction;
        }
    }
}
