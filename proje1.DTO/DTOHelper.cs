using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proje1.DTO.DTOClasses;
using proje1.Entities;

namespace proje1.DTO
{
    public class DTOHelper
    {
        public MemberDTO mapperUye(Member uye)
        {
            MemberDTO udto = new MemberDTO();
            udto.Username = uye.Username;
            udto.Name = uye.Name;
            udto.Surname = uye.Surname;
            udto.Email = uye.Email;
            return udto;
        }
    }
}
