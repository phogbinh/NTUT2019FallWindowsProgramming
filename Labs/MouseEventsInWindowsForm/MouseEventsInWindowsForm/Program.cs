using System.Windows.Forms;
namespace MouseEventsInWindowsForm
{
    class MainEntry
    {
        static void Main(string[] args)
        {
            Form form = new MyForm();
            Application.Run(form);
        }
    }
}