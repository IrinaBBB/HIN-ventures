namespace HIN_ventures.Models
{
    public class CodeFileDto
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public string CodeFileUrl { get; set; } //mulig denne fjernes
        public string StoredFileName { get; set; }
        public bool Uploaded { get; set; }
        public string FileName { get; set; }
        public int ErrorCode { get; set; }
    }
}