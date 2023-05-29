using System.Globalization;
using System.Threading;

namespace BindingTest;

public partial class App
{
    public App()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
    }
}