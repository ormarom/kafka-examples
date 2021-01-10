using Confluent.Kafka;
using System;

namespace SimpleConsumer
{
    class Program
    {
		static void Main(string[] args)
		{
			var props = new ConsumerConfig
			{
				BootstrapServers = "localhost:9092",
				GroupId = "SimpleConsumerGroup",
				ClientId = $"{Environment.MachineName}",
			};
			using (var consumer = new ConsumerBuilder<Ignore, string>(props).Build())
			{
				consumer.Subscribe("c123-topic");
				while (true)
				{
                    ConsumeResult<Ignore, string> record = consumer.Consume(TimeSpan.FromMilliseconds(100)); //in dotnet consume is one by one 
					if (record == null) continue;
					Console.WriteLine($"partition = {record.Partition} offset = {record.Offset}, key = {record.Message.Key}, value = {record.Message.Value}");
				}
			}
		}
    }
}

