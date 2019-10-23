using Microsoft.Graph;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TesteRequisicaoHttp
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        //static async Task Main(string[] args)
        //{
        //    try
        //    {
        //        HttpResponseMessage response = await client.GetAsync("");


        //        response.EnsureSuccessStatusCode();
        //        string responseBody = await response.Content.ReadAsStringAsync();

        //        Console.WriteLine(responseBody);
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        Console.WriteLine("\nException Caught!");
        //        Console.WriteLine("Message : {0}", e.Message);
        //    }
        //}

        public static void Main()
        {
            WebRequest request = WebRequest.Create("");

            request.Method = "POST";

            string postData = "";

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);

            //Close the Stream object
            dataStream.Close();

            WebResponse response = request.GetResponse();

            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server.  
            // The using block ensures the stream is automatically closed.
            using (dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);

                //Read the content
                string responseFromServer = reader.ReadToEnd();

                Console.WriteLine(responseFromServer);
            }
            response.Close();

        }

        //public static void EnviaRequisicaoPOST()
        //{
        //    string dadosPost = "";

        //    var dados = Encoding.UTF8.GetBytes(dadosPost);

        //    var requisicaoWeb = WebRequest.CreateHttp("http://teste.com.br");

        //    requisicaoWeb.Method = "POST";
        //    requisicaoWeb.ContentType = "application/x-www-form-urlencoded";
        //    requisicaoWeb.ContentLength = dados.Length;
        //    requisicaoWeb.UserAgent = "RequisicaoWebDemo";


        //    using (var stream = requisicaoWeb.GetRequestStream())
        //    {
        //        stream.Write(dados, 0, dados.Length);
        //        stream.Close();
        //    }

        //    using (var resposta = requisicaoWeb.GetResponse())
        //    {
        //        var streamDados = resposta.GetResponseStream();
        //        StreamReader reader = new StreamReader(streamDados);
        //        object objResponse = reader.ReadToEnd();

        //        var post = JsonConvert.DeserializeObject<Post>(objResponse.ToString());

        //        Console.WriteLine(post.Id + " " + " " + post.Body);
        //        streamDados.Close();
        //        resposta.Close();
        //    }
        //    Console.ReadLine();
        //}
    }
}