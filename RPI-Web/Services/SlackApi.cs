using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace RPI_Web.Services;

public class SlackApi
{
    public class ChatPostMessage
    {
        public string channel { get; set; }
        public string text { get; set; }
    }

    private const string ChatPostMessageUrl = "https://slack.com/api/chat.postMessage";
    public static string Token { get; set; } = null!;

    public static async Task PostAsync(ChatPostMessage data)
    {
        if (string.IsNullOrEmpty(Token))
        {
            throw new ArgumentNullException(nameof(data));
        }

        HttpClient client = new HttpClient();

        //授權
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer",
                Token);
        //轉換
        string content = JsonConvert.SerializeObject(data);
        byte[] buffer = Encoding.UTF8.GetBytes(content);
        ByteArrayContent byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await client.PostAsync(ChatPostMessageUrl, byteContent).ConfigureAwait(false);
        await response.Content.ReadAsStringAsync();
    }
}