using Microsoft.AspNetCore.Identity;


namespace HospitalLibrary.Identity
{
    public class SecUser : IdentityUser
    {
        public int Id { get; set; }

        public bool IsBlocked { get; set; }

        public void BlockUser()
        {
            this.IsBlocked = true;
        }

        public void UnblockUser()
        {
            this.IsBlocked = false;
        }
    }
}
