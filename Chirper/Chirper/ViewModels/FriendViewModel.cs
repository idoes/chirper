using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chirper.ViewModels
{
    public class FriendViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<CheepViewModel> Cheeps { get; set; }
    }
}