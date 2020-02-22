using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class EventHub
{
    public delegate void PickupDelegate(Character character, Toteable toteable);
    public static event PickupDelegate PickupEvent;
    public static void PickupBroadcast(Character character, Toteable toteable)
    {
        PickupEvent?.Invoke(character, toteable);
    }
}
