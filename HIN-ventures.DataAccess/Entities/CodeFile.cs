using System.ComponentModel.DataAnnotations.Schema;

namespace HIN_ventures.DataAccess.Entities
{
    public class CodeFile
    {
        [Column("id")] public int Id { get; set; }
        [Column("assignment_id")] public int AssignmentId { get; set; }
        [Column("code_file_url")] public string CodeFileUrl { get; set; }
        [ForeignKey("AssignmentId")] public virtual Assignment Assignment { get; set; }
    }
}