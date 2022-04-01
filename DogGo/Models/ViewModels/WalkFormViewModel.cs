using System.Collections.Generic;
using System.ComponentModel;

namespace DogGo.Models.ViewModels
{
    public class WalkFormViewModel
    {
        public List<Walker> Walkers { get; set; }
        public List<Dog> Dogs { get; set; }
        [DisplayName("Dog(s)")]
        public List<int> DogIds { get; set; }
        public Walk Walk { get; set; }
    }
}
