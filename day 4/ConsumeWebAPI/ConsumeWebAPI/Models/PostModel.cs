namespace ConsumeWebAPI.Models
{
    public class PostModel
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        List<PostModel> postList = new List<PostModel>();

        public  List<PostModel> GetPostData()
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("appliction/json"));
            var call = client.GetAsync(url);
            if (call.Result.IsSuccessStatusCode)
            {
                var data = call.Result.Content.ReadAsAsync<List<PostModel>>();
                data.Wait();
                postList = data.Result;               
            }
            else
            {
                throw new Exception("Cannot get data, please contact admin");
            }
                

            return postList;
        }



    }
}
