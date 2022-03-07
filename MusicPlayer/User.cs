using System.ComponentModel.DataAnnotations;

namespace DomainModel;

public class User
{
    public int Id { get; set; }
        [StringLength(30)]
    public string FirstName { get; set; }
        [StringLength(30)]
    public string LastName { get; set; }
        [StringLength(30)]
    public string Country { get; set; }
        [StringLength(30)]
    public virtual Account Account { get; set; }
    public virtual IList<Song> Songs { get; set; }
}
