using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_LiquidacionFacturas.Models
{
    public class Facturas
    {
        public long IdFactura { get; set; }
        public DateTime FechaEmision { get; set; }
        public string NumeroAutorizacion { get; set; }
        public string TipoDTEnombre { get; set; }
        public string Serie { get; set; }
        public long NumeroDTE { get; set; }
        public string NitEmisor { get; set; }
        public string NombreEmisor { get; set; }
        public int CodigoEstablecimiento { get; set; }
        public string NombreEstablecimiento { get; set; }
        public int IdReceptor { get; set; }
        public string NombreReceptor { get; set; }
        public int NitCertificador { get; set; }
        public string NombreCertificador { get; set; }
        public string Moneda { get; set; }
        public decimal MontoTotal { get; set; }
        public string Estado { get; set; }
        public string MarcaAnulado { get; set; }
        public DateTime FechaAnulacion { get; set; }
        public decimal IvaMontoImpuesto { get; set; }
        public decimal PetroleoMontoImpuesto { get; set; }
        public decimal TurismoHospedajeMontoImpuesto { get; set; }
        public decimal TurismoPasajesMontoImpuesto { get; set; }
        public decimal TimbrePrensaMontoImpuesto { get; set; }
        public decimal BomberosMontoImpuesto { get; set; }
        public decimal TasaMunicipalMontoImpuesto { get; set; }
        public decimal BebidasAlcoholicasMontoImpuesto { get; set; }
        public decimal TabacoMontoImpuesto { get; set; }
        public decimal CementoMontoImpuesto { get; set; }
        public decimal BebidasNoAlcoholicasMontoImpuesto { get; set; }
        public decimal TarifaPortuariaMontoImpuesto { get; set; }
        public bool EstadoFact { get; set; }
        public bool Reclamado { get; set; }
    }
}