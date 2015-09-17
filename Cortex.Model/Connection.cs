using System;
using System.Linq;
using Cortex.Model.Pins;
using Cortex.Model.Serialization;

namespace Cortex.Model
{
    public class Connection : IConnection
    {
        public IElement StartElement { get; private set; }

        public IElement EndElement { get; private set; }

        public IOutputPin StartPin { get; private set; }

        public IInputPin EndPin { get; private set; }

        public Connection(IElement startElement, IOutputPin startPin, IElement endElement, IInputPin endPin)
        {
            StartElement = startElement;
            EndElement = endElement;

            if (!startElement.Outputs.Contains(startPin) || !EndElement.Inputs.Contains(endPin))
                throw new Exception("Pins not from this elements");
            StartPin = startPin;
            EndPin = endPin;
        }

        public Connection()
        {
            
        }

        public void Save(IPersisterWriter persister)
        {
            persister.Set("StartElement", StartElement);
            persister.Set("EndElement", EndElement);
            persister.Set("StartPin", StartElement.Outputs.ToList().IndexOf(StartPin));
            persister.Set("EndPin", EndElement.Inputs.ToList().IndexOf(EndPin));
        }

        public void Load(IPersisterReader persister)
        {
            StartElement = persister.Get<IElement>("StartElement");
            EndElement = persister.Get<IElement>("EndElement");
            StartPin = StartElement.Outputs.ElementAt(persister.Get<int>("StartPin"));
            EndPin = EndElement.Inputs.ElementAt(persister.Get<int>("EndPin"));
        }
    }
}