using System;
using System.ComponentModel.DataAnnotations;

namespace OnBoard.WebApp.Data.Tables
{
    public class CommissionMember
    {
        [Key][Required]
        public int CommissionMemberID { get; set; }
        public int CommissionID { get; set; } //FK
        public Commission Commission { get; set; } //FK
        [Display(Name = "Title")]
        public string CommissionTitle { get; set; } //Chair, Vice Chair, Secretary, Liaison, etc.
        [MaxLength(450)]
        public string AspNetUserId { get; set; } //FK to AspNetUsers.Id
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; } //Date of actual appointment/election
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; } //Last day serving
        [Display(Name = "Term Start Date")]
        public DateTime? TermStartDate { get; set; } //Date of the beginning of the term
        [Display(Name = "Term End Date")]
        public DateTime? TermEndDate { get; set; } //Date of the end of the term
        [Display(Name = "Slot")]
        public int CommissionMemberSlot { get; set; } //If there are 7 spots on a Commission, this would be a number 1-7
        [Display(Name = "Sort Order")]
        public int? CommissionMemberSort { get; set; } //Use this number to sort the members on the page
        [Display(Name = "Appointment Notes")]
        public string CommissionMemberAppointmentNotes { get; set; } //Use this field to store notes regarding a member's appointment
        [Display(Name = "Appointment Minutes")]
        public string CommissionMemberAppointmentMinutesLink { get; set; } //Use this field to store a link to the minutes of this member's appointment
        [Display(Name = "Resignation/Removal Notes")]
        public string CommissionMemberResignationRemovalNotes { get; set; } //Use this field to store notes of the resignation or removal of this member
        [Display(Name = "Resignation/Removal Minutes")]
        public string CommissionMemberResignationRemovalMinutesLink { get; set; } //Use this field to store a link to the minutes of the resignation or removal of this member
    }
}