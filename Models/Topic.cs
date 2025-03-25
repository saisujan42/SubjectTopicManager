using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SubjectTopicsApp.Models
{
    public class Topic
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<SubTopic> SubTopics { get; set; } = new List<SubTopic>();
    }
}
