////using EmbedIO;
////using GenHTTP.Engine;
//using ScreenCapture.NET;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using Windows.UI.Input.Preview.Injection;

//namespace WebScreen
//{
//		public class ScreenShareOptions
//		{
//				public bool isInputEnabled;
//				public int delay = 100;
//		}

//		internal class ScreenShareService
//		{
//				// Server
//				WebSocketBitmap webSocketBitmap;
//				WebSocketInput webSocketInput;
//				WebSocketLog webSocketLog;
//				WebServer server;

//				// Screen capture
//				IScreenCaptureService screenCaptureService;
//				Thread screenCaptureThread;
//				InputInjector inputInjector;
//				bool stopCapturing = false;

//				// Event
//				public event EventHandler<string> Started;
//				public event EventHandler<string> OnLog;

//				public ScreenShareService() { }

//				//private void RunServer(int port)
//				//{
//				//		webSocketBitmap = new WebSocketBitmap("/bitmap");
//				//		webSocketInput = new WebSocketInput("/input");
//				//		webSocketInput.OnInput += ProcessInput;

//				//		WebSocketLog webSocketLog = new WebSocketLog("/log", message => OnLog.Invoke(this, message));

//				//		server = new WebServer(port)
//				//				.WithLocalSessionManager()
//				//				.WithModule(webSocketBitmap)
//				//				.WithModule(webSocketInput)
//				//				.WithModule(webSocketLog)
//				//				//.WithStaticFolder("/", "./Website", false);
//				//				.WithEmbeddedResources("/", typeof(MainWindow).Assembly, "WebScreen.Website");

//				//		server.RunAsync();
//				//		//Started.Invoke(this, Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].Address.ToString());
//				//}

//				public void Start(int port, ScreenShareOptions options)
//				{
//						stopCapturing = false;

//						//RunServer(port);

//						// Set up touch input
//						if (options.isInputEnabled)
//						{
//								inputInjector = InputInjector.TryCreate();
//								inputInjector.InitializeTouchInjection(InjectedInputVisualizationMode.Default);
//						}

//						// Set up screen capture
//						if (screenCaptureService == null)
//								screenCaptureService = new DX11ScreenCaptureService();
						
//						IEnumerable<GraphicsCard> graphicsCards = screenCaptureService.GetGraphicsCards();
//						IEnumerable<Display> displays = screenCaptureService.GetDisplays(graphicsCards.First());

//						// Capture only the first displays from the first graphics cards
//						IScreenCapture screenCapture = screenCaptureService.GetScreenCapture(displays.First());

//						// Capture the whole screen
//						ICaptureZone captureZone = screenCapture.RegisterCaptureZone(0, 0, screenCapture.Display.Width, screenCapture.Display.Height);
						
//						// Capture the screen on a seperate thread
//						screenCaptureThread = new Thread(new ThreadStart(() =>
//						{
//								while (!stopCapturing)
//								{
//										screenCapture.CaptureScreen();

//										webSocketBitmap.SendBitmap(captureZone.RawBuffer);

//										Thread.Sleep(options.delay);
//								}
//						}));
//						screenCaptureThread.Start();
//				}

//				public void Stop()
//				{
//						stopCapturing = true;
//						if (server != null)
//								server.Dispose();
//						//screenCaptureService.Dispose();
//				}

//				private void ProcessInput(object sender, List<InputMessage> e)
//				{
//						List<InjectedInputTouchInfo> touchInfo = new List<InjectedInputTouchInfo>();

//						foreach (InputMessage input in e)
//						{
//								OnLog.Invoke(this, input.ID + " " + input.Type);
//								switch (input.Type)
//								{
//										case 1:
//												{
//														touchInfo.Add(
//																new InjectedInputTouchInfo
//																{
//																		Contact = new InjectedInputRectangle
//																		{
//																				Left = input.X,
//																				Right = input.X,
//																				Top = input.Y,
//																				Bottom = input.Y
//																		},
//																		PointerInfo = new InjectedInputPointerInfo
//																		{
//																				PointerId = input.ID,
//																				PointerOptions =
//																				InjectedInputPointerOptions.InRange |
//																				InjectedInputPointerOptions.InContact |
//																				InjectedInputPointerOptions.PointerDown,
//																				TimeOffsetInMilliseconds = 0,
//																				PixelLocation = new InjectedInputPoint
//																				{
//																						PositionX = input.X,
//																						PositionY = input.Y
//																				}

//																		},
//																		Pressure = 1,
//																		TouchParameters =
//																		InjectedInputTouchParameters.Pressure |
//																		InjectedInputTouchParameters.Contact
//																});
//														break;
//												}
//										case 2:
//												{
//														touchInfo.Add(
//																new InjectedInputTouchInfo
//																{
//																		Contact = new InjectedInputRectangle
//																		{
//																				Left = input.X,
//																				Right = input.X,
//																				Top = input.Y,
//																				Bottom = input.Y
//																		},
//																		PointerInfo = new InjectedInputPointerInfo
//																		{
//																				PointerId = input.ID,
//																				PointerOptions =
//																				InjectedInputPointerOptions.InRange |
//																				InjectedInputPointerOptions.InContact |
//																				InjectedInputPointerOptions.Update,
//																				TimeOffsetInMilliseconds = 0,
//																				PixelLocation = new InjectedInputPoint
//																				{
//																						PositionX = input.X,
//																						PositionY = input.Y
//																				}
//																		},
//																		Pressure = 1,
//																		TouchParameters =
//																		InjectedInputTouchParameters.Pressure |
//																		InjectedInputTouchParameters.Contact
//																});
//														break;
//												}
//										case 3:
//												{
//														touchInfo.Add(
//																new InjectedInputTouchInfo
//																{
//																		PointerInfo = new InjectedInputPointerInfo
//																		{
//																				PointerId = input.ID,
//																				PointerOptions = InjectedInputPointerOptions.PointerUp
//																		}
//																});
//														break;
//												}
//								}
//						}

//						inputInjector.InjectTouchInput(touchInfo);
//				}
//		}
//}
