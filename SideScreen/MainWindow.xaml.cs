using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using ScreenCapture.NET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.SpeechRecognition;
using Windows.UI.Input.Preview.Injection;
using Microsoft.Graphics.Canvas;
using Vortice.DXGI;
using WinRT;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SideScreen
{
		/// <summary>
		/// An empty window that can be used on its own or navigated to within a Frame.
		/// </summary>
		public sealed partial class MainWindow : Window
		{
				DX11ScreenCaptureService screenCaptureService;
				Thread screenCaptureThread;

				public MainWindow()
				{
						this.InitializeComponent();
						this.ExtendsContentIntoTitleBar = true;

						 

						SurfaceImageSource surfaceImageSource = new SurfaceImageSource(1366, 768);
						//screenImage.Source = surfaceImageSource;
						//CanvasDevice device = new CanvasDevice();
					
				}

				//private void abc()
				//{
				//		bool stopCapturing = false;

				//		// Set up screen capture
				//		if (screenCaptureService == null)
				//				screenCaptureService = new DX11ScreenCaptureService();

				//		IEnumerable<GraphicsCard> graphicsCards = screenCaptureService.GetGraphicsCards();
				//		IEnumerable<Display> displays = screenCaptureService.GetDisplays(graphicsCards.First());

				//		// Capture only the first displays from the first graphics cards
				//		DX11ScreenCapture screenCapture = screenCaptureService.GetScreenCapture(displays.First());

				//		// Capture the whole screen
				//		CaptureZone<ColorBGRA> captureZone = screenCapture.RegisterCaptureZone(0, 0, screenCapture.Display.Width, screenCapture.Display.Height);

				//		// Capture the screen on a seperate thread
				//		screenCaptureThread = new Thread(new ThreadStart(() =>
				//		{
				//				while (!stopCapturing)
				//				{
				//						screenCapture.CaptureScreen();

				//						screenImage.Source = captureZone.Image.;
				//				}
				//		}));
				//		screenCaptureThread.Start();
				//}

				private void myButton_Click(object sender, RoutedEventArgs e)
				{
						//myButton.Content = "Clicked";
				}
		}
}
