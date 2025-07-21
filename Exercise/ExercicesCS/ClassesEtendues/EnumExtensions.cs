using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesEtendues
{
    public enum Status { Student, Employe, Unemployed, Retired}
    public static class EnumExtensions
    {
        /// <sumary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string ToDisplayString(this Status status)
        {
            string[] libellés = { "Etudiant", "Employé", "Unemployed", "Retired" };
            return libellés[(int)status];
        }
    }
}
