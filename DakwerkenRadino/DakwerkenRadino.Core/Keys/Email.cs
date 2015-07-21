using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakwerkenRadino.Core.Keys
{
    public static class Email
    {
        public const string Subject = "Offerte aanvraag";
        public const string Destination = "info@dakwerken-radino.be";
        public const string DestinationName = "Info @ Dakwerken Radino";
        public const string Message = @"Beste Kenzo,
                                        
Volgend persoon wou contact opnemen via dakwerkradino-be:
Naam:             {0}
Email:            {1}
Telefoon:         {2}
Straat en nummer: {3}
Plaats:           {4} {5}
Type werk:        {6}
Boodschap:
{7}";
    }
}
