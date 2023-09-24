using Microsoft.AspNetCore.Mvc;
using PostMVC.Models;
using PostMVC.Services;

namespace PostMVC.Controllers
{
    public class PostController : Controller
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }

        // GET: PostController
        public async Task<ActionResult> Index()
        {
            var post = await _postService.GetPosts();
            return View(post);
        }

        // GET: PostController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var Post = await _postService.GetPostById(id);
            return View(Post);
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Post post)
        {
            var model = await _postService.CreatePost(post);

            return RedirectToAction(nameof(Index));
        }

        // GET: PostController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var getPost = await _postService.GetPostById(id);
            return View(getPost);
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Post updatedpost)
        {
            if (updatedpost == null)
            {
                return View(updatedpost);
            }
            var post = await _postService.UpdatePost(updatedpost, id);
            return RedirectToAction(nameof(Index));
        }

        // GET: PostController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var getPost = await _postService.GetPostById(id);
            return View(getPost);
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletePost(int id)
        {
            await _postService.DeletePost(id);
            return RedirectToAction(nameof(Index));
        }
    }
}