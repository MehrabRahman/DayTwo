using System.Net;
using System.Text;

namespace DayTwo
{
    class Server
    {
        HttpListener listener;

        public Server()
        {
            listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
        }

        public void Start()
        {
            Console.WriteLine("Listening on port 8080...");

            while (true)
            {
                var ctx = listener.GetContext();
                var resp = ctx.Response;

                Console.WriteLine("Received request.");

                resp.Headers.Set("Content-Type", "text/html");
                var text = "<h1>Hello there!</h1>";
                var buffer = Encoding.UTF8.GetBytes(text);
                resp.ContentLength64 = buffer.Length;
                var output = resp.OutputStream;
                output.Write(buffer, 0, buffer.Length);

                resp.StatusCode = (int) HttpStatusCode.OK;
                resp.StatusDescription = "Success";
            }
        }
    }
}
