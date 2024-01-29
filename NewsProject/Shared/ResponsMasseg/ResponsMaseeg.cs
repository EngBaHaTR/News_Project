using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.Shared.ResponsMasseg
{
    public class ResponsMaseeg
    {
       public bool requst {  get; set; } = true;
      public string masseg { get; set; }
        public RequestMasseg requestMasseg { get; set; }
        public enum  RequestMasseg
        {
            
            add_Sucsses ,
            fild_opration 
            
            
                
        }

    }
}
