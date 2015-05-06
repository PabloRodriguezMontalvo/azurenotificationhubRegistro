using Microsoft.WindowsAzure.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Networking.PushNotifications;

namespace Notificaciones
{
    public sealed class Notificaciones
    {

       


        public IAsyncOperation<String> SubirRegistroHub(int id)
        {


           

            return  InitNotificationsAsync(id).AsAsyncOperation();
        }

        private async Task<String> InitNotificationsAsync(int idUsuario)
        {
            var channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
            var t=new List<String>() {"Usuario:"+idUsuario};
            var hub = new NotificationHub("testnh",
                "Endpoint=sb://testnh2-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=EkjSaaE0iRff2u3YIkis3wpv1FvePQDRw4LbqEI3E1E=");
            var result = await hub.RegisterNativeAsync(channel.Uri,t);

            return result.RegistrationId;
            // Displays the registration ID so you know it was successful
           

        }
    }
}
