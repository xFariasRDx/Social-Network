//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SocialNetwork.Core.Application.ViewModels.Login
//{
//    public class ChangesPasswordViewModel
//    {
//        [Required(ErrorMessage ="Obligatorio")]
//        [DataType(DataType.Password)]
//        [Display(Name = "Password Actual")]
//        public string OldPassword { get; set; }

//        //========================================//

//        [Required(ErrorMessage = "Obligatorio")]
//        [DataType(DataType.Password)]
//        [Display(Name = "New Password")]
//        public string NewPassword { get; set;}

//        //========================================//

//        [DataType(DataType.Password)]
//        [Display(Name = "Confirm Password")]
//        [Compare("NuevaPassword", ErrorMessage = "Las password no machean!")]
//        public string ConfirmPassword { get; set;}
//    }
//}
