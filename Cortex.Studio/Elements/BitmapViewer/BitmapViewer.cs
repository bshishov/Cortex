﻿using System.Windows.Media.Imaging;
using Cortex.Core.Elements;
using Cortex.Core.Model;
using Cortex.Core.Model.Pins;

namespace Cortex.Studio.Elements.BitmapViewer
{
    class BitmapViewer : BaseElement
    {
        public WriteableBitmap Bitmap { get; private set; }

        public BitmapViewer()
        {
            AddInputPin(new FlowInputPin(OnFlow));
            AddInputPin(new DataInputPin("Bitmap", typeof(WriteableBitmap)));
            AddOutputPin(new FlowOutputPin());
        }

        private void OnFlow(Flow flow)
        {
            this.Bitmap = ((IDataInputPin)_inputs[1]).Value as WriteableBitmap;
            ((IFlowOutputPin)_outputs[0]).Call(flow);
        }
    }
}
