using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;

namespace DISCORD_WEBHOOK_IMAGE_SENDER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sendImg(string url,string filePath)
        {
            HttpClient client = new HttpClient();
            MultipartFormDataContent content = new MultipartFormDataContent();

            var file = File.ReadAllBytes(filePath);
            content.Add(new ByteArrayContent(file, 0, file.Length),Path.GetExtension(filePath),filePath);
            client.PostAsync(url, content).Wait();
            client.Dispose();
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            sendImg("https://ptb.discord.com/api/webhooks/948914126187556875/tnVz99kah00KnSfkn23BrytjG5tPTr2aLcyeJtGZeSMEVpi8LH689zUH6gZMNNYEIMDm",filePath.Text);
        }
    }
}
