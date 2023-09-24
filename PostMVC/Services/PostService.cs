using PostMVC.Models;

namespace PostMVC.Services
{
    public class PostService
    {
        private readonly HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Post>> GetPosts()
        {
            var post = await _httpClient.GetFromJsonAsync<List<Post>>("api/posts");

            return post;
        }

        public async Task<Post> CreatePost(Post post)
        {
            var response = await _httpClient.PostAsJsonAsync("api/posts", post);
            response.EnsureSuccessStatusCode();
            var postCreated = await response.Content.ReadFromJsonAsync<Post>();
            return postCreated;
        }

        public async Task<Post> UpdatePost(Post post, int id)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/posts/{id}", post);
            response.EnsureSuccessStatusCode();
            var updatedPost = await response.Content.ReadFromJsonAsync<Post>();
            return updatedPost;
        }

        public async Task<Post> GetPostById(int id)
        {
            var post = await _httpClient.GetFromJsonAsync<Post>($"api/posts/{id}");
            return post;
        }

        public async Task<bool> DeletePost(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/posts/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}