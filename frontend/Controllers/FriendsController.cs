using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class FriendsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://zany-winner-v6v4wv7g9p79fpxjw-8080.app.github.dev/api/friends"; // Update with your API URL

        public FriendsController(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        // GET: Friend
        public async Task<IActionResult> Index()
        {
            var friends = await _httpClient.GetFromJsonAsync<List<FriendViewModel>>(_apiBaseUrl);
            ViewBag.Message = TempData["Message"];
            return View(friends);
        }

        // GET: Friend/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Friend/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Phone,DoB")] FriendViewModel friend)
        {
            if (ModelState.IsValid)
            {
                await _httpClient.PostAsJsonAsync(_apiBaseUrl, friend);
                TempData["Message"] = "Friend Created Successfully.!";
                return RedirectToAction(nameof(Index));
            }
            return View(friend);
        }

        // GET: Friend/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = await _httpClient.GetFromJsonAsync<FriendViewModel>($"{_apiBaseUrl}/{id}");
            if (friend == null)
            {
                return NotFound();
            }
            return View(friend);
        }

        // POST: Friend/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Phone,DoB")] FriendViewModel friend)
        {
            if (id != friend.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _httpClient.PutAsJsonAsync($"{_apiBaseUrl}/{id}", friend);
                 TempData["Message"] = "Friend Updated Successfully.!";
                return RedirectToAction(nameof(Index));
            }
            return View(friend);
        }

        // GET: Friend/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = await _httpClient.GetFromJsonAsync<FriendViewModel>($"{_apiBaseUrl}/{id}");
            if (friend == null)
            {
                return NotFound();
            }

            return View(friend);
        }

        // POST: Friend/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
             TempData["Message"] = "Friend Deleted Successfully.!";
            return RedirectToAction(nameof(Index));
        }
    }
    
}
