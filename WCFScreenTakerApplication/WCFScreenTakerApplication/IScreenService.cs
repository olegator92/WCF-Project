using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFScreenTakerApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IScreenService" in both code and config file together.
    [ServiceContract]
    public interface IScreenService
    {
        [OperationContract]
        void TakeScreen(Byte[] screen, DateTime time, Int32 mouseX, Int32 mouseY);
    }
}
