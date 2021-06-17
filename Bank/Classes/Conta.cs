using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Conta
    {
        //Propriedades
        private TipoConta TipoConta { get; set; }
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }

        //Método construtor
        public Conta(TipoConta tipoConta, string nome, double saldo, double credito) 
        {
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }
        public bool Sacar(double valorSaque) 
        {
            if (ValidarSaldo(valorSaque))
            {
                this.Saldo -= valorSaque;
                ImprimirMensagemFinal();
                return true;
            }
            return false;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            ImprimirMensagemFinal();
        }
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito + " | ";
            return retorno;
        }

        private bool ValidarSaldo(double valorSaque)
        {
            //Validar se o saldo é suficiente para realizar o saque
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente para realizar o saque.");
                return false;
            }
            return true;
        }
        private void ImprimirMensagemFinal()
        {
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }



    }
}
