using Android.App;
using Android.OS;
using Microsoft.Maui.Embedding;
using Microsoft.Maui.Platform;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.DataGrid;

namespace SfDataGridAndroidSample
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        MauiContext? _mauiContext;
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Setup MauiBits
            var builder = MauiApp.CreateBuilder();

            //Add Maui Controls
            builder.UseMauiEmbedding<Microsoft.Maui.Controls.Application>();
            builder.ConfigureSyncfusionCore();
            var mauiApp = builder.Build();

            //Create and save a Maui Context. This is needed for creating Platform UI
            _mauiContext = new MauiContext(mauiApp.Services, this);

            // - create the DataGrid control
            SfDataGrid datagrid = new SfDataGrid();
            OrderInfoRepository viewModel = new OrderInfoRepository();
            datagrid.ItemsSource = viewModel.OrderInfoCollection;
            datagrid.GridLinesVisibility = GridLinesVisibility.Both;
            datagrid.HeaderGridLinesVisibility = GridLinesVisibility.Both;

            //Turn the Maui page into an Android View
            var view = datagrid.ToPlatform(_mauiContext);

            // Explicitly turn it into a container view
            var containerView = datagrid.ToContainerView(_mauiContext);

            SetContentView(containerView);

        }
    }

}