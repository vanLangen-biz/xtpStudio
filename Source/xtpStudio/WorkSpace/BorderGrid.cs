using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1
{
    public class BorderGrid
    {
        public AvaloniaProperty<int> ConnectorsProp { get; set; }

        public BorderGrid(AvaloniaProperty<int> connectorsProp, Avalonia.Controls.Grid grid)
        {
            ConnectorsProp = connectorsProp;
        }
    }
}
