using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
        //public int ServiceID { get; set; } ekleme de ıd ye ihtiyaç duyulmaz
        [Required(ErrorMessage = "Hizmet ikon linki giriniz")]
        public string ServiceIcon { get; set; } //İcon
        [Required(ErrorMessage = "Hizmet başlığı giriniz")]
        [StringLength(100, ErrorMessage = "Hizmet başlığı en fazla 100 karakter olabilir")]
        public string Title { get; set; } //Başlık

        public string Description { get; set; }//Açıklama
    }
}
