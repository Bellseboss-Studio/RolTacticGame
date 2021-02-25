public class ServiceOfDebug: IServiceOfDebug
{
    private IDebugView debugView;

    public ServiceOfDebug(IDebugView debugView)
    {
        this.debugView = debugView;
    }

    public void PrintDebug(string text)
    {
        debugView.WhriteTextInDebug(text);
    }
}