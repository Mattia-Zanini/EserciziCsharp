namespace Esercizio2
{
    public class Veicolo
    {
        public string codveicolo { get; set; }
        public string tipo { get; set; }
        public string nome { get; set; }
        public string marca { get; set; }
        public virtual int CostoVeicoloUsato()
        {
            return 5000;
        }
        public virtual int CostoUso(int km)
        {
            return km;
        }
        public override string ToString()
        {
            return $"Codice Veicolo: {this.codveicolo}\nTipo: {this.tipo}\nNome: {this.nome}\nMarca: {this.marca}\nCosto veicolo usato: {this.CostoVeicoloUsato()} euro";
        }
    }
}