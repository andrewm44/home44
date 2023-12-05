
using MQTTnet;
using MQTTnet.Client;

namespace Home44.Services
{
    public class BroadlinkService : IBroadlinkService
    {
        public async Task SendButtonCommand()
        {
            string extractorLight = "";

            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithTcpServer("192.168.1.196")
                    .Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                var applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic("mqtttest")
                    .WithPayload("yoinks")
                    .Build();

                await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

                await mqttClient.DisconnectAsync();

               // Console.WriteLine("MQTT application message is published.");
            }

        }

    }
}
