using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamTreeHouses.Models
{
    public class ComicBook
    {
        /*** Public Part ***/
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool Favorite { get; set; }
        [Required]
        public int IssueNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string SeriesTitle { get; set; }
        public string DescriptionHtml { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
        //
        [NotMapped]
        public string DisplayText
        {
            get { return string.Format("{0} #{1}", this.SeriesTitle, this.IssueNumber); }
        }
        [NotMapped]
        public string ConvertImageFileName
        {
            get { return string.Format("{0}-{1}.jpg", this.SeriesTitle.Replace(" ", "-"), this.IssueNumber); }
        }

        public ComicBook()
        {
            //this.Artists = new HashSet<Artist>();
        }
    }
}