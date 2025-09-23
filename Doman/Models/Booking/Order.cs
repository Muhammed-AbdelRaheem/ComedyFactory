//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Reflection.PortableExecutable;

//using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;

//namespace Domain.Models;

//public class Order : BaseEntity.BaseEntity
//    {

//    public int CartId { get; set; }

//    public int? TrainerId { get; set; }
//    public int? TrainerPackageId { get; set; }
//    public int? Sessions { get; set; }
    
//    public int TournamentId { get; set; }
    
//    public int? EventId { get; set; }
    
//    public int? SubEventId { get; set; }

//    public string FullName { get; set; }

//    public string? TournamentName { get; set; }
//    public string? TournamentType { get; set; }

//    public string? PackageName { get; set; }
//    public string? TrainerName { get; set; }
    
//    public string UserId { get; set; }

//    public DateTime? Date { get; set; }

//    public TimeSpan? Time { get; set; }
    
//    [DefaultValue(0)]
//    public decimal Tax { get; set; }

//    [DefaultValue(0)]
//    [Display(Name = "Sub Total")]
//    public decimal SubTotal { get; set; }

//    [DefaultValue(0)]
//    public decimal Total { get; set; }

//    [DefaultValue(false)]
//    public bool PaymentSuccess { get; set; }
    
//    public string? PaymentNote { get; set; }
    
//    public decimal? RefundAmount { get; set; }

//    [Display(Name = "Discount")]
//    [DefaultValue(0)]
//    public decimal Discount { get; set; }

//    [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
//    public string? IpAddress { get; set; }

//    [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
//    public string? IpCountry { get; set; }

//    [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
//    public string? IpCity { get; set; }

//    [MaxLength(255, ErrorMessage = "Maximum characters is 255 character")]
//    public string? IpLocation { get; set; }
    
//    public string? TransactionId { get; set; }

//    [Display(Name = "Cart Type")]
//    public CartType CartType { get; set; }

//    [Display(Name = "Payment Method")]
//    public PaymentMethod PaymentMethod { get; set; }
    
//    //[Display(Name = "Payment Status")]
//    //public PaymentStatus PaymentStatus { get; set; }

//    [Display(Name = "Tournament")]
//    public Tournament? Tournament { get; set; }
    
//    public string? Language { get; set; }
    
//    [Display(Name = "Order Canceled")]
//    public bool OrderCanceled { get; set; }
    
    
//    [Display(Name = "Order Refund")]
//    public bool OrderRefund { get; set; }
    
//    public ApplicationUser? User { get; set; }
//    public UserBooking? UserBooking { get; set; }
//    public RefundOrder? RefundOrder { get; set; }
//}



//public class OrderFilterVM {
//    public int? OrderId { get; set; }
//    public string?Email { get; set; }
//    public DateTime? Date { get; set; }
//    public TimeSpan? Time { get; set; }
//    //public PaymentStatus? Status { get; set; }
//    public PaymentMethod? Method { get; set; }
//    public CartType? Type { get; set; }
//}

//public class RefundOrder : BaseEntity.BaseEntity {

//    public int OrderId { get; set; }
    
//    [Display(Name = "Refund Reason")]
//    [UIHint("Textarea")]
//    public string RefundReason { get; set; }
//    [Display(Name = "Partial")]
//    public bool IsPartial { get; set; }
//    //[RequiredIf("IsPartial == true", ErrorMessage = "Please add refund amount")]
//    public double? Amount { get; set; }

//    public Order? Order { get; set; }
//}

//public class RefundOrderVM {

//    public int Id { get; set; }
    
//    [Display(Name = "Refund Reason")]
//    [UIHint("Textarea")]
//    public string RefundReason { get; set; }
//    [Display(Name = "Partial")]
//    public bool IsPartial { get; set; }
//    //[RequiredIf("IsPartial == true", ErrorMessage = "Please add refund amount")]
//    public double? Amount { get; set; }
//}

//public class OrderInfoVM {

//    public int Id { get; set; }
//    public CartType CartType { get; set; }

//    public int? TrainerId { get; set; }
//    public int? TrainerPackageId { get; set; }
//    public int? CourtId { get; set; }

//    public int? EventId { get; set; }

//    public int? SubEventId { get; set; }


//}
//public class OrderTableVM {

//    [SearchableInt]
//    [Sortable(Default = false)]
//    public int Id { get; set; }

//    [SearchableString]
//    [Sortable]
//    [Display(Name = "Payment Status")]
//    public string PaymentStatus { get; set; }

//    [SearchableString]
//    [Sortable]
//    [Display(Name = "Payment Method")]
//    public string PaymentMethod { get; set; }
    
//    [SearchableString]
//    [Sortable]
//    public bool PaymentSuccess { get; set; }

//    [SearchableString]
//    [Sortable]
//    [Display(Name = "Booking Type")]
//    public CartType BookingType { get; set; }

//    [SearchableString]
//    [Sortable]
//    [Display(Name = "IpAddress")]
//    public string? IpAddress { get; set; }

//    [SearchableString]
//    [Sortable]
//    [Display(Name = "IpCountry")]
//    public string? IpCountry { get; set; }

//    [SearchableString]
//    [Sortable]
//    [Display(Name = "IpCity")]
//    public string? IpCity { get; set; }

//    [SearchableString]
//    [Sortable]
//    [Display(Name = "IpLocation")]
//    public string? IpLocation { get; set; }

//    [SearchableString]
//    [Sortable]
//    public decimal Tax { get; set; }
    
//    [SearchableString]
//    [Sortable]
//    [Display(Name = "Sub Total")]
//    public decimal SubTotal { get; set; }
    
//    [SearchableString]
//    [Sortable]
//    public decimal Total { get; set; }

//    [SearchableString]
//    [Sortable]
//    public string? TransactionId { get; set; }

//    [SearchableString]
//    [Sortable]
//    public string? PaymentNote { get; set; }
    
//    [SearchableString]
//    [Sortable]
//    public bool OrderCanceled { get; set; }

//    [SearchableString]
//    [Sortable]
//    public int? EventId { get; set; }
    
//    [SearchableString]
//    [Sortable]
//    public int? SubEventId { get; set; }

//    [SearchableString]
//    [Sortable]
//    public DateTime Date { get; set; }

//    [SearchableString]
//    [Sortable]
//    public string? Time { get; set; }

//    [SearchableString]
//    [Sortable]
//    public string User { get; set; }
    
//    [SearchableString]
//    [Sortable]
//    public string? TournamentName { get; set; }
    
//    [SearchableString]
//    [Sortable]
//    public string? TournamentType { get; set; }

//    [Display(Name = "Created Date")]
//    [SearchableString]
//    [Sortable]
//    public DateTime CreatedOnUtc { get; set; }
//}