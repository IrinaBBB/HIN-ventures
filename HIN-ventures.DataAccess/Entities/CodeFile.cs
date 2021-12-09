using System.ComponentModel.DataAnnotations.Schema;

namespace HIN_ventures.DataAccess.Entities
{
    public class CodeFile
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public string CodeFileUrl { get; set; }

        //disse er nye TODO
        public string FileName { get; set; }
        public string StoredFileName { get; set; }
        public bool Uploaded { get; set; }
        public int ErrorCode { get; set; }



        [ForeignKey("AssignmentId")] 
        public virtual Assignment Assignment { get; set; }
    }
}