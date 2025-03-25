using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubjectTopicsApp.Data;
using SubjectTopicsApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectTopicsApp.Controllers
{
    public class TopicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TopicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var topics = await _context.Topics.Include(t => t.SubTopics).ToListAsync();
            return View(topics);
        }

        [HttpPost]
        public async Task<IActionResult> AddTopic(string name)
        {
            var topic = new Topic { Name = name };
            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddSubTopic(int topicId, string name)
        {
            var subTopic = new SubTopic { Name = name, TopicId = topicId };
            _context.SubTopics.Add(subTopic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> EditTopic(int id, string name)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null) return NotFound();
            topic.Name = name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> EditSubTopic(int id, string name)
        {
            var subTopic = await _context.SubTopics.FindAsync(id);
            if (subTopic == null) return NotFound();
            subTopic.Name = name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null) return NotFound();
            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSubTopic(int id)
        {
            var subTopic = await _context.SubTopics.FindAsync(id);
            if (subTopic == null) return NotFound();
            _context.SubTopics.Remove(subTopic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
