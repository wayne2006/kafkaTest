using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kafkaTest
{
    public partial class Form1 : Form
    {
        IProducer<string, string> producer;
        IConsumer<Ignore, string> consumer;
        CancellationTokenSource cts;
        bool stopConsume = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbx_brokerList.Text = "172.16.19.197:9092,172.16.19.197:9093";
            tbx_topicName.Text = "test";
            tbx_Msg.Text = "测试消息";

            tbx_brokerListConsumer.Text = "172.16.19.197:9092,172.16.19.197:9093";
            tbx_topicNameConsumer.Text = "test";
        }
        private void btn_SetProducer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_brokerList.Text.Trim()))
            {
                MessageBox.Show("请填好brokerList");
                return;
            }
            if (string.IsNullOrEmpty(tbx_topicName.Text.Trim()))
            {
                MessageBox.Show("请填好topicName");
                return;
            }

            var config = new ProducerConfig { BootstrapServers = tbx_brokerList.Text.Trim() };
            producer = new ProducerBuilder<string, string>(config).Build();
            rtbx_log.AppendText("\n-----------------------------------------------------------------------\n");
            rtbx_log.AppendText($"Producer {producer.Name} producing on topic {tbx_topicName.Text.Trim()}.\n");
            rtbx_log.AppendText("-----------------------------------------------------------------------\n");
        }

        private async void btn_Send_Click(object sender, EventArgs e)
        {
            string val = tbx_Msg.Text.Trim();

            try
            {
                // Note: Awaiting the asynchronous produce request below prevents flow of execution
                // from proceeding until the acknowledgement from the broker is received (at the 
                // expense of low throughput).
                var deliveryReport = await producer.ProduceAsync(
                    tbx_topicName.Text.Trim(), new Message<string, string> { Key = null, Value = val });

                rtbx_log.AppendText($"delivered to: {deliveryReport.TopicPartitionOffset}\n");
                tbx_Msg.Text = "";
            }
            catch (ProduceException<string, string> ex)
            {
                rtbx_log.AppendText($"failed to deliver message: {ex.Message} [{ex.Error.Code}]\n");
            }
        }

        private void rtbx_log_TextChanged(object sender, EventArgs e)
        {
            LimitLIne(rtbx_log, 100);
            rtbx_log.SelectionStart = rtbx_log.Text.Length;
            rtbx_log.SelectionLength = 0;
            rtbx_log.Focus();
        }


        private void btn_SetConsumer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_brokerListConsumer.Text.Trim()))
            {
                MessageBox.Show("请填好消费者brokerList");
                return;
            }
            if (string.IsNullOrEmpty(tbx_topicNameConsumer.Text.Trim()))
            {
                MessageBox.Show("请填好消费者topicName");
                return;
            }

            string brokerList = tbx_brokerListConsumer.Text.Trim();
            string topics = tbx_topicNameConsumer.Text.Trim();

            var config = new ConsumerConfig
            {
                BootstrapServers = brokerList,
                GroupId = "test-consumer",
                EnableAutoCommit = true,
                StatisticsIntervalMs = 5000,
                SessionTimeoutMs = 6000,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnablePartitionEof = true
            };

            consumer = new ConsumerBuilder<Ignore, string>(config)
                // Note: All handlers are called on the main .Consume thread.
                .SetErrorHandler((_, e) => rtbx_logConsumer.AppendText($"Error: {e.Reason}\n"))
                //.SetStatisticsHandler((_, json) => rtbx_logConsumer.AppendText($"Statistics: {json}\n"))
                .SetPartitionsAssignedHandler((c, partitions) =>
                {
                    rtbx_logConsumer.AppendText($"Assigned partitions: [{string.Join(", ", partitions)}]\n");
                    // possibly manually specify start offsets or override the partition assignment provided by
                    // the consumer group by returning a list of topic/partition/offsets to assign to, e.g.:
                    // 
                    // return partitions.Select(tp => new TopicPartitionOffset(tp, externalOffsets[tp]));
                })
                .SetPartitionsRevokedHandler((c, partitions) =>
                {
                    rtbx_logConsumer.AppendText($"Revoking assignment: [{string.Join(", ", partitions)}]\n");
                })
                .Build();

            consumer.Subscribe(topics);

            btn_SetConsumer.Enabled = false;

            Task.Run(()=> {
                cts = new CancellationTokenSource();
                try
                {
                    while (!stopConsume)
                    {
                        try
                        {
                            var consumeResult = consumer.Consume(cts.Token);

                            if (consumeResult.IsPartitionEOF)
                            {
                                rtbx_logConsumer.AppendText(
                                    $"Reached end of topic {consumeResult.Topic}, partition {consumeResult.Partition}, offset {consumeResult.Offset}.\n");

                                continue;
                            }

                            rtbx_logConsumer.AppendText($"Received message at {consumeResult.TopicPartitionOffset}: {consumeResult.Value}\n");

                            //if (consumeResult.Offset % commitPeriod == 0)
                            //{
                            //    // The Commit method sends a "commit offsets" request to the Kafka
                            //    // cluster and synchronously waits for the response. This is very
                            //    // slow compared to the rate at which the consumer is capable of
                            //    // consuming messages. A high performance application will typically
                            //    // commit offsets relatively infrequently and be designed handle
                            //    // duplicate messages in the event of failure.
                            //    try
                            //    {
                            //        consumer.Commit(consumeResult);
                            //    }
                            //    catch (KafkaException e)
                            //    {
                            //        Console.WriteLine($"Commit error: {e.Error.Reason}");
                            //    }
                            //}
                        }
                        catch (ConsumeException ex)
                        {
                            rtbx_logConsumer.AppendText($"Consume error: {ex.Error.Reason}\n");
                            btn_SetConsumer.Enabled = true;
                        }
                    }
                    rtbx_logConsumer.AppendText("Stop Consume.\n");
                    btn_SetConsumer.Enabled = true;
                }
                catch (OperationCanceledException)
                {
                    rtbx_logConsumer.AppendText("Closing consumer.\n");
                    consumer.Close();
                    btn_SetConsumer.Enabled = true;
                }
                stopConsume = false;
            });

            
        }

        private void rtbx_logConsumer_TextChanged(object sender, EventArgs e)
        {
            LimitLIne(rtbx_logConsumer, 100);
            rtbx_logConsumer.SelectionStart = rtbx_logConsumer.Text.Length;
            rtbx_logConsumer.SelectionLength = 0;
            rtbx_logConsumer.Focus();
        }

        private void LimitLIne(RichTextBox rtbx, int maxLength)
        {
            if (rtbx.Lines.Length > maxLength)
            {
                int moreLines = rtbx.Lines.Length - maxLength;
                string[] lines = rtbx.Lines;
                Array.Copy(lines, moreLines, lines, 0, maxLength);
                Array.Resize(ref lines, maxLength);
                rtbx.Lines = lines;
            }
        }

        private void btn_StopConsume_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            stopConsume = true;
        }
    }
}
