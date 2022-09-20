using System.ComponentModel.DataAnnotations;

namespace OnBoard.WebApp.Data.Tables
{
    public class ApplicationQuestion
    {
        [Key][Required]
        public int ApplicationQuestionID { get; set; }
        [Required]
        public string ApplicationQuestionText { get; set; }
        public string ApplicationQuestionNotes { get; set; }
        //public List<QuestionAnswer> QuestionAnswers { get; set; } https://docs.microsoft.com/en-us/ef/core/modeling/relationships#other-relationship-patterns
        public int ApplicationQuestionTypeID { get; set; }
        public ApplicationQuestionType ApplicationQuestionType { get; set; }
    }
}