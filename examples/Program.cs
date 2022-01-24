using System;
using request;
namespace requestclient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            HttpProperties http = new HttpProperties()
            {
                dictObject = null,
                methodType = "GET",
                sync = true,
                token = null,
                url = "https://jsonplaceholder.typicode.com/todos/1"
            };
             object s = Http.HttpRequest(http);
            Console.WriteLine(s);

        }
    }
}
