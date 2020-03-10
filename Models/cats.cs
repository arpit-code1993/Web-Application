using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Assignment_4.Models
{
    // Model for parks data. These classes can be obtained by either using 
    // the Visual Studio editor (right-click -> Paste Special -> Paste Json as Classes)
    // or sites such as JsonToCSHarp
    public class Cats
    {
        [Key]
        public string gender { get; set; }
        public string species { get; set; }
        public string female_animal_physiological_status { get; set; }
      
        public string reproductive_status { get; set; }
        public List<Breed> breeds { get; set; }
        public List<Cat> catss { get; set; }
    }
    public class Breed
    {
        public string Is_crossbred { get; set; }
        public string breed_component { get; set; }
    }

    public class Cat
    {
       
        public int skip { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
    }
   

   





}