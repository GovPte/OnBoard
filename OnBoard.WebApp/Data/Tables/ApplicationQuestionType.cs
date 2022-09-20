using System.ComponentModel.DataAnnotations;

namespace OnBoard.WebApp.Data.Tables
{
    public class ApplicationQuestionType
    {
        [Required]
        public int ApplicationQuestionTypeID { get; set; }
        [Required]
        public string ApplicationQuestionTypeName { get; set; }
        public string ApplicationQuestionTypeDescription { get; set; }
    }
}