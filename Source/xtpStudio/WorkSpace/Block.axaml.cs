using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace AvaloniaApplication1
{
    public class Block : UserControl
    {
        private readonly Grid _mainGrid;
        private readonly ContentPresenter _contentPresenter;

        public Block()
        {
            InitializeComponent();
            _contentPresenter = this.FindControl<ContentPresenter>("PART_Content");
            //_border = this.FindControl<Border>("Border1");
            _labelStatus = this.FindControl<Label>("LabelStatus");

         //   PropertyChanged += Block_PropertyChanged;

            _mainGrid = this.FindControl<Grid>("MainGrid");

            var connector = new Connector();
            Grid.SetColumn(connector, 2);
            Grid.SetRow(connector, 0);
            Grid.SetRowSpan(connector, 2);

            

            _mainGrid.Children.Add(connector);

            var connector2 = new Connector();
            Grid.SetColumn(connector2, 3);
            Grid.SetRow(connector2, 3);
            Grid.SetRowSpan(connector2, 2);

            _mainGrid.Children.Add(connector2);

            var connector3 = new Connector();
            Grid.SetColumn(connector3, 1);
            Grid.SetRow(connector3, 3);
            Grid.SetRowSpan(connector3, 2);

            _mainGrid.Children.Add(connector3);
        }

        private Label _labelStatus;
    

        //private void Block_PropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        //{
        //    if (e.NewValue == null || e.OldValue == null)
        //        return;

       

        //    //if (e.Property == ConnectorsLeftProp)
        //    //{
        //    //    var delta = ((int)e.OldValue - (int)e.NewValue);

        //    //    if (delta > 0)
        //    //    {
        //    //        for (int i = 0; i < delta; i++)
        //    //        {
        //    //            var indexOfLastItem = _leftGrid.Children.Count - 1;
        //    //            _leftGrid.Children.RemoveAt(indexOfLastItem);
        //    //            _leftGrid.RowDefinitions.RemoveAt(indexOfLastItem);
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        delta = -delta;
        //    //        if (delta > 0)
        //    //        {
        //    //            var addColumns = (int)e.NewValue - (int)e.OldValue;
        //    //            int index = (int)e.OldValue;
        //    //            for (int i = 0; i < delta; i++)
        //    //            {
        //    //                _leftGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(24) });
        //    //                var label = new Connector();
        //    //                Grid.SetRow(label, index);
        //    //                _leftGrid.Children.Add(label);
        //    //                index++;
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //}

        public static readonly AvaloniaProperty<int> ConnectorsLeftProp = AvaloniaProperty.Register<Block, int>(nameof(ConnectorsLeft), 0);
        public static readonly AvaloniaProperty<int> ConnectorsUpProp = AvaloniaProperty.Register<Block, int>(nameof(ConnectorsUp), 0);
        public static readonly AvaloniaProperty<int> ConnectorsRightProp = AvaloniaProperty.Register<Block, int>(nameof(ConnectorsRight), 0);
        public static readonly AvaloniaProperty<int> ConnectorsBottomProp = AvaloniaProperty.Register<Block, int>(nameof(ConnectorsBottom), 0);


        public int ConnectorsLeft
        {
            get => this.GetValue<int>(ConnectorsLeftProp);
            set => this.SetValue(ConnectorsLeftProp, value);
        }

        public int ConnectorsUp
        {
            get => this.GetValue<int>(ConnectorsUpProp);
            set => this.SetValue(ConnectorsUpProp, value);
        }
        public int ConnectorsRight
        {
            get => this.GetValue<int>(ConnectorsRightProp);
            set => this.SetValue(ConnectorsRightProp, value);
        }
        public int ConnectorsBottom
        {
            get => this.GetValue<int>(ConnectorsBottomProp);
            set => this.SetValue(ConnectorsBottomProp, value);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}