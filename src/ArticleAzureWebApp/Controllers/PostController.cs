using ArticleWebApp.Data;
using ArticleWebApp.Dto;
using ArticleWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticleWebApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly ArticleContext _db;

        public PostController(ILogger<PostController> logger, ArticleContext db)
        {
            _logger = logger;
            _db = db;
        }

        // GET: PostController
        public async Task<IActionResult> Index()
        {
            var posts = await _db.Posts.Select(post => Mapper.MapToPostResponseDto(post)).ToListAsync();
            return View(posts);
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostRequestDto postRequest)
        {
            try
            {
                
                var post = new Post()
                {
                    Title = postRequest.Title,
                    Author = postRequest.Author,
                    Body = postRequest.Body
                };

                await _db.Posts.AddAsync(post);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var post = await _db.Posts.FirstOrDefaultAsync(post => post.Id == id);
            var postToEdit = Mapper.MapToPostResponseDto(post);
            return View(postToEdit);
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PostRequestDto postRequest)
        {
            try
            {
               await _db.Posts.Where(post => post.Id == id).ExecuteUpdateAsync(s => s
                    .SetProperty(post => post.Title, postRequest.Title)
                    .SetProperty(post => post.Author, postRequest.Author)
                    .SetProperty(post => post.Body, postRequest.Body));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
