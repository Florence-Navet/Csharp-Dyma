using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendrierPerpetuel
{
	internal static class CalculateurCalendrier

	{
        /// <summary>
        /// Calcul de la date de Pâques pour une année donnée selon l'algorithme de Gauss modifié
        /// cf. https://math.stackexchange.com/questions/896954/decoding-gauss-easter-algorithm
        /// </summary>
        /// <param name="année">Année pour laquelle on veut obtenir la date de Pâques</param>
        /// <returns>Date de Pâques</returns>
        /// 
        internal static class Constantes
        {
            public const string FormatDateCourt = "dd/MM/yyyy";
            public const string FormatDateHeure = "dd/MM/yyyy HH:mm";
        }
        public static DateOnly CalculerDatePaques(int année)
		{
			int b = année - 1900;
			int c = année % 19;
			double d = Math.Floor((double)((7 * c + 1) / 19));
			double z = (11 * c + 4 - d) % 29;
			double f = Math.Floor((double)(b / 4));
			double g = (b + f + 31 - z) % 7;
			int Day = (int)(25 - z - g);

			int jour = (Day <= 0 ? Day + 31 : Day);
			int mois = (Day <= 0 ? 3 : 4);
			return new DateOnly(année, mois, jour);
		}

		/// <summary>
		/// Calcule les dates des changements de saisons pour une année donnée
		/// en utilisant une méthode approximative d'interpolation
		/// </summary>
		/// <param name="année">Année pour laquelle on veut obtenir les date de changements de saisons</param>
		/// <returns>Tuple des dates de début de printemps, été, automne et hiver</returns>
		public static (DateOnly printemps, DateOnly été, DateOnly automne, DateOnly hiver) CalculerDatesDébutsSaisons(int année)
		{
			DateOnly[] tabSaisons = new DateOnly[4];

			int k = année - 2001;
			for (int n = 0; n < 8; n++)
			{
				double dk = k + 0.25E0 * n;
				double T = 0.21451814 + 0.99997862442e0 * dk
				+ 0.00642125 * Math.Sin(1.580244 + 0.0001621008 * dk)
				+ 0.00310650 * Math.Sin(4.143931 + 6.2829005032 * dk)
				+ 0.00190024 * Math.Sin(5.604775 + 6.2829478479 * dk)
				+ 0.00178801 * Math.Sin(3.987335 + 6.2828291282 * dk)
				+ 0.00004981 * Math.Sin(1.507976 + 6.2831099520 * dk)
				+ 0.00006264 * Math.Sin(5.723365 + 6.2830626030 * dk)
				+ 0.00006262 * Math.Sin(5.702396 + 6.2827383999 * dk)
				+ 0.00003833 * Math.Sin(7.166906 + 6.2827857489 * dk)
				+ 0.00003616 * Math.Sin(5.581750 + 6.2829912245 * dk)
				+ 0.00003597 * Math.Sin(5.591081 + 6.2826670315 * dk)
				+ 0.00003744 * Math.Sin(4.3918 + 12.56578830 * dk)
				+ 0.00001827 * Math.Sin(8.3129 + 12.56582984 * dk)
				+ 0.00003482 * Math.Sin(8.1219 + 12.56572963 * dk)
				- 0.00001327 * Math.Sin(-2.1076 + 0.33756278 * dk)
				- 0.00000557 * Math.Sin(5.549 + 5.7532620 * dk)
				+ 0.00000537 * Math.Sin(1.255 + 0.0033930 * dk)
				+ 0.00000486 * Math.Sin(19.268 + 77.7121103 * dk)
				- 0.00000426 * Math.Sin(7.675 + 7.8602511 * dk)
				- 0.00000385 * Math.Sin(2.911 + 0.0005412 * dk)
				- 0.00000372 * Math.Sin(2.266 + 3.9301258 * dk)
				- 0.00000210 * Math.Sin(4.785 + 11.5065238 * dk)
				+ 0.00000190 * Math.Sin(6.158 + 1.5774000 * dk)
				+ 0.00000204 * Math.Sin(0.582 + 0.5296557 * dk)
				- 0.00000157 * Math.Sin(1.782 + 5.8848012 * dk)
				+ 0.00000137 * Math.Sin(-4.265 + 0.3980615 * dk)
				- 0.00000124 * Math.Sin(3.871 + 5.2236573 * dk)
				+ 0.00000119 * Math.Sin(2.145 + 5.5075293 * dk)
				+ 0.00000144 * Math.Sin(0.476 + 0.0261074 * dk)
				+ 0.00000038 * Math.Sin(6.45 + 18.848689 * dk)
				+ 0.00000078 * Math.Sin(2.80 + 0.775638 * dk)
				- 0.00000051 * Math.Sin(3.67 + 11.790375 * dk)
				+ 0.00000045 * Math.Sin(-5.79 + 0.796122 * dk)
				+ 0.00000024 * Math.Sin(5.61 + 0.213214 * dk)
				+ 0.00000043 * Math.Sin(7.39 + 10.976868 * dk)
				- 0.00000038 * Math.Sin(3.10 + 5.486739 * dk)
				- 0.00000033 * Math.Sin(0.64 + 2.544339 * dk)
				+ 0.00000033 * Math.Sin(-4.78 + 5.573024 * dk)
				- 0.00000032 * Math.Sin(5.33 + 6.069644 * dk)
				- 0.00000021 * Math.Sin(2.65 + 0.020781 * dk)
				- 0.00000021 * Math.Sin(5.61 + 2.942400 * dk)
				+ 0.00000019 * Math.Sin(-0.93 + 0.000799 * dk)
				- 0.00000016 * Math.Sin(3.22 + 4.694014 * dk)
				+ 0.00000016 * Math.Sin(-3.59 + 0.006829 * dk)
				- 0.00000016 * Math.Sin(1.96 + 2.146279 * dk)
				- 0.00000016 * Math.Sin(5.92 + 15.720504 * dk)
				+ 0.00000115 * Math.Sin(23.671 + 83.9950108 * dk)
				+ 0.00000115 * Math.Sin(17.845 + 71.4292098 * dk);

				double JJD = 2451545 + T * 365.25;
				double S = année / 100.0 - 18.30;
				double TETUJ = (32.23 * S * S - 15) / 86400;
				JJD += 0.0003472222;
				JJD -= TETUJ;

				double A = Trunc(JJD + 0.5);
				if ((JJD >= 2299160.5) && (A >= 2299161)) // Calendrier grégorien
				{
					double X = Trunc((A - 1867216.25) / 36524.25);
					A += 1 + X - Trunc(X / 4);
				}
				double B = A + 1524;
				double C = Trunc((B - 122.1) / 365.25);
				double D = Trunc(365.25 * C);
				double F = Trunc((B - D) / 30.6001);

				int jour = (int)Trunc(B - D - Trunc(30.6001 * F));
				int mois = (int)(F < 13.5 ? Trunc(F - 1) : Trunc(F - 13));
				int an = (int)(mois >= 3 ? Trunc(C - 4716) : Trunc(C - 4715));
				DateOnly tmpDate = new DateOnly(an, mois, jour);

				if (tmpDate.Year == année)
					tabSaisons[n % 4] = tmpDate;
			}

			return (tabSaisons[0], tabSaisons[1], tabSaisons[2], tabSaisons[3]);
		}
        public static (DateOnly, string)[] CalculerJoursFériésFrançais(int année)
        {
            DateOnly paques = CalculerDatePaques(année);

			return new (DateOnly, string)[]
			{
				(new DateOnly(année, 1, 1), "jour de l'an"),
				(paques.AddDays(1), "Lundi de Pâques"),
				(new DateOnly(année,5, 1), "Fête du Travail"),
				(new DateOnly(année,5, 8), "Armistice 1945"),
				(paques.AddDays(39), "Ascension"),
				(paques.AddDays(49), "Pentecôte"),
				(paques.AddDays(50), "Lundi de Pentecôte"),
                (new DateOnly(année,7, 14), "Fête Nationale"),
                (new DateOnly(année,8, 15), "Assomption"),
                (new DateOnly(année,11, 1), "Toussaint"),
                (new DateOnly(année,11, 11), "Armistice 1918"),
                (new DateOnly(année,12, 24), "Noël"),


            };

        }

        public static (DateTime heureEte, DateTime heureHiver) CalculerChangementsHeures(int année)
        {
            DateOnly DernierDimanche(int annee, int mois)
            {
                var dernierJour = new DateOnly(annee, mois, DateTime.DaysInMonth(annee, mois));
                int decalage = (int)dernierJour.DayOfWeek; // dimanche = 0
                return dernierJour.AddDays(-decalage);
            }

            DateOnly dernierDimancheMars = DernierDimanche(année, 3);
            DateOnly dernierDimancheOctobre = DernierDimanche(année, 10);

            DateTime heureEte = new DateTime(année, 3, dernierDimancheMars.Day, 1, 0, 0);
            DateTime heureHiver = new DateTime(année, 10, dernierDimancheOctobre.Day, 2, 0, 0);

            return (heureEte, heureHiver);
        }




        private static double Trunc(double x)
		{
			return (x > 0.0 ? Math.Floor(x) : Math.Ceiling(x));
		}
	}
}
