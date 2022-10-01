/// —————————————————————————————————————————————
//? 
//!? 📜 HTTPServer.cs
//!? 🖋️ XEROling 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies: No special dependencies
//? 
/// —————————————————————————————————————————————


using System;
using System.Net;
using System.Text;
using System.Threading;

namespace Assets.Scripts.Lib.Network {
    /// <summary> Listen to a URI prefix and respond with a string by running <see cref="ResponseMethod"/> </summary>
    public class HTTPServer {
        #region Shortcuts

        public static bool IsSupported => HttpListener.IsSupported;
        public bool IsListening => Listener.IsListening;
        public HttpListenerPrefixCollection Prefixes => Listener.Prefixes;

        #endregion
        #region Methods

        /// <summary> Close the <see cref="Listener"/> 
        /// <br/>
        ///  • Note: <paramref name="confirm"/> value must be "confirm" to proceed </summary>
        /// <param name="confirm"></param>
        /// <returns> true if <see cref="HttpListener.Close"/> was called </returns>
        public bool Kill(string confirm) {
            if (!IsListening) return true;
            if (confirm != "confirm") return false;
            Listener.Close();
            return true;
        }
        public void Pause() {
            if (!IsListening) return;
            Listener.Stop();
        }
        public void Start() {
            ThreadPool.QueueUserWorkItem(obj => {
                Console.WriteLine("Starting server at...");
                try {
                    while (IsListening) {
                        ThreadPool.QueueUserWorkItem(ctx => {
                            var context = (HttpListenerContext)ctx;
                            if (context == null) return;
                            try {
                                var response = ResponseMethod(context.Request);
                                var responseBuffer = Encoding.UTF8.GetBytes(response);
                                context.Response.ContentLength64 = responseBuffer.Length;
                                context.Response.OutputStream.Write(responseBuffer, 0, responseBuffer.Length);
                            } catch { } finally {
                                //? Close the stream
                                if (context != null) context.Response.OutputStream.Close();
                            }
                        }, Listener.GetContext());
                    }
                } catch (Exception ex) {
                    Console.WriteLine(
                        $"Server has encountered an error!"
                        + Environment.NewLine + Environment.NewLine
                        + ex);
                }
            });
        }

        #endregion


        protected HttpListener Listener { get; }
        protected Func<HttpListenerRequest, string> ResponseMethod { get; }

        public HTTPServer(Func<HttpListenerRequest, string> method, params string[] uriPrefixes) {
            if (!IsSupported)
                throw new NotSupportedException("System not supported. HTTPServer requires Windows XP SP2, Server 2003 or later.");
            if (uriPrefixes == null || uriPrefixes.Length == 0)
                throw new ArgumentException("At least 1 URI prefix is required");

            ResponseMethod = method ?? throw new ArgumentException("Response method is required");
            Listener = new();

            foreach (string uriPrefix in uriPrefixes)
                Listener.Prefixes.Add(uriPrefix);
            Listener.Start();
        }

        public HTTPServer CreateAndStart(Func<HttpListenerRequest, string> method, params string[] uriPrefixes) {
            HTTPServer server = new(method, uriPrefixes);
            server.Start();
            return server;
        }
    }
}
