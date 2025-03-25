using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubjectTopicsApp.Models
{
    public class SubTopic
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Topic")]
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
