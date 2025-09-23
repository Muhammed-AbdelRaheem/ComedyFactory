using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Block : BaseEntity.BaseEntity
    {
        [Required(ErrorMessage = "This {0} field is required")]
        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        [Display(Name = "Arabic Name")]
        public string ArName { get; set; }

        [Required(ErrorMessage = "This {0} field is required")]
        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        [Display(Name = "English Name")]
        public string EnName { get; set; }

        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        [Display(Name = "Arabic Line1")]
        public string? ArLine1 { get; set; }

        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        [Display(Name = "English Line1")]
        public string? EnLine1 { get; set; }

        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        [Display(Name = "Arabic Line2")]
        public string? ArLine2 { get; set; }

        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        [Display(Name = "English Line2")]
        public string? EnLine2 { get; set; }


        [Display(Name = "Arabic Content")]
        [UIHint("Editor")]
        public string? ArContent { get; set; }

        [Display(Name = "English Content")]
        [UIHint("Editor")]
        public string? EnContent { get; set; }


        [Display(Name = "Arabic Picture")]
        [UIHint("PicUploader")]
        public string? ArPicture { get; set; }

        [Display(Name = "English Picture")]
        [UIHint("PicUploader")]
        public string? EnPicture { get; set; }

        [Display(Name = "Video URL")]
        [UIHint("Video")]
        public string? VideoURL { get; set; }


        [Display(Name = "Address")]
        [UIHint("Tag")]
        public string? Address { get; set; }


        [Display(Name = "Mobile")]
        [UIHint("Tag")]
        public string? Mobile { get; set; }

        [Display(Name = "Email")]
        [UIHint("Tag")]
        public string? Email { get; set; }

        [Display(Name = "Fax")]
        [UIHint("Tag")]
        public string? Fax { get; set; }

        [Display(Name = "Location")]
        [UIHint("Iframe")]
        public string? Location { get; set; }

        public BlockType BlockType { get; set; }
        [Display(Name = "Arabic Description")]
        [UIHint("Editor")]
        public string? ArDescription { get; set; }
        [Display(Name = "English Description")]
        [UIHint("Editor")]
        public string? EnDescription { get; set; }

        [DisplayName("Ar Youtube Video")]
        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        public string? ArYoutubeVideo { get; set; }

        [DisplayName("En Youtube Video")]
        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        public string? EnYoutubeVideo { get; set; }


    }

    public enum BlockType
    {
        [Display(Name = "Contact Us")]
        Contactus = 0,
        [Display(Name = "About Us")]
        AboutUs = 1,
        [Display(Name = "Privacy")]
        Privacy = 2,
        [Display(Name = "Terms")]
        Terms = 3,
        [Display(Name = "Banners Details")]
        BannerSection = 4,
        [Display(Name = "Feedback Admin")]
        FeedbackEmailToAdmin,
        [Display(Name = "Feedback User")]
        FeedbackEmailToUser,
        [Display(Name = "Forgot Password")]
        ForgotPassword,
        [Display(Name = "Notify Admin Subscription")]
        NotifyAdminForSubscription,
        [Display(Name = "Notify User Subscription")]
        NotifyUserForSubscription,
        [Display(Name = "First Approve")]
        FirstApprovedEmailTemplate,
        [Display(Name = "First Security Approval")]
        FirstSecurityApprovalEmailTemplate,
        [Display(Name = "First Medical Approval")]
        FirstMedicalApprovalEmailTemplate,
        [Display(Name = "Complete Passport Document")]
        CompletePassportDocumentEmailTemplate,
        [Display(Name = "Book Ticket")]
        BookTicket,
        [Display(Name = "Home Page")]
        HomePage,
        [Display(Name = "Sign Up Banner")]
        SignUpBanner,
        [Display(Name = "Thanks Email")]
        ThanksEmail,
    }


    public class BlockVM
    {
        [JsonProperty(PropertyName = "title")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string? Content { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string? Picture { get; set; }

        [JsonProperty(PropertyName = "type")]
        public BlockType BlockType { get; set; }

    }


    #region Web Models

    public class AboutUsPage
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Content { get; set; }
        public string? Picture { get; set; }

    }

    public class AboutUsLight
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Picture { get; set; }
        public string? VideoURL { get; set; }

    }

    public class BlockLightVM
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? name { get; set; }
        public string? content { get; set; }
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Content { get; set; }

    }

    public class ContactInfoVM
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Location { get; set; }
        public string? Mobile { get; set; }


    }
    public class FeedbackVM
    {

        [Required(ErrorMessage = "This {0} field is required")]
        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This {0} field is required")]
        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Enter a valid e-mail address")]
        public string Email { get; set; }

        [Display(Name = "Mobile")]
        [Required(ErrorMessage = "This {0} field is required")]
        [RegularExpression(@"^(\+?\d{11,17})$", ErrorMessage = "MobileNumberRequired")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "This {0} field is required")]
        [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
        [Display(Name = "Message")]
        public string Message { get; set; }


    }

    #endregion
}
