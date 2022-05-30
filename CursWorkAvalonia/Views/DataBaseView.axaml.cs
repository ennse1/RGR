using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CursWorkAvalonia.Views
{
    public partial class DataBaseView : UserControl
    {
        public DataBaseView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
