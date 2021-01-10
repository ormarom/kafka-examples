using Confluent.Kafka;
using System;
using System.Threading;

namespace SimpleProducer
{
	public class Program
	{
		static void Main(string[] args)
		{
			var props = new ProducerConfig { BootstrapServers = "localhost:9092" };
			using (var producer = new ProducerBuilder<string, string>(props).Build())
			{
				for (int i = 0; i < 1000; i++)
				{
					producer.Produce("c123-topic", new Message<string, string> { Key = i.ToString(), Value = i.ToString() });
					Console.WriteLine("sent message=> " + i);
					Thread.Sleep(10);
				}
			}
			Console.ReadLine();
		}
	}
}
