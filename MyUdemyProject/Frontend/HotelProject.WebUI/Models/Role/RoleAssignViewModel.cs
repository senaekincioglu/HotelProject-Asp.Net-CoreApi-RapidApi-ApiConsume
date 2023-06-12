namespace HotelProject.WebUI.Models.Role
{
    public class RoleAssignViewModel
    {
        public string RoleName { get; set; }
        public int RoleID { get; set; }
        public bool RoleExist { get; set; } //x kullanıcısı o role sahip mi değilmi? bunu kontrol edicek. true false döndürecek.
    }
}
