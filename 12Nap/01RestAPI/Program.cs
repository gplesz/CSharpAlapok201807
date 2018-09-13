using RestSharp;
using System;
using System.Collections.Generic;

namespace _01RestAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            //A kiszolgáló szerver elérése
            var baseUri = "http://jsonplaceholder.typicode.com";

            //kell egy kliens, ami a hívásokat intézi
            var client = new RestClient(baseUri);

            var request = new RestRequest("/posts/{id}", Method.GET);
            request.AddUrlSegment("id", 1);

            //paramétereket így lehet megadni: ?name=value
            //request.AddParameter()

            var post = client.Execute<Post>(request);

            Console.WriteLine($"userId: {post.Data.userId}, id: {post.Data.id}, title: {post.Data.title}, body: {post.Data.body}");


            request = new RestRequest("/posts", Method.GET);

            var posts = client.Execute<List<Post>>(request);

            Console.WriteLine($"ListCount: {posts.Data.Count}");

            Console.ReadLine();
        }
    }

    //ezt a json-t

    //{
    //"userId": 1,
    //"id": 1,
    //"title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
    //"body": "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
    //}

    //ide fogjuk deserializálni

    public class Post
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }

}
