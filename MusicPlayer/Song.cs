using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class Song
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(30)]
        public string Duration { get; set; }
        [StringLength(30)]
        public byte[] Content { get; set; }
        [StringLength(30)]
        public byte[] Image { get; set; }
        
    }
}
