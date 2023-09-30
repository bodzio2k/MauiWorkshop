namespace MonkeyFinder;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);


        window.Activated += Window_Activated;
        return window;
    }

    private void Window_Activated(object sender, EventArgs e)
    {
#if WINDOWS
        var window = sender as Window;

        const int height = 720;
        const int width = 360;

        window.Height = height;
        window.Width = width;
#endif
    }
}
