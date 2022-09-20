using System.ComponentModel.DataAnnotations;

namespace OnBoard.WebApp.Data.Tables
{
    public class QuestionAnswer
    {
        [Key][Required]
        public int QuestionAnswerID { get; set; }
        [Required] //Causing lots of issues I think
        public string QuestionAnswerText { get; set; }
        public string QuestionAnswerNotes { get; set; }
        [Required]
        public int ApplicationQuestionID { get; set; }
        public ApplicationQuestion ApplicationQuestion { get; set; }
        public int ApplicationID { get; set; }
        public Application Application { get; set; }
    }
}