//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace REalimenta1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ong
    {
        public int ong_id { get; set; }
        public string cnpj { get; set; }
        public string razao_social { get; set; }
        public string atividade { get; set; }
        public string email { get; set; }
        public string responsavel { get; set; }
        public string contato { get; set; }
        public int localidade_id { get; set; }
    
        public virtual localidade localidade { get; set; }
    }
}
