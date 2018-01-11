using Droplab.VOs.ViewModels;

namespace Droplab.VO.ViewModels
{
    public class UserVO : BaseVO
    {
        public string LastName { get; set; }
        public string Username { get; set; }   
        public string Password { get; set; }
    }
}