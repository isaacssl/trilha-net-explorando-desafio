namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite == null)
            {
                throw new Exception("A Suíte ainda não foi adicionada.");
            }

            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A capacidade da suíte é insuficiente para acomodar todos os hópedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
            Console.WriteLine(Suite.Capacidade);
        }

        public int ObterQuantidadeHospedes()
        {
            if (!(Hospedes == null))
            {
                return Hospedes.Count;
            }

            return 0;
        }

        public decimal CalcularValorDiaria()
        {
            if (Hospedes == null)
            {
                throw new Exception("Reserva incompleta. Por favor, verifique se a Suíte e os Hóspedes foram devidamente atribuidos.");
            }

            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                return valor * Convert.ToDecimal(0.9);
            }

            return valor;
        }
    }
}