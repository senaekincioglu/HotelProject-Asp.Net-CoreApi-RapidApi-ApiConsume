namespace HotelProject.WebUI.Dtos.AppUserDto
{
    public class ResultAppUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        //public string City { get; set; }
        //public string ImageUrl { get; set; }
        //public string WorkDepartment { get; set; }
        ////Her kullanıcının bir departmanı olduğundan dolayı kullanıcı yani AppUser tablosuna kullanıcı departman ıd eklenir.aşağıdaki gibi
        //public int WorkLocationID { get; set; }
    }
}
