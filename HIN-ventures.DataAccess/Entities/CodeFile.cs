using System.ComponentModel.DataAnnotations.Schema;

namespace HIN_ventures.DataAccess.Entities
{
    public class CodeFile
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public string CodeFileUrl { get; set; }
        [ForeignKey("AssignmentId")] public virtual Assignment Assignment { get; set; }
    }
}