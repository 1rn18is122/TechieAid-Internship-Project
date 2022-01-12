using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;




namespace ARS.Models
{
    [Table("TblAdminLogin")]

    public class AdminLogin
    {
        [Key]
        public int AdminId { get; set; }
        [Required(ErrorMessage = "User Name Required")]
        [Display(Name = "User Name")]
        [MinLength(3, ErrorMessage = "Minimum 3 characters required"), MaxLength(10, ErrorMessage = "max length 10 allowed")]

        public string AdName{get;set;}

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Minimum 5 characters required"), MaxLength(10, ErrorMessage = "max length 10 allowed")]
       
        public string Password { get; set; }




    }
    [Table("TblUserAccount")]
    public class UserAccount
    {
        [Key]

        public int UserId { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name required")]
        [MaxLength(20, ErrorMessage = "Max 20 char allowed"), MinLength(5, ErrorMessage = "min 5b char allowed")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name required")]
        [MaxLength(20, ErrorMessage = "Max 20 char allowed"), MinLength(5, ErrorMessage = "min 5b char allowed")]
        public string LastName { get; set; }

        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "Email Id  required")]
        [MaxLength(50, ErrorMessage = "Max 50 char allowed"), MinLength(5, ErrorMessage = "min 5b char allowed")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password required")]
        [MaxLength(20, ErrorMessage = "Max 20 char allowed"), MinLength(5, ErrorMessage = "min 5b char allowed")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not matched")]
        [MaxLength(20, ErrorMessage = "Max 20 char allowed"), MinLength(5, ErrorMessage = "min 5b char allowed")]
        public string CPassword { get; set; }

        [Required(ErrorMessage = "age required")]
        [Range(18, 120, ErrorMessage = "MIN 18 YEARS REQUIRED")]

        public int Age { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone number  required"), RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Phone Number not valid")]
        [StringLength(10)]
        public string Phoneno { get; set; }

        [Display(Name = "NIC Number")]
        [Required(ErrorMessage = "NIC number  required"), RegularExpression(@"^([0-9]{13})$", ErrorMessage = "NIC Number not valid")]
        [StringLength(13)]

        public string NIC { get; set; }

    }
    public class AeroPlaneInfo
    {
        [Key]

        public int Planeid { get; set; }
        [Display(Name = "Aeroplane Name")]
        [Required(ErrorMessage = "Aeroplane name required")]
        [MaxLength(30, ErrorMessage = "Max 30 char allowed"), MinLength(3, ErrorMessage = "min 3 char allowed")]
        public string APlaneName { get; set; }

        [Required(ErrorMessage = "Capacity Req")]
        [Display(Name = "Seating capacity")]

        public int SeatingCapacity { get; set; }
        [Required(ErrorMessage = "Price Required")]

        public float Price { get; set; }



    }
    [Table("TblFlightbook")]
    public class FlightBooking
    {
        [Key]

        public int bid{ get; set; }

        [Required, Display(Name = "Customer Name")]
        public string bCusName { get; set; }
        [Required, Display(Name = "Customer Address")]
        public string bCusAddress { get; set; }
        [Required, Display(Name = "Customer Email")]
        public string bCusEmail { get; set; }
        [Required, Display(Name = "Phone Number")]
        public string bCusPhoneNum { get; set; }
        [Required, Display(Name = "Number Of Seats")]
        public string bCusSeats { get; set; }

        public int ResID { get; set; }

        public virtual TicketReserve_tbl TicketReserve_tbls { get; set; }

    }

    public class TicketReserve_tbl
    {
        [Key]
        public int ResID { get; set; }
        [Required, Display(Name = "From City:")]

        public string Resfrom { get; set; }
        [Required, Display(Name = "To City:")]

        public string ResTo { get; set; }
        [Required, Display(Name = "Departure Date:")]
        public string ResDepDate { get; set; }

        [Required, Display(Name = "Flight Time:")]
        public string ResTime { get; set; }

        [Required, Display(Name = "Plane No:")]
        public int Planeid { get; set; }

        public virtual AeroPlaneInfo Plane_tbls { get; set; }

        [Required, Display(Name = "Seats Available:")]
        public int PlaneSeat { get; set; }
        [Required, Display(Name = "Price:")]
        public float ResTicketPrice { get; set; }

        [Required, Display(Name = "Plane Type:")]
        public string ResPlaneType { get; set; }

        public virtual ICollection<FlightBooking> tblFligthBookings { get; set; }
    }
}