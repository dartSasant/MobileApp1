using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;

#if ANDROID
using Android.Content.Res;
using Android.Graphics;
#endif

namespace MobileApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.BackgroundTintList =
                    Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#endif
            });

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Brands-Regular-400.otf", "FABrands");
                    fonts.AddFont("Free-Regular-400.otf", "FARegular");
                    fonts.AddFont("Free-Solid-900.otf", "FASolid");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
