using System.ComponentModel.DataAnnotations;

namespace WebApplication3.model
{
    public class RegTable
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    
        public string Age { get; set; }
      

        public string email { get; set; }
      
        public string PhoneNumber { get; set; }
     
        public string Country { get; set; }
    
        public string State { get; set; }

        public string City { get; set; }
    
     
        public string CPassword { get; set; }
   
    }
}
